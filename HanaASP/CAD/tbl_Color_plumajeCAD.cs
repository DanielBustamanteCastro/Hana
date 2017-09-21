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
    public class tbl_Color_plumajeCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Busca los Reinos
        public List<tbl_Color_plumaje> Buscar_Color_plumaje()
        {
            List<tbl_Color_plumaje> Color_plumaje = new List<tbl_Color_plumaje>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_tbl_Color_plumaje";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Color_plumaje Color_plumaje_A = new tbl_Color_plumaje();
                    Color_plumaje_A.Color_plumaje = dr["color_plumaje"].ToString();
                    Color_plumaje_A.id_Color_plumaje = int.Parse(dr["id_color_plumaje"].ToString());
                    Color_plumaje.Add(Color_plumaje_A);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Color_plumaje;
        }
    }
}
