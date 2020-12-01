using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGECSUnitConvertor.PageModels.Convertors
{
    [AddINotifyPropertyChangedInterface]
    public class GenericPage : FreshBasePageModel, INotifyPropertyChanged
    {
        public List<VMClass> MyList { get; set; } = new List<VMClass>();

        public Command SomethingChanged { get; set; }

        
        public GenericPage()
        {
        }
        
    }

    public class VMClass : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enum LengthUnit { get; set; }
        public override string ToString() => Name;

        public event PropertyChangedEventHandler PropertyChanged;
    }


}

