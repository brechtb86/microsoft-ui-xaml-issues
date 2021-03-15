using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace WinUI3Issues.ViewModels
{
    public class XamlCommandBindingIconSourceIssueViewModel : BaseViewModel
    {
        public XamlUICommand PickFolderWithIcon
        {
            get;
            private set;
        }

        public XamlUICommand PickFolderWithLabel
        {
            get;
            private set;
        }

        public XamlCommandBindingIconSourceIssueViewModel()
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

            this.PickFolderWithLabel = new XamlUICommand
            {
                Label = "Pick folder",
                Description = "Select a movie folder to add...",
            };

            this.PickFolderWithLabel.ExecuteRequested += async (command, args) =>
                {
                    // Do something
                };
        }
    }
}
