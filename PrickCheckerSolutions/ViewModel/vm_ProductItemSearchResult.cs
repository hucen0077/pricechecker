using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_ProductItemSearchResult
    {
        public int id { get; set; } //id of the product

        public string name { get; set; } //name of the product

        public int imgid { get; set; } //id of the image

        //public vm_ProductImage image { get; set; } //single image of the product
    }
}