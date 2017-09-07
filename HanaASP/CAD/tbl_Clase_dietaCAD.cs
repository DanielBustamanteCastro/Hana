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
    public class tbl_Clase_dietaCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Clase_dieta> Buscar_Clase_dieta()
        {
            List<tbl_Clase_dieta> Clase_dieta = new List<tbl_Clase_dieta>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Clase_dieta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Clase_dieta Clase_dieta_A = new tbl_Clase_dieta();
                    Clase_dieta_A.Clase_dieta = dr["clase_dieta"].ToString();
                    Clase_dieta_A.id_Clase_dieta = int.Parse(dr["id_clase_dieta"].ToString());
                    Clase_dieta.Add(Clase_dieta_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Clase_dieta;
        }
    }
}
