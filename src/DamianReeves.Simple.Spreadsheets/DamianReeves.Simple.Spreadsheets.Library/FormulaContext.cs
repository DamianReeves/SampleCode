using System;
using System.Collections;
using System.Collections.Generic;

namespace DamianReeves.Simple.Spreadsheets {
    public class FormulaContext: IEnumerable<KeyValuePair<string, object>> {
        private readonly IDictionary<string, object> _variables;

        public FormulaContext(IDictionary<string,object> variables) {
            if (variables == null) throw new ArgumentNullException("variables");
            _variables = variables;
        }

        public object this[string name] {
            get { return _variables[name]; }
            set { _variables[name] = value; }
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() {
            return _variables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}