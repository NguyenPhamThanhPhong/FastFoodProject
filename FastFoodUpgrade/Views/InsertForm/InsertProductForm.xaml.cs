using FastFoodUpgrade.Models;
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
using System.Windows.Shapes;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;

namespace FastFoodUpgrade.Views.InsertForm
{
    /// <summary>
    /// Interaction logic for InsertProductForm.xaml
    /// </summary>
    public partial class InsertProductForm : Window
    {
        public InsertProductForm()
        {
            InitializeComponent();
            InsertProductViewModel datacontext = new InsertProductViewModel();
            this.DataContext = datacontext;
            this.InsertCommand= datacontext.InsertCommand;
        }
        private ICommand InsertCommand;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Product p = new Product();
            //p.Name = productname.Text.Trim();
            //p.Type= producttype.Text.Trim();
            //p.Remain = int.Parse(Remain.Text.Trim());
            //p.Price = int.Parse(productprice.Text.Trim());
            //p.DiscountAmount = new Discount() { Value = float.Parse(Amount.Text.Trim()),StartDate=DateTime.Today, EndDate= DateTime.Now };
            //p.Description = description.Text;
            //DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            //db.Insert(p);
            if(InsertCommand!= null) 
            {
                InsertCommand.Execute(null);
            }
        }
    }
}
