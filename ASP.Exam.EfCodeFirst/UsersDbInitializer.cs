using System.Collections.Generic;
using System.Data.Entity;

namespace ASP.Exam.DalEfCodeFirst
{
    //class for initialization data base with some data 
    //it calls from Global.asax
    public class UsersDbInitializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext db)
        {
            Users user1 = new Users { Name = "Name1", Surname = "Surname1" };
            Users user2 = new Users { Name = "Name2", Surname = "Surname2" };
            Users user3 = new Users { Name = "Name3", Surname = "Surname3" };
            db.Users.AddRange(new List<Users> { user1, user2, user3 });
            db.SaveChanges();
            Details profile1 = new Details { Id = user1.Id, Age = 11, Address = "Address1" };
            Details profile2 = new Details { Id = user2.Id, Age = 22, Address = "Address2" };
            Details profile3 = new Details { Id = user3.Id, Age = 33, Address = "Address3" };
            db.Details.AddRange(new List<Details> { profile1, profile2, profile3 });
            db.SaveChanges();
        }
    }
}
