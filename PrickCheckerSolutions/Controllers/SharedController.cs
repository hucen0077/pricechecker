using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System;

namespace PrickCheckerSolutions.Controllers
{
    public class SharedController : Controller
    {
        const string _staticpath = "~/Static/";

        /// <summary>
        /// Get an advertisement by its ID
        /// </summary>
        /// <param name="ghxcu">id of the advertisement to return</param>
        /// <returns>If successful, a partial view would be returned, if any error occurs HTTP error code will be thrown</returns>
        public async Task<ActionResult> JHHACOXTWD(int ghxcu)
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Get Section Contents from database or dynamic source
        /// </summary>
        /// <param name="wqbvr">id of the section content to return</param>
        /// <returns>If successful, partial view is returned, if any error occurs HTTP error code will be thrown</returns>
        public async Task<ActionResult> ABCMGMOVBV(int wqbvr)
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Get Section Contents from static files
        /// </summary>
        /// <param name="kxtvb">name of the static file to return</param>
        /// <returns>If successful, partial view is returned, if any error occurs HTTP error code will be thrown</returns>
        public async Task<ActionResult> PVWEKSDEDJ(string kxtvb)
        {
            try
            {
                if (string.IsNullOrEmpty(kxtvb) || (int)kxtvb.Length <= 0)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    string _file = Server.MapPath(string.Format("{0}{1}", _staticpath, kxtvb));

                    if (!System.IO.File.Exists(_file))
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                    }
                    else
                    {
                        var _executor = Task.Run(() => System.IO.File.ReadAllText(_file));

                        string _content = await _executor;

                        if (_executor.IsCompleted)
                        {
                            if (string.IsNullOrEmpty(_content) || (int)_content.Length <= 0)
                            {
                                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                            }
                            else
                            {
                                return PartialView("_PlainHtmlContent", (string)_content);
                            }
                        }
                        else
                        {
                            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
                        
        }




    }
}