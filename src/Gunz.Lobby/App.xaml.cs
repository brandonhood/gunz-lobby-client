using Autofac;
using Gunz.Lobby.DependencyInjection;
using Gunz.Lobby.Views.Login;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace Gunz.Lobby
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ILifetimeScope _lifetimeScope;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            _lifetimeScope = AutofacModule.Container.BeginLifetimeScope();
            _lifetimeScope.Resolve<ILoginPresenter>().Show();
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
        }
    }
}
