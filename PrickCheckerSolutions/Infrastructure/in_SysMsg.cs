using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrickCheckerSolutions.Data;
using System.Threading.Tasks;

namespace PrickCheckerSolutions.Infrastructure
{
    public class in_SysMsg
    {
        private pricecheckerEntities _db = new pricecheckerEntities(); //db connection
        private in_Status _status; //status of execution

        public in_SysMsg()
        {
            //initiator
        }

        /// <summary>
        /// get list of system messages
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Sysmsg>> GetAllSystemMessagesAsync(string srch)
        {
            try
            {
                if (string.IsNullOrEmpty(srch) || (int)srch.Length <= 0)
                {
                    var _job = Task.Run(() => _db.tbl_SystemMessages.Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).ToList());
                    var _result = await _job;

                    if (_result == null)
                    {
                        return new List<Sysmsg>();
                    }
                    else
                    {
                        return _result;
                    }
                }
                else
                {
                    var _job = Task.Run(() => _db.tbl_SystemMessages.Where(x => x.Name.ToLower().Contains(srch.ToLower()) || x.Message.ToLower().Contains(srch.ToLower())).Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).ToList());

                    var _result = await _job;

                    if (_result == null)
                    {
                        return new List<Sysmsg>();
                    }
                    else
                    {
                        return _result;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// get list of system messages
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public List<Sysmsg> GetAllSystemMessages(string srch)
        {
            try
            {
                if (string.IsNullOrEmpty(srch) || (int)srch.Length <= 0)
                {
                    var _result = _db.tbl_SystemMessages.Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).ToList();
                    

                    if (_result == null)
                    {
                        return new List<Sysmsg>();
                    }
                    else
                    {
                        return _result;
                    }
                }
                else
                {
                    var _result = _db.tbl_SystemMessages.Where(x => x.Name.ToLower().Contains(srch.ToLower()) || x.Message.ToLower().Contains(srch.ToLower())).Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).ToList();
                    

                    if (_result == null)
                    {
                        return new List<Sysmsg>();
                    }
                    else
                    {
                        return _result;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// get system message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Sysmsg> GetSystemMessageAsync(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()) || (int)id <= 0)
                {
                    return null;
                }
                else
                {
                    var _job = Task.Run(() => _db.tbl_SystemMessages.Where(x => x.Id == id).Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).FirstOrDefault());

                    var _result = await _job;

                    if (_result == null)
                    {
                        return null;
                    }
                    else
                    {
                        return _result;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// get system message
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Sysmsg> GetSystemMessageAsync(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || (int)name.Length <= 0)
                {
                    return null;
                }
                else
                {
                    var _job = Task.Run(() => _db.tbl_SystemMessages.Where(x => x.Name.ToLower().Equals(name.ToLower(), StringComparison.CurrentCultureIgnoreCase)).Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).FirstOrDefault());

                    var _result = await _job;

                    if (_result == null)
                    {
                        return null;
                    }
                    else
                    {
                        return _result;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// get system message
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Sysmsg GetSystemMessage(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || (int)name.Length <= 0)
                {
                    return null;
                }
                else
                {
                    var _result = _db.tbl_SystemMessages.Where(x => x.Name.ToLower().Equals(name.ToLower(), StringComparison.CurrentCultureIgnoreCase)).Select(x => new Sysmsg { id = x.Id, message = x.Message, name = x.Name }).FirstOrDefault();
                    
                    if (_result == null)
                    {
                        return null;
                    }
                    else
                    {
                        return _result;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// create new system message
        /// </summary>
        /// <param name="model"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        public async Task<in_Status> CreateSystemMessageAsync(Sysmsg model, RecordMeta meta)
        {
            try
            {
                var newsysmsg = _db.tbl_SystemMessages.Create();

                newsysmsg.Message = model.message;
                newsysmsg.Name = model.name;

                newsysmsg.CreateBy = meta.name;
                newsysmsg.CreatedOn = meta.atdate;
                newsysmsg.ModifiedBy = meta.name;
                newsysmsg.ModifiedOn = meta.atdate;
                newsysmsg.IsDeleted = false;

                _db.tbl_SystemMessages.Add(newsysmsg);

                int _stat = Convert.ToInt32(await _db.SaveChangesAsync());

                if (_stat <= 0)
                {
                    return new in_Status { statuscode = 409, message = "Could not create new system message", status = false, extra = string.Empty };
                }
                else
                {
                    return new in_Status { statuscode = 201, message = "New system message created", status = true, extra = string.Empty };
                }

            }
            catch (Exception ex)
            {
                return new in_Status { statuscode = 500, message = ex.Message, status = false, extra = ex.Source };
            }
        }

        /// <summary>
        /// update system message
        /// </summary>
        /// <param name="model"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        public async Task<in_Status> UpdateSystemMessageAysnc(Sysmsg model, RecordMeta meta)
        {
            try
            {
                if (!_db.tbl_SystemMessages.Where(x => x.Id == model.id).Any())
                {
                    return new in_Status { extra = string.Empty, message = "Could not locate system message", status = false, statuscode = 404 };
                }
                else
                {
                    var sysmsg = _db.tbl_SystemMessages.Where(x => x.Id == model.id).FirstOrDefault();

                    sysmsg.Message = model.message;
                    sysmsg.Name = model.name;
                    sysmsg.ModifiedBy = meta.name;
                    sysmsg.ModifiedOn = meta.atdate;
                    
                    int _stat = Convert.ToInt32(await _db.SaveChangesAsync());

                    if (_stat <= 0)
                    {
                        return new in_Status { extra = string.Empty, message = "Could not update system message", status = false, statuscode = 409 };
                    }
                    else
                    {
                        return new in_Status { statuscode = 200, message = "System message updated", status = true };
                    }
                }
                
            }
            catch (Exception ex)
            {
                return new in_Status { message = ex.Message, statuscode = 500, status = false, extra = ex.Source ?? string.Empty };
            }
        }

        /// <summary>
        /// delete system message
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        public async Task<in_Status> DeleteSystemMEssageAsync(int id, RecordMeta meta)
        {
            try
            {
                if (!_db.tbl_SystemMessages.Where(x => x.Id == id && x.IsDeleted == false).Any())
                {
                    return new in_Status { extra = string.Empty, message = "Could not locate system message", status = false, statuscode = 404 };
                }
                else
                {
                    
                    var sysmsg = _db.tbl_SystemMessages.Where(x => x.Id == id).FirstOrDefault();

                    sysmsg.ModifiedBy = meta.name;
                    sysmsg.ModifiedOn = meta.atdate;
                    sysmsg.DeletedBy = meta.name;
                    sysmsg.DeletedOn = meta.atdate;
                    sysmsg.IsDeleted = true;

                    int _stat = Convert.ToInt32(await _db.SaveChangesAsync());

                    if (_stat <= 0)
                    {
                        return new in_Status { extra = string.Empty, message = "Could not delete system message", status = false, statuscode = 409 };
                    }
                    else
                    {
                        return new in_Status { statuscode = 200, message = "System message delete", status = true };
                    }
                }

            }
            catch (Exception ex)
            {
                return new in_Status { message = ex.Message, statuscode = 500, status = false, extra = ex.Source ?? string.Empty };
            }
        }

    }

    //system message class returned
    public class Sysmsg
    {
        public int id { get; set; } //id of the message
        public string name { get; set; } //name of the message
        public string message { get; set; } //message itself
    }

    /// <summary>
    /// Full System Message, record object used for operations
    /// </summary>
    public class Sysmsg_Record
    {
        public Sysmsg msg { get; set; }

        public in_Metadata metadata { get; set; }
    }

}