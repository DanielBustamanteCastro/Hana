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
    public class tbl_Reino_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Reino_ave> Buscar_Reino(int idDominio)
        {
            List<tbl_Reino_ave> Reino = new List<tbl_Reino_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Reino_ave_todos_con_idDominio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDominio", idDominio);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Reino_ave reino_A = new tbl_Reino_ave();
                    reino_A.Reino_ave = dr["reino_ave"].ToString();
                    reino_A.id_Reino_ave = int.Parse(dr["id_reino_ave"].ToString());
                    Reino.Add(reino_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Reino;
        }
    }
}
