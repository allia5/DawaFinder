using Api.DawaFinder.managers;
using Api.DawaFinder.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.DawaFinder.services
{
    public   class OfficeServices : IOfficeService
    {
        private readonly IOfficeManager oManager;
       public OfficeServices(IOfficeManager Manager)
        {

            
            this.oManager = Manager;

        }
        public  List<Office> getAll()
        {
            return oManager.SelectManger();
        }

        public Office Validate(Office off)
        {
            
            Validatnom(off.nom);
            Validatprenom(off.adress);
            Validatmail(off.email);
            return off;
            
            
        }
        public void Validatnom(String nom)
        {
            if (String.IsNullOrWhiteSpace(nom)) 
            {
                throw new Exception("le champs nom ne pas valide");
            }
        }
        public void Validatprenom(String prenom)
        {
            if (String.IsNullOrWhiteSpace(prenom))
            {
                throw new Exception("le prenome ne pas valide");
            }
        }
        public void Validatmail(String email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                throw new Exception("le emaile  ne pas valide");
            }
        }

        public Office insertoff(Office off)
        {
            try
            {
                Validate(off);
                System.Guid guid = System.Guid.NewGuid();
                off.id = guid.ToString(); 
                if (oManager.inserttoManager(off) == 1)
                {
                    return off;
                }
                return null;
            } catch (Exception e)
            {
                throw;
            }



        }
    }
}
