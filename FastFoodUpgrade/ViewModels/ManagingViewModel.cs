using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.ViewModels
{
    public class ManagingViewModel : ViewModelBase
    {
        private ObservableCollection<Staff> _staffs;
        public ObservableCollection<Staff> staffs
        {
            get { return _staffs; }
            set { _staffs = value; OnPropertyChanged(nameof(staffs)); }
        }
        public ManagingViewModel()
        {
            List<Staff> stfs = new fastfooddtbEntities().Staffs.ToList();
            _staffs = new ObservableCollection<Staff>(stfs);
        }
    }
}
