using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fooey.Editor.Tools.ViewModels
{
    public class OutputPaneViewModel : ToolViewModel
    {
        public OutputPaneViewModel()
        {
            PreferredLocation = Dock.Bottom;
        }
    }
}
