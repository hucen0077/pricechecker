using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.Infrastructure
{
    public class in_Status
    {
        public int statuscode { get; set; }//status code of execution
        public string message { get; set; }//message to be displayed
        public bool status { get; set; }//overall status of execution
        public string extra { get; set; }//additional paramters
    }
}