using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrickCheckerSolutions.Areas.Administration.Models;
using System.Threading.Tasks;
using System.Net;

namespace PrickCheckerSolutions.Areas.Administration.Controllers
{
    public class RoleController : Controller
    {
        private avm_Roles _roles; //roles class

        // GET: Administration/Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult getRolesPartial()
        {
            _roles = new avm_Roles();
            var model = _roles.GetRoles(string.Empty);
            return PartialView("_AllRoles", model);
        }

        // GET: Administration/Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Role/Create
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_CreateRolePartial",  new Roles());
        }

        // POST: Administration/Role/Create
        [HttpPost]
        public async Task<ActionResult> Create(Roles model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _roles = new avm_Roles();
                    var _results = await _roles.CreateRoleAsync(model.name);
                    return new HttpStatusCodeResult(_results.statuscode, _results.message);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid parameters");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: Administration/Role/Edit/5
        public ActionResult Edit(string name)
        {
            try
            {
                if(string.IsNullOrEmpty(name) || (int)name.Length <= 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    _roles = new avm_Roles();
                    var model = _roles.GetRole(name);

                    if (model == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return PartialView("_EditRolePartial", model);
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Administration/Role/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Roles model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roles = new avm_Roles();
                    var _results = await _roles.EditRoleAsync(model);
                    return new HttpStatusCodeResult(_results.statuscode, _results.message);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid parameters");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: Administration/Role/Delete/5
        public ActionResult Delete(string name)
        {

            try
            {
                if (string.IsNullOrEmpty(name) || (int)name.Length <= 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    _roles = new avm_Roles();
                    var model = _roles.GetRole(name);

                    if (model == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return PartialView("_DeleteRolePartial", model);
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Administration/Role/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Roles model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roles = new avm_Roles();
                    var _results = await _roles.DeleteRoleAsync(model);
                    return new HttpStatusCodeResult(_results.statuscode, _results.message);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid parameters");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
