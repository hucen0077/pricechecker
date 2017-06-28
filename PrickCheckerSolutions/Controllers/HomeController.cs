using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrickCheckerSolutions.ViewModel;
using System.Threading.Tasks;
using PrickCheckerSolutions.Data;

namespace PrickCheckerSolutions.Controllers
{
    public class HomeController : Controller
    {
        private int pgcount = 10;
        private AdventureWorks2008R2Entities _db = new AdventureWorks2008R2Entities(); // sample db

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


     

     
        /// <summary>
        /// Search method
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        //public async Task<ActionResult> Search(string q, int? page)
        //{
        //    int _remove = 0;
        //    int totcount = 0;

        //    if ((bool)page.HasValue == false)
        //    {
        //        //page not provided
        //        page = 1;
        //        _remove = 0;
        //    }
        //    else
        //    {
        //        //page provided
        //        page = (int)page.Value;
        //        _remove = ((int)page.Value - 1) * pgcount;
        //    }

        //    try
        //    {
        //        if (string.IsNullOrEmpty(q) || (int)q.Length <= 0)
        //        {
        //            //no search term provided
        //            var results = new dummyData(1).dummySearchResult();

        //            if (results == null || (int)results.Count <= 0)
        //            {
        //                return PartialView("_SearchResults", new vm_SearchResults());
        //            }
        //            else
        //            {
        //                totcount = results.Count;
        //                //have results
        //                //check if 1st page or not
        //                if (page == 1)
        //                {
        //                    //first page, only 1st page items as per pgcount
        //                    results = results.Take(pgcount).ToList();

        //                }
        //                else
        //                {
        //                    //not first page
        //                    //1- remove previous page amounts from results
        //                    //2- then take pgcount of results
        //                    results.RemoveRange(0, _remove);
        //                    results = results.Take(pgcount).ToList();
        //                }

        //                return PartialView("_SearchResults", new vm_SearchResults { currentpage = page.Value, results = results, totalcount = totcount });
        //            }
        //        }
        //        else
        //        {
        //            //search term provided
        //            var results = new dummyData(1).dummySearchResult(q);

        //            if (results == null || (int)results.Count() <= 0)
        //            {
        //                return Json("false", "application/json", JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                totcount = results.Count();

        //                //check if 1st page or not
        //                if (page == 1)
        //                {
        //                    //first page, only 1st page items as per pgcount
        //                    results = results.Take(pgcount).ToList();

        //                }
        //                else
        //                {
        //                    //not first page
        //                    //1- remove previous page amounts from results
        //                    //2- then take pgcount of results
        //                    results.RemoveRange(0, _remove);
        //                    results = results.Take(pgcount).ToList();
        //                }
                        
        //                return PartialView("_SearchResults", new vm_SearchResults { currentpage = page.Value, results = results, totalcount = totcount });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}