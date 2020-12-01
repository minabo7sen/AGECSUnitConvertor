﻿using AGS.Framework.Engineering.QuantitiesAndUnits.UnitTypes.Distances;
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
    public class LengthPageModel : GenericPage
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

        public LengthPageModel()
        {
            //Initilizing Commands for conversion:
            SomethingChanged = new Command(async () => await SomethingChangedFunction());
            PopulateUnits();

        }
        private async Task PopulateUnits()
        {
            int i = 0;
            //Filling list of units based on quanitity selected:
            foreach (var unit in LengthUnitConverter.UnitsStrings)
            {
                VMClass sample = new VMClass { Name = unit, Id = i };
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
