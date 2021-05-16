using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.models.User
{
    public static class UserMeaper
    {
        public static User user(this DataRow userTab )
        {
            UserStatus getparse;
            Enum.TryParse(userTab["etate"].ToString(), out getparse);
            typeUser getpase;
            Enum.TryParse(userTab["UserType"].ToString(), out getpase);


            return new User
            {
                idUser = (string)userTab["id_user"],


                Status = getparse,

                userName = (string)userTab["user_name"],
                
                CreationDate= (DateTime)userTab["date_creation"],

               email= (string)userTab["Email"],

               Type_U = getpase,
               password= (string)userTab["password"]



            };
        }
        public static List<User> ToUser(this DataTable table)
        {
            List<User> tab = new List<User>();
            foreach (DataRow tb in  table.Rows)
            {
                tab.Add(tb.user());
                
            }
            return tab;
        }
    }
}
