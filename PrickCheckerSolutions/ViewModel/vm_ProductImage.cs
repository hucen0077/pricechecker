using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_ProductImage
    {
        public int id { get; set; } //id of the image

        public string guid { get; set; } //guid of the image

        public string path { get; set; } //path of the image

        public string ext { get; set; } //ext of the image

        public string filename { get; set; } //file name of the image
    }
}