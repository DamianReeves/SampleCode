using System;

namespace DamianReeves.Simple.Spreadsheets {
    using Caliburn.Micro;
    using ReactiveUI;
    public class WorksheetCell : ReactiveObject
    {
        public string Address { get; set; }
        public string Formula { get; set; }

        public object GetValue() {
            throw new NotImplementedException();
        }
    }
}