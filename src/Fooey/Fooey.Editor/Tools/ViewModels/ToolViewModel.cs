using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using Fooey.Editor.Framework;

namespace Fooey.Editor.Tools.ViewModels
{
    public class ToolViewModel : Screen, ITool
    {
        private bool _isVisible = true;
        public ICommand CloseCommand { get; protected set; }
        public Dock PreferredLocation { get; protected set; }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
    }
}