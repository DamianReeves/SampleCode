using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;

namespace Fooey.Editor.Framework
{
    public interface IDocument : IScreen
    {
         
    }
    
    public interface ITool : IScreen
    {
        ICommand CloseCommand { get; }
        Dock PreferredLocation { get; }
        bool IsVisible { get; set; }
    }
}