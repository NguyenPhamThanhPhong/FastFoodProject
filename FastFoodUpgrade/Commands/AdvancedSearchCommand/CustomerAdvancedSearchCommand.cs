using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using FastFoodUpgrade.Views.SplitTaskTable;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FastFoodUpgrade.Commands.AdvancedSearchCommand
{
    public class CustomerAdvancedSearchCommand : AsyncCommandBase
    {
        private CustomerAdvancedSearch vm;
        public CustomerAdvancedSearchCommand(CustomerAdvancedSearch current) 
        { 
            this.vm = current;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await Task.Run(() =>
                {

                    string SearchName = vm.CustomerName;
                    string Phone = vm.Phone;
                    string rank = vm.SelectedRank;
                    int From = vm.RevenueFrom;
                    int To = vm.RevenueTo;
                    if (rank == null)
                    {
                        return;
                    }
                    FilterDefinition<Customer> filter =
                    Builders<Customer>.Filter.Regex("Fullname", new BsonRegularExpression(SearchName, "i"))
                    & Builders<Customer>.Filter.Regex("Phone", new BsonRegularExpression(Phone, "i"))
                    & Builders<Customer>.Filter.Regex("Rank", new BsonRegularExpression(rank, "i"))
                    & Builders<Customer>.Filter.Lte(c => c.Total, To)
                    & Builders<Customer>.Filter.Gte(c => c.Total, From);
                    DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
                    List<Customer> results = db.ReadFiltered(filter);
                    Application.Current.Dispatcher.Invoke(() => {
                        vm.cvm.UpdateCustomerList(results);
                    });

                });
            }catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
