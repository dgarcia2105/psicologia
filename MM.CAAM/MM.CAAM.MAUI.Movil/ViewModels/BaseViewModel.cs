using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MM.CAAM.MAUI.Movil.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        //private ISettingsService SettingsService => DependencyService.Get<ISettingsService>();

        public bool IsBusy { get; set; }
        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand { get; set; }
    }
}
