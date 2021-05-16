using Api.DawaFinder.models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.managers.Manager_User
{
    public interface IUser
    {
        public List<User> getUser();
        public int InserUser(User user);
        

        
    }
}
