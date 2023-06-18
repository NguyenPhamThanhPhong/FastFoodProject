using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.InsertCommands;
using System.Windows.Media.Imaging;
using SharpCompress.Common;
using System.Windows;

namespace FastFoodUpgrade.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private Staff _currentStaff = new Staff();
        public Staff CurrentStaff
        {
            get => _currentStaff;
            set { _currentStaff = value; OnPropertyChanged(nameof(CurrentStaff)); }
        }
        private StringBuilder _filename { get; set; } = new StringBuilder("");
        public StringBuilder Filename
        {
            get => _filename;
            set { _filename = value; 
                OnPropertyChanged(nameof(Filename)); }
        }
      
        public ICommand InsertStaff { get; set; }
        public ICommand SaveImageDialog { get; set; }

        public SignUpViewModel() 
        {
            this.Filename.Append("D:\\Fastfood\\FastFoodUpgrade\\IMAGE\\Burger.png");
            SaveImageDialog = new SaveImageDialogCommand(Filename,this);
            InsertStaff = new InsertStaffCommand(CurrentStaff, this.Filename);
            GetID();
        }
        public async void GetID()
        {
            this.CurrentStaff.ID = await Staff.GenerateID();
        }
        public void ChangeFilename(string filename)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                StringBuilder bb = this.Filename;
                bb.Clear();
                bb.Append(filename);
                OnPropertyChanged(nameof(Filename));
            });

        }
    }
}
