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
    public class tbl_Persistencia_hojaCAD
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Persistencia_hoja> Persistencia_hoja()
        {
            List<tbl_Persistencia_hoja> Reino = new List<tbl_Persistencia_hoja>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Persistencia_hoja";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Persistencia_hoja ra = new tbl_Persistencia_hoja();
                    ra.id_persistencia_hoja = int.Parse(dr["id_persistencia_hoja"].ToString());
                    ra.persistencia_hoja = dr["persistencia_hoja"].ToString();
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
