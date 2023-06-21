using FastFoodUpgrade.Commands;
using FastFoodUpgrade.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Windows
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            this.DataContext = new SignUpViewModel();
            ComboboxAcessright.ItemsSource = new List<String>() { "Admin", "Staff"};
            ComboboxGender.ItemsSource = new List<String>() { "Male", "Female", "Other" };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as SignUpViewModel).InsertStaff.Execute(null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri u = new Uri("/IMAGE/Burger.png",UriKind.Relative);
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            string filepath = null;
            if (saveFileDialog.ShowDialog() == true)
            {
                filepath = saveFileDialog.FileName;
            }
            if (filepath != null)
            {
                MessageBox.Show(filepath);
                MyImage.Source = null;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(filepath);
                bitmapImage.EndInit();
                MyImage.Source = bitmapImage;
            }
            //SaveImageDialogCommand mycommand = new SaveImageDialogCommand(u);
            //mycommand.Execute(null);
            //if(u == null )
            //{
            //    return;
            //}


        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SignUpViewModel vm = this.DataContext as SignUpViewModel;
            //vm.Filename.Clear();
            //vm.Filename.Append();
            vm.ChangeFilename("D:\\Fastfood\\FastFoodUpgrade\\IMAGE\\test.png");



        }

        //Send mail here
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignUpViewModel vm = this.DataContext as SignUpViewModel;
            vm.ConfirmMail();
        }
        //insert
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SignUpViewModel vm = this.DataContext as SignUpViewModel;
            if (vm.InsertStaff != null)
            {
                vm.InsertStaff.Execute(this);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
