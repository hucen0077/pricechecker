using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrickCheckerSolutions.Data;
using System.Threading.Tasks;

namespace PrickCheckerSolutions.Controllers
{
    public class MediaController : Controller
    {
        private AdventureWorks2008R2Entities _db = new AdventureWorks2008R2Entities(); // sample db


        /// <summary>
        /// Retrieve and show image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ShowImageThumbnail(int id)
        {
            if(string.IsNullOrEmpty(Convert.ToString(id)))
            {
                return Content(Url.Content(string.Format("~/Images/Placeholder/{0}", "imageplaceholder.png")), "text/plain");
            }
            else
            {
                var imagefetch = Task.Run(() => _db.ProductPhotoes.Where(x => x.ProductPhotoID == id).FirstOrDefault());

                var image = await imagefetch;

                if(image == null)
                {
                    return Content(Url.Content(string.Format("~/Images/Placeholder/{0}", "imageplaceholder.png")), "text/plain");
                }
                else
                {
                    return File(image.ThumbNailPhoto, "image/jpg");
                }
            }
        }


        /// <summary>
        /// Retrieve and show image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ShowImageLarge(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(id)))
            {
                return Content(Url.Content(string.Format("~/Images/Placeholder/{0}", "imageplaceholder.png")), "text/plain");
            }
            else
            {
                var imagefetch = Task.Run(() => _db.ProductPhotoes.Where(x => x.ProductPhotoID == id).FirstOrDefault());

                var image = await imagefetch;

                if (image == null)
                {
                    return Content(Url.Content(string.Format("~/Images/Placeholder/{0}", "imageplaceholder.png")), "text/plain");
                }
                else
                {
                    return File(image.LargePhoto, "image/jpg");
                }
            }
        }


    }
}