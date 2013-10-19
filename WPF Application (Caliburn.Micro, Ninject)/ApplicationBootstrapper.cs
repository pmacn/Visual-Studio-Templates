using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$
{
    public class ApplicationBootstrapper : Bootstrapper<ShellViewModel>
    {
        readonly static IKernel Kernel = new StandardKernel();

        protected override void Configure()
        {
            Kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            base.Configure();
        }

        protected override object GetInstance(Type service, string key)
        {
            return Kernel.Get(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            Kernel.Inject(instance);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
            Kernel.Dispose();
        }
    }
}