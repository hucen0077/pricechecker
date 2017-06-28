using PrickCheckerSolutions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrickCheckerSolutions.Areas.Administration.Controllers
{
    public class SystemMessageController : Controller
    {
        private in_SysMsg _sm = new in_SysMsg(); //private system message

        // GET: Administration/SystemMessage
        public async Task<ActionResult> Index()
        {
            return View();
        }

        //GET: List of System Message
        public PartialViewResult _GetList(string srch)
        {
            var model = _sm.GetAllSystemMessages(srch ?? string.Empty);
            return PartialView("_SystemMessageList", model);
        }

        // GET: Administration/SystemMessage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/SystemMessage/Create
        public ActionResult Create()
        {
            return View(new Sysmsg());
        }

        // POST: Administration/SystemMessage/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sysmsg model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid parameters provided");
                }
                else
                {
                    var _result = await _sm.CreateSystemMessageAsync(model, new RecordMeta { name = User.Identity.Name ?? "System", atdate = DateTime.Now });
                    return new HttpStatusCodeResult(_result.statuscode, _result.message);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: Administration/SystemMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/SystemMessage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/SystemMessage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/SystemMessage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
