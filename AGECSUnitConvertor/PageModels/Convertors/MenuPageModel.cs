using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class MenuPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public Command GoLength { get; set; }
        public Command GoForce { get; set; }
        public Command GoMoment { get; set; }
        public MenuPageModel()
        {
            GoLength = new Command(async () => await NavigateToLength());
            GoForce = new Command(async () => await NavigateToForce());
            GoMoment = new Command(async () => await NavigateToMoment());
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

    }
}
