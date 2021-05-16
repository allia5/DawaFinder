using Api.DawaFinder.managers.Manager_User;
using Api.DawaFinder.models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.DawaFinder.services.UserService
{
    public class ServUser : IServUser
    {
        private readonly IUser OuserManager;
        public  ServUser ( IUser user)
        {
            this.OuserManager = user;
        }
        public User getUser(User OuserGet)
        {
            verifet(OuserGet);
            OuserGet.password=remplacerPass(OuserGet);
            if(OuserManager.InserUser(OuserGet) == 1)
            {
                return OuserGet;
            }
            return null;
        }

        private String remplacerPass(User user)
        {
            string password = user.idUser.Replace("-", "*");
            return password;
        }

        private void verifet(User ouserGet)
        {

                verifetemail(ouserGet.email);
            verifetentry(ouserGet.idUser);
            verifetentry(ouserGet.userName);



        }

  

        private void verifetentry(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new Exception("il ya un champs vide");
            }
        }

        private void verifetemail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                throw new Exception("le emaile  ne pas valide");
            }
        }

        public List<User> listUser()
        {

            try
            {
                List<User> tableaux = new List<User>();
                if (OuserManager.getUser() != null) {
                    tableaux = OuserManager.getUser();
                    return tableaux;
                }
                return null;
                

            }catch (Exception e)
            {
                throw;
            }
        }
    }
}
