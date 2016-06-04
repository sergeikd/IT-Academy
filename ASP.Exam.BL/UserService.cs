using ASP.Exam.DalEfCodeFirst;
using ASP.Exam.EfCodeFirst;
using System.Collections.Generic;
using System.Linq;

namespace ASP.Exam.BL
{
    public class UserService : IUserService
    {
        UsersContext db = new UsersContext();
        public IEnumerable<Users> GetAllUsers()
        {
            return db.Users;
        }

        public Users GetUser(int id)
        {
            Users user = new Users();
            try
            {
                user = db.Users.Include("DetailsId").Where(x => x.Id == id).First();
            }
            catch
            {
            }
            return user;
        }
        public void AddUser(NewUser newUser)
        {
            Users user = new Users { Name = newUser.Name, Surname = newUser.Surname };
            db.Users.Add(user);
            db.SaveChanges();

            db.Details.Add(new Details { Id = user.Id, Age = newUser.Age, Address = newUser.Address });
            db.SaveChanges();
        }
        public void DeleteUser (int id)
        {
            Users user = db.Users.Include("DetailsId").Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                db.Details.Remove(user.DetailsId);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
