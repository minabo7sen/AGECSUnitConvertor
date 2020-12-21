using AGS.Framework.Engineering.QuantitiesAndUnits.UnitTypes.ForcePerVolume;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class ForcePerVolumePageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public Command SomethingChanged { get; set; }
        public Command OutputHelperCommand { get; set; }
        public List<UnitCarrier> MyList { get; set; } = new List<UnitCarrier>();

        //Input Value Handling:
        ///===================
        private double _inputValue;
        public double InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;

                SomethingChangedFunction();
                OnPropertyChanged();
            }
        }

        //Output Value Handling:
        ///===================
        private double _outputValue;
        public double OutputValue
        {
            get { return _outputValue; }
            set
            {
                if (_outputValue != OutputValue)
                {

                    _outputValue = value;

                    SomethingChangedFunction();
                }
                else
                {
                    _outputValue = value;
                    OutputValueChanged();
                    OnPropertyChanged();
                }
            }

        }

        //Input Unit Handling:
        ///===================
        private UnitCarrier _inputUnit;
        public UnitCarrier SelectedInputUnit
        {
            get { return _inputUnit; }
            set
            {
                _inputUnit = value;

                SomethingChangedFunction();
                OnPropertyChanged();

            }
        }

        //Output Unit Handling:
        ///===================
        private UnitCarrier _outputUnit;
        public UnitCarrier SelectedOutputUnit
        {
            get { return _outputUnit; }
            set
            {
                _outputUnit = value;

                SomethingChangedFunction();
                OnPropertyChanged();
            }
        }

        public ForcePerVolumePageModel()
        {
            //Initilizing Commands for conversion:
            SomethingChanged = new Command(async () => await SomethingChangedFunction());
            OutputHelperCommand = new Command(async () => await OutputValueChanged());
            PopulateUnits();

        }

        public async Task OutputValueChanged()
        {
            if (OutputValue == ForcePerVolumeUnitConverter.Convert(InputValue, (ForcePerVolumeUnits)SelectedInputUnit.Id, (ForcePerVolumeUnits)SelectedOutputUnit.Id))
            {

                //do nothing
            }
            else
            {
                InputValue = ForcePerVolumeUnitConverter.Convert(OutputValue, (ForcePerVolumeUnits)SelectedOutputUnit.Id, (ForcePerVolumeUnits)SelectedInputUnit.Id);
           
            }

            //throw new System.NotImplementedException();
        }
        private void PopulateUnits()
        {
            int i = 0;
            //Filling list of units based on quanitity selected:
            foreach (var unit in ForcePerVolumeUnitConverter.UnitsStrings)
            {
                UnitCarrier sample = new UnitCarrier { Name = unit, Id = i };
                MyList.Add(sample);
                i++;
            }
        }
        public async Task SomethingChangedFunction()
        {
            //StringsToEnumConverter();
            OutputValue = ForcePerVolumeUnitConverter.Convert(InputValue, (ForcePerVolumeUnits)SelectedInputUnit.Id, (ForcePerVolumeUnits)SelectedOutputUnit.Id);
        }
    }




}

