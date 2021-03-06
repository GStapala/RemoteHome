﻿using System.Collections.Generic;
using RemoteHome.Pages.About;
using RemoteHome.Pages.Audio;
using RemoteHome.Pages.Home;
using RemoteHome.Pages.Lighting;
using RemoteHome.Pages.Shades;
using RemoteHome.Pages.Temperature;
using RemoteHome.Pages.WashMachine;
using RemoteHome.Properties;
using Xamarin.Forms;

namespace RemoteHome.SideMenu
{
    /// <summary>
    ///     Items on side menu list (drawer)
    /// </summary>
    public class MenuListData : List<MenuViewModel>
    {
        public MenuListData()
        {
            Add(new MenuViewModel("house1.png", Resources.PageHomeTitle, typeof(Home), Color.FromHex("#F57C00")));//orange
            Add(new MenuViewModel("washmachine.png", Resources.PageWashMachineTitle, typeof(WashMachine),Color.FromHex("#1976d2"))); //blue
            Add(new MenuViewModel("audio.png", Resources.PageAudioTitle, typeof(Audio), Color.FromHex("#512da8")));//purple
            Add(new MenuViewModel("temperature.png", Resources.PageTemperatureTitle, typeof(Temperature),Color.FromHex("#388e3c"))); //Green
            Add(new MenuViewModel("shades.png", Resources.PageShadesTitle, typeof(Shades), Color.FromHex("#303F9F")));//Indygo
            Add(new MenuViewModel("lights.png", Resources.PageLightingTitle, typeof(Lighting), Color.FromHex("#fbc02d")));//Yellow
            Add(new MenuViewModel("aboutus.png", Resources.PageAboutTitle, typeof(About), Color.FromHex("#fbc02d")));//Blueish
        }
    }
}