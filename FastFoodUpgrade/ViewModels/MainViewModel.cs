using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastFoodUpgrade.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //public MainWindow = 
        private ViewModelBase _currentViewModel;
        public ViewModelBase currentViewModel 
        { 
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(currentViewModel));
            }
        }
        public MainViewModel()
        {
            currentViewModel= new LoginViewModel(this);
        }
    }

}
