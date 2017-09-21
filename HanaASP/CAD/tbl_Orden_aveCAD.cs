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
    public class tbl_Orden_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Orden_ave> Buscar_Orden(int idClase)
        {
            List<tbl_Orden_ave> Orden = new List<tbl_Orden_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Orden_ave_todos_con_idClase";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idClase", idClase);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Orden_ave Orden_A = new tbl_Orden_ave();
                    Orden_A.Orden_ave = dr["orden_aves"].ToString();
                    Orden_A.id_Orden_ave = int.Parse(dr["id_orden_ave"].ToString());
                    Orden.Add(Orden_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Orden;
        }
    }
}
