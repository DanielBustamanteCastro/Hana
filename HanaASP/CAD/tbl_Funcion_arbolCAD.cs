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
    public class tbl_Funcion_arbolCAD
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Funcion_arbol> Funcion_arbol()
        {
            List<tbl_Funcion_arbol> Reino = new List<tbl_Funcion_arbol>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Funcion_arbol";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Funcion_arbol ra = new tbl_Funcion_arbol();
                    ra.id_funcion_arbol = int.Parse(dr["id_funcion_arbol"].ToString());
                    ra.funcion_arbol = dr["funcion_arbol"].ToString();
                    Reino.Add(ra);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Reino;
        }
    }
}
