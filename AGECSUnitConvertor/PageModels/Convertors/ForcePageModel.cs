using AGS.Framework.Engineering.QuantitiesAndUnits.UnitTypes.Forces;
using PropertyChanged;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class ForcePageModel : GenericPage
    {

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
        private VMClass _inputUnit;
        public VMClass SelectedInputUnit
        {
            get { return _inputUnit; }
            set
            {
                _inputUnit = value;

                SomethingChangedFunction();

            }
        }

        //Output Unit Handling:
        ///===================
        private VMClass _outputUnit;
        public VMClass SelectedOutputUnit
        {
            get { return _outputUnit; }
            set
            {
                _outputUnit = value;

                SomethingChangedFunction();

            }
        }

        public ForcePageModel()
        {
            //Initilizing Commands for conversion:
            SomethingChanged = new Command(async () => await SomethingChangedFunction());
            PopulateUnits();

        }
        private async Task PopulateUnits()
        {
            int i = 0;
            //Filling list of units based on quanitity selected:
            foreach (var unit in ForceUnitConverter.UnitsStrings)
            {
                VMClass sample = new VMClass { Name = unit, Id = i };
                MyList.Add(sample);
                i++;
            }
        }
        public async Task SomethingChangedFunction()
        {
            //StringsToEnumConverter();
            OutputValue = ForceUnitConverter.Convert(InputValue, (ForceUnits)SelectedInputUnit.Id, (ForceUnits)SelectedOutputUnit.Id);
        }
    }




}

