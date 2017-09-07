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
    public class tbl_Orden_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Buscamos orden arbol con id de la clase arbol
        public List<tbl_Orden_arbol> Buscar_orden(int id_clase)
        {
            List<tbl_Orden_arbol> clase = new List<tbl_Orden_arbol>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Orden_arbol_con_id_Clase";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_clase);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Orden_arbol ca = new tbl_Orden_arbol();
                    ca.id_Orden_arbol = int.Parse(dr["id_orden_arbol"].ToString());
                    ca.Orden_arbol = dr["oreden_arbol"].ToString();
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
