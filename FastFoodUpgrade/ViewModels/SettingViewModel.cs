using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.UpdateCommands;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        private Staff _currentStaff ;
        public Staff CurrentStaff
        {
            get => _currentStaff;
            set { _currentStaff = value; OnPropertyChanged(nameof(CurrentStaff)); }
        }
        private StringBuilder _filename { get; set; } = new StringBuilder("");
        public StringBuilder Filename
        {
            get => _filename;
            set
            {
                _filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }
        //handling mail
        private bool _isConfirmed = true;
        public bool IsConfirmed
        {
            get => _isConfirmed;
            set { _isConfirmed = value; OnPropertyChanged(nameof(IsConfirmed)); }
        }
        public string Current6Digits { get; set; }
        private string _code;
        public string Code
        {
            get => _code;
            set { _code = value;OnPropertyChanged(nameof(Code)); }
        }
        private string _mailConfirmed;
        public string MailConfirmed
        {
            get => _mailConfirmed;
            set { _mailConfirmed=  value; OnPropertyChanged(nameof(MailConfirmed));}
        }
        //end handling mail
        public ICommand SaveFileDialog { get; set; }
        public ICommand UpdateStaff { get; set; }
        public SettingViewModel(Staff s) {
            this.CurrentStaff = s;
            this.Filename.Clear();
            this.Filename.Append(ImageStorage.GetImage(ImageStorage.StaffImageLocation, s.Avatar));
            this.MailConfirmed = s.Email;
            this.SaveFileDialog = new SaveImageDialogCommand(Filename, this);
            this.UpdateStaff = new UpdateStaffCommand(this);
        }
        public async void ConfirmMail()
        {
            await Task.Run(() =>
            {
                string str = MailUtil.Generate6Digits();
                Current6Digits = str;
                MailConfirmed = CurrentStaff.Email;
                if (String.IsNullOrEmpty(MailConfirmed))
                {
                    MessageBox.Show("Please fill in Mail first");
                    return;
                }
                MailUtil.SendEmail(MailConfirmed, "NoReply", str);
            });
        }
        private void CheckCode()
        {
            if (!String.IsNullOrEmpty(Current6Digits))
            {
                IsConfirmed = false;
                if (Code==Current6Digits)
                {
                    IsConfirmed = true;
                }
            }
        }
        //private async Task InitializeAsync()
        //{
        //    await Task.Run(() =>
        //    {

        //    });
        //}
    }
}
