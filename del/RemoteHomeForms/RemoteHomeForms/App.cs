using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RemoteHomeForms.Pages;
using RemoteHomeForms.Pages.About;
using RemoteHomeForms.Views;
using Xamarin.Forms;

namespace RemoteHomeForms
{
    public class App : Application
    {
        public App()
        {
            MainPage = new RootPage();
        }
    }
}
