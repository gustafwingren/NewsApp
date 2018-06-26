using Autofac;
using NewsApp.Services.Analytic;
using NewsApp.Services.Authentication;
using NewsApp.Services.Dialog;
using NewsApp.Services.Navigation;
using NewsApp.Services.OpenUri;
using System;

namespace NewsApp.ViewModels.Base
{
    public class Locator
    {
        private IContainer _container;
        private ContainerBuilder _containerBuilder;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        public Locator()
        {
            _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<AnalyticService>().As<IAnalyticService>();
            _containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            _containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            _containerBuilder.RegisterType<OpenUriService>().As<IOpenUriService>();
            _containerBuilder.RegisterType<DefaultBrowserCookiesService>().As<IBrowserCookiesService>();
            _containerBuilder.RegisterType<GravatarUrlProvider>().As<IAvatarUrlProvider>();

            _containerBuilder.RegisterType<HomeViewModel>();
            _containerBuilder.RegisterType<LoginViewModel>();
            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<MenuViewModel>();


            _containerBuilder.RegisterType<ExtendedSplashViewModel>();

        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void Register<T>() where T : class
        {
            _containerBuilder.RegisterType<T>();
        }

        public void Build()
        {
            _container = _containerBuilder.Build();
        }
    }
}
