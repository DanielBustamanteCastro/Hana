using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
   public class tbl_Clase_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //BUsca el id de la clase con el nombre de la clase
        public int Buscar_id_clase(String clase)
        {
            int id = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Clase_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Clase", clase);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_clase_arbol"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }

        //Busca todas las clase dependientes del id del division
        public List<tbl_Clase_arbol> Buscar_clase(int id_division)
        {
            List<tbl_Clase_arbol> clase = new List<tbl_Clase_arbol>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Clase_arbol_con_id_Division";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_division);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Clase_arbol ca = new tbl_Clase_arbol();
                    ca.id_clase_arbol = int.Parse(dr["id_clase_arbol"].ToString());
                    ca.clase_arbol = dr["clase_arbol"].ToString();
                    clase.Add(ca);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return clase;
        }
    }
}
