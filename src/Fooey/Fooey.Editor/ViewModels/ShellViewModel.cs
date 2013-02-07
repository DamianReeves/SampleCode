using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Fooey.Editor.Framework;
using Fooey.Editor.Tools.ViewModels;

namespace Fooey.Editor.ViewModels
{
    public class ShellViewModel : Conductor<IDocument>.Collection.OneActive, IShell
    {
        private static int documentIndex = 0;
        private readonly Conductor<ITool>.Collection.OneActive tools = new Conductor<ITool>.Collection.OneActive(); 
        protected override void OnInitialize()
        {
            this.DisplayName = "Fooey Editor";
            this.NewDocument();
            this.ShowOutputWindow();
            base.OnInitialize();
        }

        public IObservableCollection<IDocument> Documents
        {
            get { return this.Items; }
        }

        public IObservableCollection<ITool> Tools
        {
            get { return this.tools.Items; }
        } 

        public void NewDocument()
        {
            this.ActivateItem(new DocumentViewModel { DisplayName = "Document" + ++documentIndex });
        }

        public void OpenDocument()
        {
            
        }


        public void ShowOutputWindow()
        {
            this.tools.ActivateItem(new OutputPaneViewModel { DisplayName = "Output Window"});
        }

        public override void ActivateItem(IDocument item)
        {
            base.ActivateItem(item);
        }
    }
}
