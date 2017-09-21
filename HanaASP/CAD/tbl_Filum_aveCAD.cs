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
    public class tbl_Filum_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Filum_ave> Buscar_Filum(int idReino)
        {
            List<tbl_Filum_ave> Filum = new List<tbl_Filum_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Filum_ave_todos_con_idReino";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idReino", idReino);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Filum_ave Filum_A = new tbl_Filum_ave();
                    Filum_A.Filum_ave = dr["filum_ave"].ToString();
                    Filum_A.id_Filum_ave = int.Parse(dr["id_filum_ave"].ToString());
                    Filum.Add(Filum_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Filum;
        }
    }
}
