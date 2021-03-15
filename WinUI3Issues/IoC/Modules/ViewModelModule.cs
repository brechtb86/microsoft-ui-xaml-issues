using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WinUI3Issues.ViewModels;

namespace WinUI3Issues.IoC.Modules
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ItemsRepeaterScrollIssueViewModel>().ToSelf().InSingletonScope();
            this.Bind<XamlCommandBindingIconSourceIssueViewModel>().ToSelf().InSingletonScope();
        }
    }
}
