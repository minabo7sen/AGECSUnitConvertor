using FreshMvvm;
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
                new MenuItem{ Label="Length",Image="Length.png",Navigate = new Command(async () => await NavigateToLength())},
                new MenuItem{ Label="Force",Image="Force.png",Navigate = new Command(async () => await NavigateToForce())},
                new MenuItem{ Label="Moment",Image="Moment.png",Navigate = new Command(async () => await NavigateToMoment())},
                new MenuItem{ Label="Stress",Image="Stress.png",Navigate = new Command(async () => await NavigateToStress())},
                new MenuItem{ Label="Acceleration",Image="Acceleration.png",Navigate = new Command(async () => await NavigateToAcceleration())},
                new MenuItem{ Label="Angle",Image="Acceleration.png",Navigate = new Command(async () => await NavigateToAngle())},
                new MenuItem{ Label="Area",Image="Acceleration.png",Navigate = new Command(async () => await NavigateToArea())},

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
        private async Task NavigateToAcceleration()
        {
            await CoreMethods.SwitchSelectedMaster<AccelerationPageModel>();
        }
        private async Task NavigateToAngle()
        {
            await CoreMethods.SwitchSelectedMaster<AnglePageModel>();
        }
        private async Task NavigateToArea()
        {
            await CoreMethods.SwitchSelectedMaster<AreaPageModel>();
        }

    }

    public class MenuItem
    {
        public string Label { get; set; }
        public Command Navigate { get; set; }
        public string Image { get; set; }
    }
}
