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
    public class tbl_Especie_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Buscamos orden arbol con id de la clase arbol
        public List<tbl_Especie_arbol> Buscar_especie(int id_clase)
        {
            List<tbl_Especie_arbol> clase = new List<tbl_Especie_arbol>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Especie_arbol_con_id_genero";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_clase);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Especie_arbol ca = new tbl_Especie_arbol();
                    ca.id_especie_arbol = int.Parse(dr["id_especie_arbol"].ToString());
                    ca.especie_arbol = dr["especie_arbol"].ToString();
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
