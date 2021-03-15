using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace WinUI3Issues.IoC
{
    public static class IocKernel
    {
        private static IReadOnlyKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            _kernel ??= new KernelConfiguration(modules).BuildReadonlyKernel();
        }
    }
}
