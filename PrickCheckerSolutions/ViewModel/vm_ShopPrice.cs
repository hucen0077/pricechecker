using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_ShopPrice
    {
        public int id { get; set; } //id of the price entry

        public int productid { get; set; } //the product id to which the price belongs

        public int shopid { get; set; } //shop id to which the product price belongs to

        public string shopname { get; set; } //shop name to which the product price belongs to

        public double price { get; set; } //the price of the product for this shop

        public List<vm_PriceDifference> comparison { get; set; } //the comparison of this price with other related prices

        public DateTime lastpriceupdatedon { get; set; } //date on which the price was last updated

    }
}