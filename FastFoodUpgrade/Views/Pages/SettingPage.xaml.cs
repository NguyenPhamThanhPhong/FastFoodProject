using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        private Staff s;
        public SettingPage()
        {
            InitializeComponent();
            this.ComboboxAcessRight.ItemsSource = new List<string>() { "Admin", "User" };
            this.ComboboxGender.ItemsSource = new List<string>() { "Male", "Female", "Others" };
            DashBoardWindow main = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as DashBoardWindow;
            DashBoardViewModel vm = main.DataContext as DashBoardViewModel;
            Staff loggedinS = vm.CurrentStaff;
            s = loggedinS;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (s != null)
                this.DataContext = new SettingViewModel(s);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingViewModel vm = this.DataContext as SettingViewModel;
            vm.ConfirmMail();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SettingViewModel vm = this.DataContext as SettingViewModel;
            if (vm.UpdateStaff != null)
            {
                vm.UpdateStaff.Execute(null);
                DashBoardWindow main = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as DashBoardWindow;
                main.UpdateStaff();

            }
        }
    }
}
