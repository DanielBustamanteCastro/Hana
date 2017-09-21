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
    public class tbl_Familia_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Familia_ave> Buscar_Familia(int idOrden)
        {
            List<tbl_Familia_ave> Familia = new List<tbl_Familia_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Familia_ave_todos_con_idOrden";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Familia_ave Familia_A = new tbl_Familia_ave();
                    Familia_A.Familia_ave = dr["familia_ave"].ToString();
                    Familia_A.id_Familia_ave = int.Parse(dr["id_familia_ave"].ToString());
                    Familia.Add(Familia_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Familia;
        }
    }
}
