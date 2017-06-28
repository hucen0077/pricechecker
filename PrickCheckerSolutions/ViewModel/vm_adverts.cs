using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_adverts
    {
        public int id { get; set; } //id of the adv

        public string title { get; set; } //title of the adv

        public bool showtitle { get; set; } //indicate whether to show title or not

        public string img { get; set; } //full image with path of the adv
        
        public bool showimage { get; set; } //indicate whether to show image or not

        public string description { get; set; } //description to show on reveal

        public bool showdescription { get; set; } //indicate whether to show or not description

        public string link { get; set; } //link to redirect to

        public bool showlink { get; set; } //indicate whether or not the link is active

        public int adbox { get; set; } //indicate size of the advertisement
    }
}