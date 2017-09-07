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
    public class tbl_Dominio_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los dominios
        public List<tbl_Dominio_ave> Buscar_Dominio()
        {
            List<tbl_Dominio_ave> dominio = new List<tbl_Dominio_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Dominio_ave_todos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Dominio_ave dominio_A = new tbl_Dominio_ave();
                    dominio_A.Dominio_ave = dr["dominio_ave"].ToString();
                    dominio_A.id_Dominio_ave = int.Parse(dr["id_dominio_ave"].ToString());
                    dominio.Add(dominio_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return dominio;
        }
    }
}
