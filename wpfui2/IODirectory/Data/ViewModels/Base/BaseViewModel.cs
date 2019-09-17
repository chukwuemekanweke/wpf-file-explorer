using PropertyChanged;
using System.ComponentModel;

namespace wpfui2.IODirectory.Data.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}