using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.ViewModels
{
    public class DashBoardViewModel : ViewModelBase
    {
        private Staff _currentStaff;
        public Staff CurrentStaff
        {
            get => _currentStaff;
            set { _currentStaff = value; OnPropertyChanged(nameof(CurrentStaff)); } 
        }

        private Uri _currentPage;
        public Uri CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }
        //Constructor
        public DashBoardViewModel(MainViewModel currentMain)
        {

        }
        public DashBoardViewModel()
        {

        }
        public DashBoardViewModel(Staff s)
        {
            this._currentStaff= s;
            OnPropertyChanged(nameof(CurrentStaff));
        }
        // Methods
        public void SwitchBillPage()
        {
            CurrentPage = new Uri("/Views/Pages/BillPage.xaml", UriKind.Relative);
        }
        public void SwitchManagingPage()
        {
            CurrentPage = new Uri("/Views/Pages/ManagingPage.xaml", UriKind.Relative);

        }
        public void SwitchCustomerPage()
        {
            CurrentPage = new Uri("/Views/Pages/CustomerPage.xaml", UriKind.Relative);
        }
        public void SwitchHomePage()
        {
            CurrentPage = new Uri("/Views/Pages/HomePage.xaml", UriKind.Relative);


        }
        public void SwitchIngredientPage()
        {
            CurrentPage = new Uri("/Views/Pages/IngredientPage.xaml", UriKind.Relative);

        }
        public void SwitchProductPage()
        {
            CurrentPage = new Uri("/Views/Pages/ProductPage.xaml", UriKind.Relative);

        }
        public void SwitchSettingPage()
        {
            CurrentPage = new Uri("/Views/Pages/SettingPage.xaml", UriKind.Relative);

        }
    }
}
