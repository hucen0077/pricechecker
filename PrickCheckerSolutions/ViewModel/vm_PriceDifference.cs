using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrickCheckerSolutions.ViewModel
{
    public class vm_PriceDifference
    {
        public int dashopid { get; set; } //id of the shop to which the da price belongs to

        public string dashopname { get; set; } //name of the shop to which the da price belongs to 

        public double daprice { get; set; } //difference against price that should be compared with

        public double difference { get; set; } //difference between price and da price

        public double diffpercent { get; set; } //difference percentage of da against price

        public bool isincreased { get; set; } //indication whether price difference is increased or decreased
                
    }
}