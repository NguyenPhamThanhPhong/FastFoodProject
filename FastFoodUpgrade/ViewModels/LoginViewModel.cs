﻿using FastFoodUpgrade.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username="";
        public string username 
        { 
            get
            {return _username;}
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }
        private string _password="";
        public string password 
        {
            get{return _password;}
            set
            {
                _password= value;
                OnPropertyChanged(nameof(password));
            }
        }
        public ICommand CommandLogin { get; }
        public LoginViewModel() 
        {
            CommandLogin = new LoginCommand(this);
            //CommandLogin = new LoginCommand();
        }
    }
}
