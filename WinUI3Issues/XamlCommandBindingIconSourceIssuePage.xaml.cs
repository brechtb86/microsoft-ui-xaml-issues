using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Issues
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class XamlCommandBindingIconSourceIssuePage : Page
    {
        public XamlUICommand PickFolderWithIcon
        {
            get;
            private set;
        }


        public XamlCommandBindingIconSourceIssuePage()
        {
            this.PickFolderWithIcon = new XamlUICommand
            {
                IconSource = new SymbolIconSource
                {
                    Symbol = Symbol.Folder
                },
                Description = "Select a movie folder to add...",
            };

            this.PickFolderWithIcon.ExecuteRequested += async (command, args) =>
            {
                // Do something
            };

            this.InitializeComponent();
        }
    }
}
