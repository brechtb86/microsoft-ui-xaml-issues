using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI3Issues.IoC;
using WinUI3Issues.ViewModels;

namespace WinUI3Issues.Common
{
    public class ViewModelLocator
    {
        public ItemsRepeaterScrollIssueViewModel ItemsRepeaterScrollIssueViewModel => IocKernel.Get<ItemsRepeaterScrollIssueViewModel>();
        public XamlCommandBindingIconSourceIssueViewModel XamlCommandBindingIconSourceIssueViewModel => IocKernel.Get<XamlCommandBindingIconSourceIssueViewModel>();
    }
}
