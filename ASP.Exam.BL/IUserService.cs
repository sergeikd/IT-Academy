using ASP.Exam.DalEfCodeFirst;
using ASP.Exam.EfCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Exam.BL
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUser(int id);
        void AddUser(NewUser newUser);
        void DeleteUser(int id);
    }
}
