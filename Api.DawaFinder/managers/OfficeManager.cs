using Api.DawaFinder.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Api.DawaFinder.managers
{
    
    public class OfficeManager : IOfficeManager
    {
        private string str="Data Source=laptop-3lrva8n6\\dev000;Initial Catalog=DawaFinder;Integrated Security=True";

        public int inserttoManager(Office off)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("INSERT INTO  officier values(@aid,@anom,@aAgrement,@atelph,@aAdress,@aVille,@aWillaya,@aemail)", cnx);
                cmd.Parameters.AddWithValue("@aid", off.id);
                cmd.Parameters.AddWithValue("@anom", off.nom);
                cmd.Parameters.AddWithValue("@aAgrement", off.Agrement);
                cmd.Parameters.AddWithValue("@atelph", off.telph);
                cmd.Parameters.AddWithValue("@aAdress", off.adress);
                cmd.Parameters.AddWithValue("@aVille", off.Ville);
                cmd.Parameters.AddWithValue("@aWillaya", off.Wilaya);
                cmd.Parameters.AddWithValue("@aemail", off.email);
                cnx.Open();
                int index = cmd.ExecuteNonQuery();
                return index;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public List<Office> SelectManger()
        {
            SqlConnection connect = new SqlConnection(str);
            SqlCommand cmd =new  SqlCommand("SELECT * from officier", connect);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            connect.Open();
            da.Fill(dt);
            return dt.TOoffice();
        }
    }
}
