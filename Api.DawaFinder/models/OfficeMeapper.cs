using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Api.DawaFinder.models
{
    public static class OfficeMeapper
    {
        public static Office getOffice (this DataRow row)
        {
            if (row is null)
            {
                return null;
                
            }
            else
            {
                return new Office
                {
                    id = (string)row["id"],
                    nom = (string)row["nom"],
                    
                    telph = (string)row["Telph"],
                    adress = (string)row["Adress"],
                    Ville = (string)row["Ville"],
                    Wilaya = (string)row["Willaya"],
                    email = (string)row["Email"],
                    Agrement  = (string)row["Agrement"]
                };
            }
 



        }

        public static List<Office> TOoffice(this DataTable row1)
        {
            List<Office> list = new List<Office>();
            foreach (DataRow row in row1.Rows)
            {
                list.Add(row.getOffice());
            }
            return list;
        }
    }
}
