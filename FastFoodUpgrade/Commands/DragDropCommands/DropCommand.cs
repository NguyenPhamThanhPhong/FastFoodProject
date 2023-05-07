using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.DragDropCommands
{
    public class DropCommand : CommandBase
    {

        ObservableCollection<Order> PurchaseList;
        public DropCommand(ObservableCollection<Order> odrs) 
        {
            this.PurchaseList = odrs;
        }
        public override void Execute(object parameter)
        {
            DragEventArgs e = parameter as DragEventArgs;
            var product = e.Data.GetData(typeof(Product)) as Product;

            if (product != null) 
            {
                Product p = product;
                for(int i=0;i<PurchaseList.Count;i++) 
                {
                    Order item = PurchaseList[i];
                    if (item.Merchandise.Name.Equals(p.Name))
                    {
                        item.SellAmount++;
                        if(item.DiscountAmount!=null)
                            item.Total += (int)(p.Price * (1 - item.DiscountAmount.Value));
                        else
                            item.Total += p.Price;
                        Order oo = item;
                        PurchaseList.RemoveAt(i); // Remove the old item
                        PurchaseList.Insert(i, oo); // Insert the new item at the same index
                        return;
                    }
                }

                Order o = new Order()
                {
                    Merchandise = p,
                    SellAmount = 1,
                    DiscountAmount = p.DiscountAmount,
                    Total = p.Price * 1
                };
                PurchaseList.Add(o);
                //pvm.Odrs.Add(o);
                //pvm.SelectedItem = null;
            }
        }
    }
}
