using System.ComponentModel;

namespace Com.Igniscor.DevProject.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
