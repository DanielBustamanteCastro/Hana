using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CAD
{
    class tbl_RolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);


        //Buscar id de rol
        public int Buscar_rol(String Rol)
        {
            int id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=con;
                cmd.CommandText = "prc_SELECT_Rol";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rol",Rol);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                   id=int.Parse(dr["id_rol"].ToString());                    
                }
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            return id;
        }

    }
}
