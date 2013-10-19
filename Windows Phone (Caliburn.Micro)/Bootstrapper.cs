using Caliburn.Micro;
using $safeprojectname$.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace $safeprojectname$
{
    public class Bootstrapper : PhoneBootstrapper
    {
        PhoneContainer _container;

        protected override void Configure()
        {
            _container = new PhoneContainer();
            _container.RegisterPhoneServices(RootFrame);
            _container.PerRequest<MainPageViewModel>();
            AddCustomConventions();
        }

        private void AddCustomConventions()
        {
            //TODO: Add your custom conventions here
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new Assembly[] { this.GetType().Assembly };
        }

        protected override void OnUnhandledException(object sender, System.Windows.ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        protected override object GetInstance(System.Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAllInstances(System.Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
