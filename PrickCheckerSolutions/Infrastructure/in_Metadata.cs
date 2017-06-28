using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.Infrastructure
{
    public class in_Metadata
    {
        public RecordMeta creation { get; set; }

        public RecordMeta modification { get; set; }

        public RecordMeta deletion { get; set; }
    }


    /// <summary>
    /// Meta class object that hold record metadata
    /// </summary>
    public class RecordMeta
    {
        public string name { get; set; } // created, modified, deleted user
        public DateTime atdate { get; set; } //created, modified, deleted date time
    }
}