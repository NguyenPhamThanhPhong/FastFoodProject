using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FastFoodUpgrade.ViewModels.InsertFormViewModels
{
    public class InsertStaffViewModel : ViewModelBase
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
            set
            {_filename = value; OnPropertyChanged(nameof(Filename));}
        }
        public ICommand InsertStaff { get; set; }
        public ICommand SaveFileDialogCommand { get; set; }
        public InsertStaffViewModel() { }
        public InsertStaffViewModel(Staff s,Uri u)
        {
        }

        public static async Task<InsertStaffViewModel> Initialize()
        {
            InsertStaffViewModel viewModel= new InsertStaffViewModel();
            await viewModel.IntializeAsync();
            return viewModel;
        }
        private async Task IntializeAsync()
        {
            await Task.Run(async () =>
            {
                int x = await Staff.GenerateID();
                CurrentStaff.ID = x;
                this.InsertStaff = new InsertStaffCommand(CurrentStaff,Filename);
                this.SaveFileDialogCommand = new SaveImageDialogCommand(Filename, this);
            });
        }
    }
}
