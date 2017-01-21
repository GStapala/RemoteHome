using Android.OS;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace SharedApp
{
    public static class SharedStatic
    {
        public static string AndroidDevName { get { return String.Format("{0} {1}", Build.Manufacturer, Build.Model); } }
    }
}
