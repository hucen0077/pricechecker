using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_SearchResults
    {
        public int totalcount { get; set; } //total results count of the search

        public int currentpage { get; set; } //current page of the search results

        public List<vm_ProductItemSearchResult> results { get; set; } //results
    }
}