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
    public class tbl_Longevidad_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Longevidad_arbol> longevidad_arbol()
        {
            List<tbl_Longevidad_arbol> Reino = new List<tbl_Longevidad_arbol>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Longevidad_arbol";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Longevidad_arbol ra = new tbl_Longevidad_arbol();
                    ra.id_longevidad_arbol = int.Parse(dr["id_longevidad_arbol"].ToString());
                    ra.longevidad_arbol = dr["longevidad_arbol"].ToString();
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
