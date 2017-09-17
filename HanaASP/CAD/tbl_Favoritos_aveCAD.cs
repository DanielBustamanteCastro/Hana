using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class tbl_Favoritos_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);
           
        public string agregar_ave(int ave,int usu)
        {
            String mensaje = "Error al agregar a favoritos";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Favoritos_aves";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idU", usu);
                cmd.Parameters.AddWithValue("@idA", ave);
                con.Open();
                int rows=cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Agregado correctamente a favoritos";
            }
            catch (Exception)
            {

                throw;
            }
            return mensaje;
        }

        public List<String[]> Buscar_ave(int id)
        {
            List<String[]> list = new List<string[]>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Favoritos_aves";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_us", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    string idFA = dr["id_favoritos_aves"].ToString();
                    string idF = dr["id_favoritos"].ToString();
                    string idA = dr["id_ave"].ToString();
                    list.Add(new String[] {idFA , idF, idA });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public String Eliminar_ave(int idA,int idU)
        {
            String mensaje = "Error al eliminar";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_DELETE_tbl_Favorios_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idA", idA);
                cmd.Parameters.AddWithValue("@idU", idU);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Eliminado correctamente";
            }
            catch (Exception)
            {

                throw;
            }
            return mensaje;
        }

    }
}
