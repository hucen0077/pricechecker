using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrickCheckerSolutions.Models;
using PrickCheckerSolutions.ViewModel;
using System.Text;
using PrickCheckerSolutions.Data;

namespace PrickCheckerSolutions.ViewModel
{
    public class dummyData
    {
        private AdventureWorks2008R2Entities _db = new AdventureWorks2008R2Entities(); // sample db
        private PriceDifferenceCalculation _calculate = new PriceDifferenceCalculation(); // calculation

        public List<vm_Product> _products { get; set; }
        
        public dummyData(int returnCount)
        {
            //first, generate random number of shops, here its going to be 5
            var _shops = new List<vm_Shops>
            {
                new vm_Shops { id = 1, name = "Supermarket" },
                new vm_Shops { id = 2, name = "Whole Foods" },
                new vm_Shops { id = 3, name = "Acme Company" },
                new vm_Shops { id = 4, name = "Giant" },
                new vm_Shops { id = 5, name = "Farm Fresh" }
            };

            var _list = new List<vm_Product>();

            var _rand = new Random();

            for (int i = 0; i <= returnCount; i++)
            {
                var _prod = new vm_Product
                {
                    id = i,
                    lastupdatedon = DateTime.Now,
                    brand = RandomString(10),
                    category = RandomString(20),
                    name = string.Format("{0} {1} {2}", RandomString(_rand.Next(5, 10)), RandomString(_rand.Next(5, 10)), RandomString(_rand.Next(1, 5))),
                    code = RandomString(_rand.Next(5, 10)),
                    description = LoremIpsum(20, 40, 1, 1, 1),
                    prices = new List<vm_ShopPrice>(),
                    tags = new List<string> { "nike", "shoes", "turf", "football", "sports" },
                    images = new List<vm_ProductImage>
                    {
                        new vm_ProductImage { id = 1, guid = Guid.NewGuid().ToString(), ext = "jpg", filename = "_prod1.jpg", path = string.Empty },
                        new vm_ProductImage { id = 2, guid = Guid.NewGuid().ToString(), ext = "jpg", filename = "_prod2.jpg", path = string.Empty },
                        new vm_ProductImage { id = 3, guid = Guid.NewGuid().ToString(), ext = "jpg", filename = "_prod3.jpg", path = string.Empty },
                        new vm_ProductImage { id = 4, guid = Guid.NewGuid().ToString(), ext = "jpg", filename = "_prod4.jpg", path = string.Empty },
                    }
                };

                //product initialized, add prices, for each
                int idcnt = 1;
                foreach(var item in _shops)
                {
                    //if(_rand.Next(1,10) < 8)
                    //{
                        var _shopprice = new vm_ShopPrice
                        {
                            id = idcnt,
                            lastpriceupdatedon = DateTime.Now,
                            shopid = item.id,
                            productid = _prod.id,
                            shopname = item.name,
                            price = RandomPriceBetween(_rand.NextDouble(), _rand.NextDouble()) + _rand.Next(100, 500),
                            comparison = new List<vm_PriceDifference>()
                        };

                        _prod.prices.Add(_shopprice);
                        idcnt++;
                    //}
                    
                }

                //all prices for shops generated without comparison,
                //run comparison
                foreach(var item in _prod.prices)
                {
                    double _baseprice = item.price; //base price
                    
                    foreach(var remainingprices in _prod.prices)
                    {
                        double _daprice = remainingprices.price; //comparing price
                        var _diff = _calculate.CalculatePriceDifference(_baseprice, _daprice, remainingprices.shopid, remainingprices.shopname);

                        if (_diff != null)
                        {
                            item.comparison.Add(_diff);
                        }
                    }
                }

                _list.Add(_prod);
                
            }

            _products = _list;

        }

        public List<vm_ProductItemSearchResult> dummySearchResult()
        {
            var results = _db.Products.Select(x => new vm_ProductItemSearchResult
            {
                id = x.ProductID,
                name = x.Name,
                imgid = x.ProductProductPhotoes.Where(y => y.ProductID == x.ProductID).FirstOrDefault().ProductPhotoID
            }).ToList();

            if(results == null || (int)results.Count <= 0)
            {
                //no results
                return new List<vm_ProductItemSearchResult>();
            }
            else
            {
                return results;
            }
            
        }

        public List<vm_ProductItemSearchResult> dummySearchResult(string srch)
        {
            var list = _db.Products.Where(x => x.Name.ToLower().Contains(srch.ToLower())).ToList();

            if(list == null || (int)list.Count <= 0)
            {
                //no results
                return new List<vm_ProductItemSearchResult>();
            }
            else
            {

                var results = list.Select(x => new vm_ProductItemSearchResult
                {
                    id = x.ProductID,
                    name = x.Name,
                    imgid = x.ProductProductPhotoes.Where(y => y.ProductID == x.ProductID).FirstOrDefault().ProductPhotoID
                }).ToList();

                return results;
            }
            
        }

        

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789 abcdefghijklmnopqrstuvwxyz ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
            }

            return result.ToString();
        }

        private static double RandomPriceBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        private static string randomName(int num)
        {
            if(num > 7)
            {
                return "test";
            }
            else if(num < 7 && num > 4)
            {
                return "shoes";
            }
            else
            {
                return "sport";
            }
        }
    }
}