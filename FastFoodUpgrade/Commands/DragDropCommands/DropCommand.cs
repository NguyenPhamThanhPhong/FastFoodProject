using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.DragDropCommands
{
    public class DropCommand : CommandBase
    {
        ProductViewModel pvm;
        public DropCommand(ProductViewModel pvm) 
        {
            this.pvm = pvm;
        }
        public override void Execute(object parameter)
        {
            if(pvm.SelectedItem!= null) 
            {
                DragEventArgs e = parameter as DragEventArgs;
                if(e!=null && e.Data!=null) 
                {
                    Product p = pvm.SelectedItem;
                    Order o = new Order() {Productname = p.ProductName, price = p.Price };
                    pvm.Odrs.Add(o);
                    pvm.SelectedItem= null;
                }
            }
        }
    }
}
