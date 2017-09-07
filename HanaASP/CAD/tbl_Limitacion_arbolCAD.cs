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
    public class tbl_Limitacion_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Limitacion_arbol> Limitacion_arbol()
        {
            List<tbl_Limitacion_arbol> Reino = new List<tbl_Limitacion_arbol>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Limitacion_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Limitacion_arbol ra = new tbl_Limitacion_arbol();
                    ra.id_limitacion_arbol = int.Parse(dr["id_limitaciones_arbol"].ToString());
                    ra.limitacion_arbol = dr["limitaciones_arbol"].ToString();
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
