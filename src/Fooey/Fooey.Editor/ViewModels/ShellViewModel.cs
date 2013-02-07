using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Fooey.Editor.Core;

namespace Fooey.Editor.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {
        private readonly Conductor<IDocument>.Collection.OneActive documents = new Conductor<IDocument>.Collection.OneActive();
        protected override void OnInitialize()
        {
            this.DisplayName = "Fooey Editor";
            documents.ActivateItem(new DocumentViewModel {DisplayName = "Document1"});
            base.OnInitialize();
        }

        public IObservableCollection<IDocument> Documents
        {
            get { return documents.Items; }
        }
    }
}
