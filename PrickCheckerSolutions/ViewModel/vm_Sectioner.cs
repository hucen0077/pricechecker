using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_Sectioner
    {
        public int id { get; set; } //id of the section
        public Guid guid { get; set; } //guid of the section
        public string sectioncolor { get; set; } //section color
        public string heading { get; set; } //heading of the section
        public string htmlcontent { get; set; } //html content to show
        public string htmlcontentclasses { get; set; } //html content styles
        public string headingclasses { get; set; } //heading styles
        public bool isstatic { get; set; } //is static load or dynamic load
        public string functiontoload { get; set; } //function to load additional html data
        public List<FunctionParameterValue> parameters { get; set; } //parameters needed to additional functional load

        public string contentstyles { get; set; }//styles to apply to loaded content
    }

    public class FunctionParameterValue
    {
        public string parameter { get; set; } //name of the parameter

        public string value { get; set; } //value of the parameter
    }
}