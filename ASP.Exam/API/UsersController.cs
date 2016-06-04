using ASP.Exam.BL;
using ASP.Exam.DalEfCodeFirst;
using ASP.Exam.EfCodeFirst;
using System.Collections.Generic;

using System.Web.Http;

namespace ASP.Exam.API
{    
    public class UsersController : ApiController
    {
        IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/Users
        public IEnumerable<Users> Get()
        {
            //var a = db.Users.Include("DetailsId").ToList();
            return _service.GetAllUsers();
        }

        // GET: api/Users/5
        public System.Web.Mvc.JsonResult Get(int id)
        {
            var detailes = _service.GetUser(id).DetailsId;
            if(detailes != null)
            {
                var result = new { Age = detailes.Age, Address = detailes.Address };
                return (new System.Web.Mvc.JsonResult()
                {
                    Data = result,
                    JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet
                });
            }
            return null;
        }

        // POST: api/Users
        public void Post(NewUser model)
        {
            _service.AddUser(model);
        }

        // PUT: api/Users/5
        //public void Put(int id, [FromBody]EditUser model)
        //{
        //}

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            _service.DeleteUser(id);
        }
    }
}

