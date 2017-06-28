using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrickCheckerSolutions.ViewModel;

namespace PrickCheckerSolutions.Models
{
    public class PriceDifferenceCalculation
    {
        public vm_PriceDifference CalculatePriceDifference(double price, double daprice, int daid, string daname)
        {
            if (price == null || string.IsNullOrEmpty(price.ToString()) || daprice == null || string.IsNullOrWhiteSpace(daprice.ToString()) || daid <= -1 || string.IsNullOrEmpty(daid.ToString()) || string.IsNullOrEmpty(daname))
            {
                return null;
            }
            else
            {
                double _outDouble;
                int _outInt;
                if(double.TryParse(price.ToString(), out _outDouble) == false || double.TryParse(daprice.ToString(), out _outDouble) == false || int.TryParse(daid.ToString(), out _outInt) == false)
                {
                    return null;
                }
                else
                {
                    //valid price and da (difference against) price, proceed
                    //formula for price difference calculation
                    //=((P-DA)/((P+DA)/2))*100, WHERE => P = price, DA = daprice
                    var pd = new vm_PriceDifference
                    {
                        dashopid = daid,
                        dashopname = daname,
                        daprice = daprice,
                        difference = (double)price-daprice,
                        diffpercent = (double)((price - daprice)/((price + daprice)/2))*100,
                    };

                    if (pd.difference >= 0.01)
                    {
                        //differnce is greater than 0.01, 
                        pd.isincreased = true;
                    }
                    else
                    {
                        pd.isincreased = false;
                    }

                    return pd;
                }
            }
        }
    }
}