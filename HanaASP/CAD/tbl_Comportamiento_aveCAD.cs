using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CAD
{
    public class tbl_Comportamiento_aveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Comportamiento_ave> Buscar_Comportamiento_ave()
        {
            List<tbl_Comportamiento_ave> Comportamiento_ave = new List<tbl_Comportamiento_ave>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Comportamiento_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Comportamiento_ave Comportamiento_ave_A = new tbl_Comportamiento_ave();
                    Comportamiento_ave_A.Comportamiento_ave = dr["comportamiento_ave"].ToString();
                    Comportamiento_ave_A.id_Comportamiento_ave = int.Parse(dr["id_comportamiento_ave"].ToString());
                    Comportamiento_ave.Add(Comportamiento_ave_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Comportamiento_ave;
        }
    }
}
