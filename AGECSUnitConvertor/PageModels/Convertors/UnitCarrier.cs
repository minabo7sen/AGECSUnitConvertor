using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{

    public class UnitCarrier : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;

        public event PropertyChangedEventHandler PropertyChanged;
    }


}

