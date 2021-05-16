using System;
using System.Collections.Generic;
using System.Linq;



namespace Api.DawaFinder.models.User
{
    public class User
    {
        public String idUser { get; set; }
        public String userName { get; set; }
        public typeUser Type_U { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public String email { get; set; }
        public String password { get; set; }

    }
}
