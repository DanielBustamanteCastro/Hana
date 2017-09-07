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
    public class tbl_Tamaño_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Tamaño_ave> Buscar_Tamaño_ave()
        {
            List<tbl_Tamaño_ave> Tamaño_ave = new List<tbl_Tamaño_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Tamaño_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Tamaño_ave Tamaño_ave_A = new tbl_Tamaño_ave();
                    Tamaño_ave_A.Tamaño_ave = dr["tamaño_ave"].ToString();
                    Tamaño_ave_A.id_Tamaño_ave = int.Parse(dr["id_tamaño_ave"].ToString());
                    Tamaño_ave.Add(Tamaño_ave_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Tamaño_ave;
        }
    }
}
