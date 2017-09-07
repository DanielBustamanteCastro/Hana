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
   public  class tbl_Familia_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Buscamos orden arbol con id de la clase arbol
        public List<tbl_Familia_arbol> Buscar_familia(int id_clase)
        {
            List<tbl_Familia_arbol> clase = new List<tbl_Familia_arbol>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Familia_arbol_con_id_Orden";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_clase);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Familia_arbol ca = new tbl_Familia_arbol();
                    ca.id_Familia_arbol = int.Parse(dr["id_familia_arbol"].ToString());
                    ca.Familia_arbol = dr["familia_arbol"].ToString();
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
