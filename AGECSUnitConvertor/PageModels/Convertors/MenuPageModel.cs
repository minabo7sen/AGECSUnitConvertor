﻿using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class MenuPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public MenuPageModel()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem{ Label="Length Converter",Image="Length.png",Navigate = new Command(async () => await NavigateToLength())},
                new MenuItem{ Label="Force Converter",Image="Force.png",Navigate = new Command(async () => await NavigateToForce())},
                new MenuItem{ Label="Moment Converter",Image="Moment.png",Navigate = new Command(async () => await NavigateToMoment())},
                new MenuItem{ Label="Stress Converter",Image="Stress.png",Navigate = new Command(async () => await NavigateToStress())},

            };
        }
        private async Task NavigateToLength()
        {
            await CoreMethods.SwitchSelectedMaster<LengthPageModel>();
        }
        private async Task NavigateToForce()
        {
            await CoreMethods.SwitchSelectedMaster<ForcePageModel>();
        }
        private async Task NavigateToMoment()
        {
            await CoreMethods.SwitchSelectedMaster<MomentPageModel>();
        }
        private async Task NavigateToStress()
        {
            await CoreMethods.SwitchSelectedMaster<StressPageModel>();
        }

    }

    public class MenuItem
    {
        public string Label { get; set; }
        public Command Navigate { get; set; }
        public string Image { get; set; }
    }
}
