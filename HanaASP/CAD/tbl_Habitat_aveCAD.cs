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
    public class tbl_Habitat_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Habitat_ave> Buscar_Habitat_ave()
        {
            List<tbl_Habitat_ave> Habitat_ave = new List<tbl_Habitat_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Habitat_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Habitat_ave Habitat_ave_A = new tbl_Habitat_ave();
                    Habitat_ave_A.Habitat_ave = dr["habitat_ave"].ToString();
                    Habitat_ave_A.id_Habitat_ave = int.Parse(dr["id_habitat_ave"].ToString());
                    Habitat_ave.Add(Habitat_ave_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Habitat_ave;
        }
    }
}
