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
    public class tbl_Especie_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Especie_ave> Buscar_Especie(int idGenero)
        {
            List<tbl_Especie_ave> Especie = new List<tbl_Especie_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Especie_ave_todos_con_idGenero";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idGenero", idGenero);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Especie_ave Especie_A = new tbl_Especie_ave();
                    Especie_A.Especie_ave = dr["especie_aves"].ToString();
                    Especie_A.id_Especie_ave = int.Parse(dr["id_especie_ave"].ToString());
                    Especie.Add(Especie_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Especie;
        }
    }
}
