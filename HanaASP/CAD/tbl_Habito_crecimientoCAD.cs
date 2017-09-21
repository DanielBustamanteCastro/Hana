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
    public class tbl_Habito_crecimientoCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Habito_crecimiento> Habito_crecimiento()
        {
            List<tbl_Habito_crecimiento> Reino = new List<tbl_Habito_crecimiento>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Habito_crecimiento";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Habito_crecimiento ra = new tbl_Habito_crecimiento();
                    ra.id_habito_crecimiento = int.Parse(dr["id_crecimiento"].ToString());
                    ra.habito_crecimiento = dr["crecimiento"].ToString();
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
