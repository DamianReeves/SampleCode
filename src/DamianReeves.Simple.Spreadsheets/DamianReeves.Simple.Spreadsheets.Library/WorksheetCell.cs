using System;

namespace DamianReeves.Simple.Spreadsheets {
    using Caliburn.Micro;
    using ReactiveUI;
    public class WorksheetCell : ReactiveObject
    {
        public string Address { get; set; }
        public string Formula { get; private set; }
        public string Text { get; set; }
        protected Func<object> FormulaValueAccessor { get; set; }  

        public object GetValue() {
            throw new NotImplementedException();
        }

        protected void OnTextChanged() {
            
        }
    }
}