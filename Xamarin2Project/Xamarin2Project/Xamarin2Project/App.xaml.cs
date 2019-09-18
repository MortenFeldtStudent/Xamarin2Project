﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin2Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Xamarin2Project.MainPage())
            {
                BarBackgroundColor = Color.DarkOrange,
                BarTextColor = Color.White,
                
            };
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
