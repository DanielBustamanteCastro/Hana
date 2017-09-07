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
    public class tbl_DietaCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Dieta> Buscar_Dieta(int idClase_dieta)
        {
            List<tbl_Dieta> Dieta = new List<tbl_Dieta>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Dieta_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idClase_dieta", idClase_dieta);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Dieta Dieta_A = new tbl_Dieta();
                    Dieta_A.Dieta = dr["desc_dieta"].ToString();
                    Dieta_A.id_Dieta = int.Parse(dr["id_dieta_ave"].ToString());
                    Dieta.Add(Dieta_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Dieta;
        }
    }
}
