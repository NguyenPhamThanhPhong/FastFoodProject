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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views.ListViews
{
    /// <summary>
    /// Interaction logic for DrawerListView.xaml
    /// </summary>
    public partial class DrawerListView : UserControl
    {
        public DrawerListView()
        {
            InitializeComponent();
        }
        public ICommand DropCommand
        {
            get { return (ICommand)GetValue(DropCommandProperty); }
            set { SetValue(DropCommandProperty, value); }
        }

        public static readonly DependencyProperty DropCommandProperty =
            DependencyProperty.Register("DropCommand", typeof(ICommand), typeof(DrawerListView), new PropertyMetadata(null));
        private void ListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if(DropCommand!=null) 
            { 
                DropCommand.Execute(e);
            }
        }
    }
}
