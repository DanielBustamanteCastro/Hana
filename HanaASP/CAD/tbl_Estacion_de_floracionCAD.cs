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
    public class tbl_Estacion_de_floracionCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Estacion_de_floracion> Esacion_floracion()
        {
            List<tbl_Estacion_de_floracion> Reino = new List<tbl_Estacion_de_floracion>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Estacion_de_floracion";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Estacion_de_floracion ra = new tbl_Estacion_de_floracion();
                    ra.id_estacion_floracion = int.Parse(dr["id_estacion_de_floracion"].ToString());
                    ra.estacion_floracion = dr["estacion_de_floracion"].ToString();
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
