using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_FileModel
    {
        public string filename { get; set; } //name of the file

        public string contenttype { get; set; } //type or extension of the file

        public string contentcoding { get; set; } // content coding of file

        public long contentlength { get; set; } //length of the file

        public Stream content { get; set; } //the actual content of the file 
    }
    
}