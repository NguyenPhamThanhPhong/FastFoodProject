using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FastFoodUpgrade.ViewModels
{
    public class ManagingViewModel : ViewModelBase
    {
        // Listview ItemSource
        private ObservableCollection<Staff> _staffs;
        public ObservableCollection<Staff> staffs
        {
            get { return _staffs; }
            set { _staffs = value; OnPropertyChanged(nameof(staffs)); }
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
        // Constructor
        public ManagingViewModel()
        {
            //List<Staff> stfs = new fastfooddtbEntities().Staffs.ToList();
            //_staffs = new ObservableCollection<Staff>(stfs);
        }
        private void Search()
        {
//            List<Staff> result;
//            if (!String.IsNullOrEmpty(SearchString))
//            {
//                using (fastfooddtbEntities db = new fastfooddtbEntities())
//                {
//                    result = db.Staffs
//.Where(s => s.fullname.ToLower().Contains(SearchString.ToLower()))
//.ToList();
//                }
//                staffs.Clear();
//                foreach (Staff s in result)
//                {
//                    staffs.Add(s);
//                }
//            }

        }


    }
}
