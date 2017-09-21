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
    public class tbl_Tipo_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Tipo_ave> Buscar_Tipo()
        {
            List<tbl_Tipo_ave> Tipo = new List<tbl_Tipo_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Tipo_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Tipo_ave Tipo_A = new tbl_Tipo_ave();
                    Tipo_A.Tipo_ave = dr["tipo_ave"].ToString();
                    Tipo_A.id_Tipo_ave = int.Parse(dr["id_tipo_ave"].ToString());
                    Tipo.Add(Tipo_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Tipo;
        }
    }
}
