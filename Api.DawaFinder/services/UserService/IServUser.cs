using Api.DawaFinder.managers.Manager_User;
using Api.DawaFinder.models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.services.UserService
{
    

   public interface IServUser
    {

        public User getUser(User OuserGet);
        public List<User> listUser();
        

        
    }
}
