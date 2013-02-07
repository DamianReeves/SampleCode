using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Fooey.Editor.Framework;

namespace Fooey.Editor.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {
        private static int documentIndex = 0;
        private readonly Conductor<IDocument>.Collection.OneActive documents = new Conductor<IDocument>.Collection.OneActive();
        protected override void OnInitialize()
        {
            this.DisplayName = "Fooey Editor";
            this.NewDocument();
            base.OnInitialize();
        }

        public IObservableCollection<IDocument> Documents
        {
            get { return documents.Items; }
        }

        public void NewDocument()
        {
            this.documents.ActivateItem(new DocumentViewModel { DisplayName = "Document" + ++documentIndex });
        }

        public void OpenDocument()
        {
            
        }
    }
}
