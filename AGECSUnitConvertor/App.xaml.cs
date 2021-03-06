﻿using AGECSUnitConvertor.PageModels.Convertors;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGECSUnitConvertor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadMasterDetail();
            //LoadBasicNavigation();
        }
        public void LoadMasterDetail()
        {
            var masterDetailNav = new FreshMasterDetailNavigationContainer();
            masterDetailNav.Init("Unit Convertor");
            masterDetailNav.AddPage<LengthPageModel>("Length");
            masterDetailNav.AddPage<ForcePageModel>("Force");
            masterDetailNav.AddPage<MomentPageModel>("Moment");
            masterDetailNav.AddPage<StressPageModel>("Stress");
            masterDetailNav.AddPage<AccelerationPageModel>("Acceleration");
            masterDetailNav.AddPage<AnglePageModel>("Angle");
            masterDetailNav.AddPage<AreaPageModel>("Area");
            masterDetailNav.AddPage<ForcePerLengthPageModel>("Force Per Length");
            masterDetailNav.AddPage<ForcePerVolumePageModel>("Force Per Volume");
            masterDetailNav.AddPage<InertiaPageModel>("Inertia");
            Page master = FreshPageModelResolver.ResolvePageModel<MenuPageModel>();
            Page detail = FreshPageModelResolver.ResolvePageModel<LengthPageModel>();

            master.Title = "Unit Convertor";
            masterDetailNav.Master = master;
            //masterDetailNav.Detail = detail;
            Application.Current.MainPage = masterDetailNav;
        }
        public void LoadBasicNavigation()
        {
            //Page page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
            //FreshNavigationContainer basicNavContainer = new FreshNavigationContainer(page);
            //MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
