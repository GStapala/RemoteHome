using System;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;
using RemoteHomePCL.Interfaces;
using RemoteHomePrism.Pages.Audio;
using RemoteHomePrism.Pages.Lighting;
using RemoteHomePrism.Pages.Shades;
using RemoteHomePrism.Pages.Temperature;
using RemoteHomePrism.Pages.WashMachine;

namespace RemoteHomePrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("RootPage");
        }

        protected override void ConfigureViewModelLocator()
        {
            //Auto viewModel injection changed to the same folder rather then View and ViewModels folders
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                var viewAssembleyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName,
                    viewAssembleyName);
                return Type.GetType(viewModelName);
            });
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => { return Container.Resolve(type); });

            //BindViewModelToView<WashMachineViewModel, WashMachine>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IWashMachineService, WashMachineService>();
            Container.RegisterType<IAudioService, AudioService>();
            Container.RegisterType<ILightingService, LightingService>();
            Container.RegisterType<ITemperatureService, TemperatureService>();
            Container.RegisterType<IShadesService, ShadesService>();
            Container.RegisterType<ILogger, RemoteHomePCL.Helpers.Logger>();

            // Container.RegisterTypeForNavigation<MenuPage>();
            //Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<RootPage>();
        }

        //Registers specific view model to view.
        public void BindViewModelToView<TViewModel, TView>()
        {
            ViewModelLocationProvider.Register(typeof(TView).ToString(), () => Container.Resolve<TViewModel>());
        }
    }
}