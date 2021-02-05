using Autofac;
using Gunz.Lobby.Common.Http;
using Gunz.Lobby.Repositories.Security;
using Gunz.Lobby.Views.Interfaces;

namespace Gunz.Lobby.DependencyInjection
{
    internal sealed class AutofacModule : Module
    {
        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();


            var types = new[]
            {
                typeof(AutofacModule),
                typeof(IAnonymousHttpClient),
                typeof(IApiTokenRepository),
                typeof(IView)
            };

            foreach (var type in types)
            {
                builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetAssembly(type))
                    .AsImplementedInterfaces();
            }

            return builder.Build();
        }

        public static IContainer Container { get; } = CreateContainer();
    }
}
