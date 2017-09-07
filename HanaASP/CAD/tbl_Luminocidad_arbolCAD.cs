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
    public class tbl_Luminocidad_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Luminocidad_arbol> Luminocidad_arbol()
        {
            List<tbl_Luminocidad_arbol> Reino = new List<tbl_Luminocidad_arbol>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Luminocidad_arbol";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Luminocidad_arbol ra = new tbl_Luminocidad_arbol();
                    ra.id_luminocidad_arbol = int.Parse(dr["id_luminocidad_arbol"].ToString());
                    ra.luminocidad_arbol = dr["luminocidad_arbol"].ToString();
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
