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
    public class tbl_Genero_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Genero_Ave> Buscar_Genero(int idFamilia)
        {
            List<tbl_Genero_Ave> Genero = new List<tbl_Genero_Ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Genero_ave_todos_con_idFamilia";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFamilia", idFamilia);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Genero_Ave Genero_A = new tbl_Genero_Ave();
                    Genero_A.Genero_ave = dr["genero_ave"].ToString();
                    Genero_A.id_Genero_ave = int.Parse(dr["id_genero_ave"].ToString());
                    Genero.Add(Genero_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Genero;
        }
    }
}
