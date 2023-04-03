using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FastFoodUpgrade.Commands.DragDropCommands
{
    public class MouseDownDrag : CommandBase
    {
        ProductViewModel pvm;
        public MouseDownDrag(ProductViewModel pvm)
        {
            this.pvm = pvm;
        }
        public override void Execute(object parameter)
        {
            var grid = parameter as Grid;
            pvm.SelectedItem = grid.DataContext as Product;
            if (pvm.SelectedItem != null)
            {
                DragDrop.DoDragDrop(grid, pvm.SelectedItem, DragDropEffects.Copy);
            }
        }
    }
}
