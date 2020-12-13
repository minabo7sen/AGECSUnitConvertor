using FreshMvvm;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class MenuPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public Command SaveOrder { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public MenuPageModel()
        {
            SaveOrder = new Command(async () => await SaveListOrder());
            TryToLoadSavedList();

            if (MenuItems.Count < 1)
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
                    new MenuItem{ Label="Force Per Length",Image="ForcePerLength.png",Navigate = new Command(async () => await NavigateToForcePerLength())},
                    new MenuItem{ Label="Force Per Volume",Image="ForcePerVolume.png",Navigate = new Command(async () => await NavigateToForcePerVolume())},
                    new MenuItem{ Label="Inertia",Image="Inertia.png",Navigate = new Command(async () => await NavigateToInertia())},

                 };
            }
        }

        private async Task TryToLoadSavedList()
        {
            try
            {
                var listString = await SecureStorage.GetAsync("ConvertersList");
                if (listString != null)
                {

                    var x = JsonConvert.DeserializeObject<List<JsonMenuItem>>(listString);
                    foreach (var json in x)
                    {
                        MenuItem item = new MenuItem
                        {
                            Label = json.Label,
                            Image = json.Image,
                            Navigate = CommandHelper(json.Label)
                        };
                        MenuItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        private async Task SaveListOrder()
        {
            try
            {
                var listString = JsonConvert.SerializeObject(MenuItems);

                await SecureStorage.SetAsync("ConvertersList", listString);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        public async Task NavigateToLength()
        {
            await CoreMethods.SwitchSelectedMaster<LengthPageModel>();
        }
        public async Task NavigateToForce()
        {
            await CoreMethods.SwitchSelectedMaster<ForcePageModel>();
        }
        public async Task NavigateToMoment()
        {
            await CoreMethods.SwitchSelectedMaster<MomentPageModel>();
        }
        public async Task NavigateToStress()
        {
            await CoreMethods.SwitchSelectedMaster<StressPageModel>();
        }
        public async Task NavigateToAcceleration()
        {
            await CoreMethods.SwitchSelectedMaster<AccelerationPageModel>();
        }
        public async Task NavigateToAngle()
        {
            await CoreMethods.SwitchSelectedMaster<AnglePageModel>();
        }
        public async Task NavigateToArea()
        {
            await CoreMethods.SwitchSelectedMaster<AreaPageModel>();
        }
        public async Task NavigateToForcePerLength()
        {
            await CoreMethods.SwitchSelectedMaster<ForcePerLengthPageModel>();
        }
        public async Task NavigateToForcePerVolume()
        {
            await CoreMethods.SwitchSelectedMaster<ForcePerVolumePageModel>();
        }
        public async Task NavigateToInertia()
        {
            await CoreMethods.SwitchSelectedMaster<InertiaPageModel>();
        }

        public Command Navigator { get; set; }
        public Command CommandHelper(string label)
        {
            if (label == "Length")
                Navigator = new Command(async () => await NavigateToLength());
            else if (label == "Force")
                Navigator = new Command(async () => await NavigateToForce());
            else if (label == "Angle")
                Navigator = new Command(async () => await NavigateToAngle());
            else if (label == "Moment")
                Navigator = new Command(async () => await NavigateToMoment());
            else if (label == "Stress")
                Navigator = new Command(async () => await NavigateToStress());
            else if (label == "Acceleration")
                Navigator = new Command(async () => await NavigateToAcceleration());
            else if (label == "Force Per Length")
                Navigator = new Command(async () => await NavigateToForcePerLength());
            else if (label == "Force Per Volume")
                Navigator = new Command(async () => await NavigateToForcePerVolume());
            else if (label == "Inertia")
                Navigator = new Command(async () => await NavigateToInertia());

            return Navigator;
        }

        public class MenuItem
        {
            public MenuItem()
            {

            }
            public string Label { get; set; }
            public Command Navigate { get; set; }
            public string Image { get; set; }
        }
    }

    public class JsonMenuItem
    {
        public string Label { get; set; }
        public string Image { get; set; }

    }

}
