using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrickCheckerSolutions.Data;
using System.Threading.Tasks;
using PrickCheckerSolutions.Infrastructure;

namespace PrickCheckerSolutions.Areas.Administration.Models
{
    public class avm_Roles
    {
        private pricecheckerEntities _db = new pricecheckerEntities(); //db connection
        private in_SysMsg _msg = new in_SysMsg(); //system message fetching

        public string _roleid { get; set; } //role id, required
        public string _rolename { get; set; } //role name, optional
        public string userid { get; set; } //user id, optional

        //initiate roles
        public avm_Roles()
        {

        }

        /// <summary>
        /// initiate roles with id   
        /// </summary>
        /// <param name="id"></param>
        public avm_Roles(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || (int)name.Length <= 0)
                {
                    _roleid = string.Empty;
                    _rolename = string.Empty;
                }
                else
                {
                    var role = _db.AspNetRoles.Where(x => x.Name.ToLower().Equals(name.ToLower(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    if (role == null)
                    {
                        _roleid = string.Empty;
                        _rolename = string.Empty;
                    }
                    else
                    {
                        _roleid = role.Id;
                        _rolename = role.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                _roleid = string.Empty;
                _rolename = string.Empty;
            }
        }    

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Roles>> GetRolesAsync(string id)
        {
            try
            {
                if(string.IsNullOrEmpty(id) || (int)id.Length <= 0)
                {
                    var _job = Task.Run(() => _db.AspNetRoles.Select(x => new Roles { id = x.Id, name = x.Name }).ToList());

                    var list = await _job;

                    if (list == null || (int)list.Count <= 0)
                    {
                        //there are no roles currently
                        return new List<Roles>();
                    }
                    else
                    {
                        //have roles, return them
                        return list;
                    }
                }
                else
                {
                    var _job = Task.Run(() => _db.AspNetRoles.Where(x => x.Id.ToLower().Contains(id.ToLower())).Select(x => new Roles { id = x.Id, name = x.Name }).ToList());

                    var list = await _job;

                    if (list == null || (int)list.Count <= 0)
                    {
                        //there are no roles currently
                        return new List<Roles>();
                    }
                    else
                    {
                        //have roles, return them
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Roles> GetRoles(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || (int)id.Length <= 0)
                {
                    var list = _db.AspNetRoles.Select(x => new Roles { id = x.Id, name = x.Name }).ToList();
                    
                    if (list == null || (int)list.Count <= 0)
                    {
                        //there are no roles currently
                        return new List<Roles>();
                    }
                    else
                    {
                        //have roles, return them
                        return list;
                    }
                }
                else
                {
                    var list = _db.AspNetRoles.Where(x => x.Id.ToLower().Contains(id.ToLower())).Select(x => new Roles { id = x.Id, name = x.Name }).ToList();
                    
                    if (list == null || (int)list.Count <= 0)
                    {
                        //there are no roles currently
                        return new List<Roles>();
                    }
                    else
                    {
                        //have roles, return them
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<in_Status> CreateRoleAsync(string rolename)
        {
           try
            {
                if (string.IsNullOrEmpty(rolename) || (int)rolename.Length <= 0)
                {
                    return new in_Status { statuscode = 400, message = "Invalid Parameters", status = false, extra = string.Empty };
                }
                else
                {
                    //valid
                    var role = _db.AspNetRoles.Create();
                    role.Name = rolename;
                    role.Id = Guid.NewGuid().ToString();

                    _db.AspNetRoles.Add(role);

                    int stat = await _db.SaveChangesAsync();

                    if (stat <= 0)
                    {
                        return new in_Status { statuscode = 500, message = _msg.GetSystemMessage("Roles.Create.Failure").message, extra = string.Empty, status = false };
                    }
                    else
                    {
                        return new in_Status { statuscode = 201, message = _msg.GetSystemMessage("Roles.Create.Success").message, extra = string.Empty, status = true };
                    }
                }
            }
            catch (Exception ex)
            {
                return new in_Status { statuscode = 500, message = ex.Message, extra = ex.Source, status = false };
            }
        }


        /// <summary>
        /// Get role by name async method
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Roles> GetRoleAsync(string name)
        {
            try
            {
                if(name == null || string.IsNullOrEmpty(name.ToString()) || (int)name.Length <= 0)
                {
                    return null;
                }
                else
                {
                    var _job = Task.Run(() => _db.AspNetRoles.Where(x => x.Name.ToLower().Equals(name.ToLower(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault());
                    var role = await _job;

                    if(role == null)
                    {
                        return null;
                    }
                    else
                    {
                        return new Roles { id = role.Id, name = role.Name };
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Get role by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Roles GetRole(string name)
        {
            try
            {
                if (name == null || string.IsNullOrEmpty(name.ToString()) || (int)name.Length <= 0)
                {
                    return null;
                }
                else
                {
                    var role = _db.AspNetRoles.Where(x => x.Name.ToLower().Equals(name.ToLower(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    
                    if (role == null)
                    {
                        return null;
                    }
                    else
                    {
                        return new Roles { id = role.Id, name = role.Name };
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Edit role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<in_Status> EditRoleAsync(Roles model)
        {
            try
            {
                if(model == null)
                {
                    return new in_Status { status = false, statuscode = 400, extra = string.Empty, message = "Invalid parameters" };
                }
                else
                {
                    var role = _db.AspNetRoles.Where(x => x.Id.ToLower().Equals(model.id.ToLower(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    if (role == null)
                    {
                        return new in_Status { status = false, extra = string.Empty, message = "Could not locate role", statuscode = 404 };
                    }
                    else
                    {
                        if (role.Name.ToLower().Equals("super admin", StringComparison.CurrentCultureIgnoreCase))
                        {
                            return new in_Status { statuscode = 403, message = "Cannot delete super admin role", extra = string.Empty, status = false };
                        }
                        else
                        {

                            role.Name = model.name;

                            int stat = await _db.SaveChangesAsync();

                            if (stat <= 0)
                            {
                                return new in_Status { statuscode = 500, message = _msg.GetSystemMessage("Roles.Edit.Failure").message, extra = string.Empty, status = false };
                            }
                            else
                            {
                                return new in_Status { statuscode = 201, message = _msg.GetSystemMessage("Roles.Edit.Success").message, extra = string.Empty, status = true };
                            }
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                return new in_Status { statuscode = 500, message = ex.Message, extra = ex.Source, status = false };
            }
        }

        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<in_Status> DeleteRoleAsync(Roles model)
        {
            try
            {
                if (model == null)
                {
                    return new in_Status { status = false, statuscode = 400, extra = string.Empty, message = "Invalid parameters" };
                }
                else
                {
                    var role = _db.AspNetRoles.Where(x => x.Id.ToLower().Equals(model.id.ToLower(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    if (role == null)
                    {
                        return new in_Status { status = false, extra = string.Empty, message = "Could not locate role", statuscode = 404 };
                    }
                    else
                    {
                        //check count of users in role
                        //role can only be deleted if users are 0
                        //also super admin role cannot be deleted

                        if (role.Name.ToLower().Equals("super admin", StringComparison.CurrentCultureIgnoreCase))
                        {
                            return new in_Status { statuscode = 403, message = "Cannot delete super admin role", extra = string.Empty, status = false };
                        }
                        else
                        {
                            if((int)role.AspNetUsers.Count >= 1)
                            {
                                return new in_Status { statuscode = 403, message = "Remove all users from role " + model.name + " to delete this role", extra = string.Empty, status = false };
                            }
                            else
                            {
                                _db.AspNetRoles.Remove(role);

                                int stat = await _db.SaveChangesAsync();

                                if (stat <= 0)
                                {
                                    return new in_Status { statuscode = 500, message = _msg.GetSystemMessage("Roles.Edit.Failure").message, extra = string.Empty, status = false };
                                }
                                else
                                {
                                    return new in_Status { statuscode = 201, message = _msg.GetSystemMessage("Roles.Delete.Success").message, extra = string.Empty, status = true };
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return new in_Status { statuscode = 500, message = ex.Message, extra = ex.Source, status = false };
            }
        }
    }

    public class Roles
    {
        public string id { get; set; } //id of the role
        public string name { get; set; } //name of the role
    }

}