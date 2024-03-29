﻿using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FastFoodUpgrade.Commands.AdvancedSearchCommand
{
    public class ProductAdvancedSearchCommand : AsyncCommandBase
    {
        private ProductAdvancedSearch currentAdvancedSearch;
        public ProductAdvancedSearchCommand(ProductAdvancedSearch productAdvancedSearch) 
        {
            currentAdvancedSearch = productAdvancedSearch;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await Task.Run(() => {
                    string SearchName = currentAdvancedSearch.SearchName;
                    int SearchTypeIndex = currentAdvancedSearch.SearchTypeIndex;
                    int priceFrom = currentAdvancedSearch.PriceFrom;
                    int priceTo = currentAdvancedSearch.PriceTo;
                    int RemainingQuantity = currentAdvancedSearch.RemainingQuantity;
                    float discountFrom = currentAdvancedSearch.DiscountAmountFrom;
                    float discountTo = currentAdvancedSearch.DiscountAmountTo;
                    List<String> AllProductTypes = currentAdvancedSearch.pvm.Types.ToList();
                    FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(SearchName, "i"))
                        & Builders<Product>.Filter.Regex("Type", new BsonRegularExpression(AllProductTypes[SearchTypeIndex], "i"))
                        & Builders<Product>.Filter.Gt("Price", priceFrom)
                        & Builders<Product>.Filter.Lt("Price", priceTo)
                        & Builders<Product>.Filter.Lt("Remain", RemainingQuantity)
                        & Builders<Product>.Filter.Gt(p => p.DiscountAmount.Value, discountFrom)
                        & Builders<Product>.Filter.Lt(p => p.DiscountAmount.Value, discountTo);
                    //                FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression("rek", "i"))
                    //& Builders<Product>.Filter.Regex("Type", new BsonRegularExpression("drinks", "i"))
                    //& Builders<Product>.Filter.Gt("Price", 0)
                    //& Builders<Product>.Filter.Lt("Price", 110000)
                    //& Builders<Product>.Filter.Lt("Remain", 500)
                    //& Builders<Product>.Filter.Gt(p => p.DiscountAmount.Value, 0)
                    //& Builders<Product>.Filter.Lt(p => p.DiscountAmount.Value, 100000000);
                    DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
                    List<Product> results = db.ReadFiltered(filter);
                    Application.Current.Dispatcher.Invoke(() => {
                        currentAdvancedSearch.pvm.UpdateListViewResult(results);
                    });
                    
                });


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
