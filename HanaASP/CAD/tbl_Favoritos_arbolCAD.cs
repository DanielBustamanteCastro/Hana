using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
   public  class tbl_Favoritos_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public string agregar_arbol(int arbol, int usu)
        {
            String mensaje = "Error al agregar a favoritos";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Favoritos_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idU", usu);
                cmd.Parameters.AddWithValue("@idA", arbol);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Agregado correctamente a favoritos";
            }
            catch (Exception)
            {

                throw;
            }
            return mensaje;
        }

        public List<String[]> Buscar_arbol(int id)
        {
            List<String[]> list = new List<string[]>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Favoritos_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_us", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    string idFA = dr["id_favoritos_arbol"].ToString();
                    string idF = dr["id_favoritos"].ToString();
                    string idA = dr["id_arbol"].ToString();
                    list.Add(new String[] { idFA, idF, idA });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public String Eliminar_arbol(int idA, int idU)
        {
            String mensaje = "Error al eliminar";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_DELETE_tbl_Favorios_arbol";
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
        public String Validar_favoritos(String NombreCient, String Correo)
        {
            String mensaje = "No existe";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Confirmar_Favoritos_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomcient", NombreCient);
                cmd.Parameters.AddWithValue("@correo", Correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    mensaje = "Existe";
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return mensaje;
        }
    }
}
