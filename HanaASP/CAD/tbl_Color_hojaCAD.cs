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
    public class tbl_Color_hojaCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);


            SqlCommand cmd = new SqlCommand();
        public List<tbl_Color_hoja> Buscar_color_hoja() {
            List<tbl_Color_hoja> list = new List<tbl_Color_hoja>();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Color_hoja";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Color_hoja ch = new tbl_Color_hoja();
                    ch.id_color_hoja = int.Parse(dr["id_color_hoja"].ToString());
                    ch.color_hoja = dr["color_hoja"].ToString();
                    list.Add(ch);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;

        }
    }
}
