using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Net.Models
{
    public interface IUser
    {
        void save(User u);
        List<User> logIn(User u);
        User getUser(String user1);
    }
}
