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
    public class tbl_Origen_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Origen_ave> Buscar_Origen()
        {
            List<tbl_Origen_ave> Origen = new List<tbl_Origen_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Origen_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Origen_ave Origen_A = new tbl_Origen_ave();
                    Origen_A.Origen_ave = dr["origen_ave"].ToString();
                    Origen_A.id_Origen_ave = int.Parse(dr["id_origen_ave"].ToString());
                    Origen.Add(Origen_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Origen;
        }
    }
}
