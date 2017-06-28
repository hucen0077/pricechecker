using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_Product
    {
        public int id { get; set; } //id of the product

        public string name { get; set; } //name of the product

        public string brand { get; set; } //brand of the product

        public string category { get; set; } //category of the product

        public string code { get; set; } //unique code (barcode) of the product

        public string description { get; set; } //short description of the product

        public List<vm_ProductImage> images { get; set; } //list of all images associated with this product

        public DateTime lastupdatedon { get; set; } //date on which the product details were last updated on

        public List<string> tags { get; set; } //tags associated with this product

        public List<vm_ShopPrice> prices { get; set; } //prices from different shops
    }
}