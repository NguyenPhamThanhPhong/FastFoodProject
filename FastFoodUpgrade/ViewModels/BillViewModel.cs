using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FastFoodUpgrade.ViewModels
{
    public class BillViewModel : ViewModelBase
    {
        private ObservableCollection<Bill> _bills = new ObservableCollection<Bill>();
        public ObservableCollection<Bill> Bills
        { 
            get { return _bills; }
            set { _bills = value; OnPropertyChanged(nameof(Bills)); }
        }
        //Search string in textbox
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
            set { _selectedFilterIndex = value; Search(); OnPropertyChanged(nameof(SelectedFilterIndex)); }
        }
        private void Search()
        {
            List<Bill> results = new List<Bill>();
            if(!String.IsNullOrEmpty(SearchString))
            {
                //using(fastfooddtbEntities db = new fastfooddtbEntities())
                //{
                //    string text = Regex.Replace(SearchString, @"s", "").ToLower();

                //    switch (SelectedFilterIndex)
                //    {
                //        case 0:
                //            db.Bills.Where(b => b.ToString().Contains(text));
                //            break;
                //        case 1:
                //            results = db.Bills.
                //                Where(b =>
                //                Regex.Replace(b.Customer.fullname, @"s", "").ToLower().Contains(SearchString.ToLower())).ToList();
                //            break;
                //        case 2:
                //            results = db.Bills.Where(b=>b.BillDate.ToString().ToLower().Contains(SearchString.ToLower())).ToList();
                //            break;
                //        case 3:
                //            results = db.Bills.Where(b => b.Total.ToString().ToLower().Contains(SearchString.ToLower())).ToList();
                //            break;
                //        default:

                //            break;
                //    }
                //    Bills.Clear();
                //    foreach(Bill b in results) 
                //    {
                //        Bills.Add(b);
                //    }
                //}
            }
        }

    }
}
