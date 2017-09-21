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
    public class tbl_Reproduccion_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Reproduccion_ave> Buscar_Reproduccion_ave()
        {
            List<tbl_Reproduccion_ave> Reproduccion_ave = new List<tbl_Reproduccion_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Reproduccion_aves";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Reproduccion_ave Reproduccion_ave_A = new tbl_Reproduccion_ave();
                    Reproduccion_ave_A.Reproduccion_ave = dr["reproduccion_ave"].ToString();
                    Reproduccion_ave_A.id_Reproduccion_ave = int.Parse(dr["id_reproduccion_ave"].ToString());
                    Reproduccion_ave.Add(Reproduccion_ave_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Reproduccion_ave;
        }
    }
}
