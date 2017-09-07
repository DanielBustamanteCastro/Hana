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
    public class tbl_Genero_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Buscamos orden arbol con id de la clase arbol
        public List<tbl_Genero_arbol> Buscar_Genero(int id_familia)
        {
            List<tbl_Genero_arbol> clase = new List<tbl_Genero_arbol>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Genero_arbol_con_id_familia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_familia);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Genero_arbol  ca = new tbl_Genero_arbol();
                    ca.id_Genero_arbol = int.Parse(dr["id_genero_arbol"].ToString());
                    ca.Genero_arbol = dr["genero_arbol"].ToString();
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
