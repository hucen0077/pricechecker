using PrickCheckerSolutions.Data;
using PrickCheckerSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrickCheckerSolutions.Controllers
{
    public class SearchController : Controller
    {
        private int pgcount = 10;
        private AdventureWorks2008R2Entities _db = new AdventureWorks2008R2Entities(); // sample db
        
        // GET: Search
        public ActionResult Index()
        {
            if (Request.QueryString["q"] != null)
            {
                if (!string.IsNullOrEmpty((string)Request.QueryString["q"]))
                {
                    if ((int)Request.QueryString["q"].ToString().Length <= 0)
                    {
                        ViewBag.SearchTerm = "";
                    }
                    else
                    {
                        ViewBag.SearchTerm = Request.QueryString["q"].ToString();
                    }
                }
                else
                {
                    ViewBag.SearchTerm = "";
                }
            }
            else
            {
                ViewBag.SearchTerm = "";
            }

            ViewBag.CurrentBlock = 1;
            return View();
        }


        /// <summary>
        /// Task for
        /// </summary>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> _GetSearchResults(string q, int? page)
        {
            var model = new List<vm_ProductItemSearchResult>();
            if (!string.IsNullOrEmpty(q))
            {
                ViewBag.SearchTerm = q;
                model = await Task.Run(() => new dummyData(1).dummySearchResult(q));
            }
            else
            {
                ViewBag.SearchTerm = string.Empty;
                model = await Task.Run(() => new dummyData(1).dummySearchResult());
            }

            if (model == null || (int)model.Count <= 0)
            {
                return PartialView("_noresults");
            }
            else
            {
                //check if all possible blocks displayed
                int _maxblocks = 0;
                if (model.Count <= pgcount)
                {
                    //total results is less than or equal to max page count
                    _maxblocks = 1;
                }
                else
                {
                    //total results are greater than max page count
                    _maxblocks = (model.Count / pgcount) + 1;
                }

                //have results
                //set page
                int _block = 1;
                if ((bool)page.HasValue == false)
                {
                    _block = 1;
                }
                else
                {
                    _block = (int)page.Value;
                }

                //number of maximum records in model to return
                if (_block > _maxblocks)
                {
                    //current result block is greater than possible blocks of results
                    //there should be no more results to be displayed
                    return PartialView("_Empty");
                }
                else
                {
                    //set records to display in block
                    if (_block == 1)
                    {
                        model = model.Take(pgcount).ToList();
                    }
                    else
                    {
                        //not first page, remove initial records
                        model.RemoveRange(0, (pgcount * (_block - 1)));
                        model = model.Take(pgcount).ToList();
                    }

                    //set block in viewbag
                    ViewBag.CurrentBlock = _block;

                    return PartialView("_ProductGrid", model);
                }


            }
        }



    }
}