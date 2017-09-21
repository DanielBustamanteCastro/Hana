using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace CAD
{
    public class tbl_Clase_aveCAD
    {
        

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);
        //Busca los Reinos
        public List<tbl_Clase_ave> Buscar_Clase(int idFilum)
        {
            List<tbl_Clase_ave> Clase = new List<tbl_Clase_ave>(); ;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Clase_ave_todos_con_idFilum";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFilum", idFilum);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Clase_ave Clase_A = new tbl_Clase_ave();
                    Clase_A.Clase_ave = dr["clase_ave"].ToString();
                    Clase_A.id_Clase_ave = int.Parse(dr["id_clase_ave"].ToString());
                    Clase.Add(Clase_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Clase;
        }

    }
}
