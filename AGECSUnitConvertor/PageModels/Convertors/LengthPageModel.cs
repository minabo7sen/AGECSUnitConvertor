using AGS.Framework.Engineering.QuantitiesAndUnits.UnitTypes.Distances;
using FreshMvvm;
using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class LengthPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public Command SomethingChanged { get; set; }
        public Command Swap { get; set; }
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

        public LengthPageModel()
        {
            //Initilizing Commands for conversion:
            SomethingChanged = new Command(async () => await SomethingChangedFunction());
            Swap = new Command(async () => await SwapInputAndOutput());
            PopulateUnits(); 

        }

        private async Task SwapInputAndOutput()
        {
            var temp = InputValue;
            InputValue = OutputValue;
            OutputValue = temp;
            SomethingChangedFunction();
        }

        private void PopulateUnits()
        {
            int i = 0;
            //Filling list of units based on quanitity selected:
            foreach (var unit in LengthUnitConverter.UnitsStrings)
            {
                UnitCarrier sample = new UnitCarrier { Name = unit, Id = i };
                MyList.Add(sample);
                i++;
            }
        }
        public async Task SomethingChangedFunction()
        {
            //StringsToEnumConverter();
            OutputValue = LengthUnitConverter.Convert(InputValue, (LengthUnits)SelectedInputUnit.Id, (LengthUnits)SelectedOutputUnit.Id);
        }
    }




}

