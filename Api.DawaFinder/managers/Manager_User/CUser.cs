using Api.DawaFinder.models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.managers.Manager_User
{

    public class CUser : IUser
    {
        private string str = "Data Source=laptop-3lrva8n6\\dev000;Initial Catalog=DawaFinder;Integrated Security=True";
        public List<User> getUser()
        {
            try
            {
                SqlConnection connect = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("SELECT * from Tuser", connect);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                connect.Open();
                da.Fill(dt);
                return dt.ToUser();
            }
            catch (Exception e)
            {
                throw;
            }


        }

        public int InserUser(User user)
        {


            try
            {
                SqlConnection cnx = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("INSERT INTO  officier values(@aid,@anom,@aAgrement,@atelph,@aAdress,@aVille,@aWillaya,@aemail)", cnx);
                cmd.Parameters.AddWithValue("@aid", user.idUser);
                cmd.Parameters.AddWithValue("@anom", user.userName);
                cmd.Parameters.AddWithValue("@aAgrement", user.Status);
                cmd.Parameters.AddWithValue("@atelph", user.Type_U);
                cmd.Parameters.AddWithValue("@aAdress", user.email);
                cmd.Parameters.AddWithValue("@aVille", user.CreationDate);
                cmd.Parameters.AddWithValue("@aWillaya", user.Status);
                cmd.Parameters.AddWithValue("@aemail", user.password);

                cnx.Open();
                int index = cmd.ExecuteNonQuery();
                return index;
            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}
