using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace FormulaParser
{
    public static class ExpressionParser {
        public static Expression<Func<decimal>> ParseExpression(string text) {
            return Lambda.Parse(text);
        }

        static Parser<ExpressionType> Operator(string op, ExpressionType opType) {
            return Parse.String(op).Token().Return(opType);
        }

        static readonly Parser<ExpressionType> Add = Operator("+", ExpressionType.AddChecked);
        static readonly Parser<ExpressionType> Subtract = Operator("-", ExpressionType.SubtractChecked);
        static readonly Parser<ExpressionType> Multiply = Operator("*", ExpressionType.MultiplyChecked);
        static readonly Parser<ExpressionType> Divide = Operator("/", ExpressionType.Divide);
        static readonly Parser<char> LetterOrUnderscore = Parse.Char(c => char.IsLetter(c) || c == '_', "letter or underscore");
        static readonly Parser<char> LetterOrDigitOrUnderscore = Parse.Char(c => char.IsLetterOrDigit(c) || c == '_', "letter or digit or underscore");

        static readonly Parser<string> Identifier =
            from ws1 in Parse.WhiteSpace.Many()
            from first in LetterOrUnderscore.Once().Text()
            from rest in LetterOrDigitOrUnderscore.Many().Text()
            from ws2 in Parse.WhiteSpace.Many()
            select first + rest;
        
        static readonly Parser<Expression> Constant =
            (from d in Parse.Decimal.Token()
             select (Expression)Expression.Constant(decimal.Parse(d))).Named("number");

        static readonly Parser<Expression> Factor =
            ((from lparen in Parse.Char('(')
              from expr in Parse.Ref(() => Expr)
              from rparen in Parse.Char(')')
              select expr).Named("expression")
             .XOr(Constant)).Token();

        static readonly Parser<Expression> Term = Parse.ChainOperator(Multiply.Or(Divide), Factor, Expression.MakeBinary);

        static readonly Parser<Expression> Expr = Parse.ChainOperator(Add.Or(Subtract), Term, Expression.MakeBinary);

        static readonly Parser<Expression> Assignment =
            from identifier in Identifier.Once()
            from assign in Parse.Char('=')
            from ws in Parse.WhiteSpace.Many()
            from expr in Expr
            select (Expression)Expression.Assign(
                Expression.Variable(typeof(decimal), identifier.Single()),
                expr);

        static readonly Parser<Expression<Func<decimal>>> Lambda =
            Expr.End().Select(body => Expression.Lambda<Func<decimal>>(body));
    }
}
