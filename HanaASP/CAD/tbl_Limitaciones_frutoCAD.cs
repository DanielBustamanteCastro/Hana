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
    public class tbl_Limitaciones_frutoCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Limitaciones_fruto> Limitacion_fruto()
        {
            List<tbl_Limitaciones_fruto> Reino = new List<tbl_Limitaciones_fruto>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Limitacion_fruto";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Limitaciones_fruto ra = new tbl_Limitaciones_fruto();
                    ra.id_limitacioin_fruto = int.Parse(dr["id_limitaciones_fruto"].ToString());
                    ra.limitacion_fruto = dr["limitaciones_fruto"].ToString();
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
