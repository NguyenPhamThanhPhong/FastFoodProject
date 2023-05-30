using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.ViewModels
{
    public class ManagingViewModel : ViewModelBase
    {
        // Listview ItemSource
        private ObservableCollection<Staff> _staffs;
        public ObservableCollection<Staff> Staffs
        {
            get { return _staffs; }
            set { _staffs = value; OnPropertyChanged(nameof(Staffs)); }
        }
        // Search String in textbox
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set 
            { 
                _searchString = value; 
                Search(); 
                OnPropertyChanged(nameof(SearchString)); 
            }
        }
        // COmbobox
        private int _selectedFilterIndex = -1;
        public int SelectedFilterIndex
        {
            get { return _selectedFilterIndex; }
            set { _selectedFilterIndex = value; OnPropertyChanged(nameof(SelectedFilterIndex)); }
        }
        //DataContext For advanced Search
        public StaffAdvancedSearch CurrentAdvancedSearch { get; set; }
        // Constructor

        public void UpdateListStaff(List<Staff> results)
        {
            this.Staffs.Clear();
            foreach(Staff s in results)
            {
                Staffs.Add(s);
            }
        }

        public static async Task<ManagingViewModel> Initialize()
        {
            ManagingViewModel viewmodel = new ManagingViewModel();
            await viewmodel.InitializeAsync();
            return viewmodel;
        }
        private async Task InitializeAsync()
        {
            DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            List<Staff> stf = await db.ReadAllAsync();
            this.Staffs = new ObservableCollection<Staff>(stf);
            this.CurrentAdvancedSearch = new StaffAdvancedSearch(this);
        }
        private async void Search()
        {
            await Task.Run(() =>
            {
                DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                string searchInput = SearchString.Trim();
                List<Staff> results = new List<Staff>();
                switch(_selectedFilterIndex)
                {
                    case 0:
                        {
                            FilterDefinition<Staff> filter = Builders<Staff>.Filter.Where(
                                s => s.Fullname.ToLower().Trim().Contains(searchInput)
                                && s.AccessRight.Equals("Staff"));
                            break;

                        }
                    case 1:
                        {
                            FilterDefinition<Staff> filter = Builders<Staff>.Filter.Where(
                                s => s.Fullname.ToLower().Trim().Contains(searchInput)
                                && s.AccessRight.Equals("Admin"));
                            break;
                        }
                    default:
                        return;
                }
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Staffs.Clear();
                    foreach(Staff s in results)
                    {
                        Staffs.Add(s);
                    }
                });
            });
        }


    }
}
