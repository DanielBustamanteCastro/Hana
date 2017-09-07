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
    public class tbl_Tipo_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public List<tbl_Tipo_arbol> Buscar_Tipo()
        {
            List<tbl_Tipo_arbol> Reino = new List<tbl_Tipo_arbol>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Tipo_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Tipo_arbol ra = new tbl_Tipo_arbol();
                    ra.id_tipo_arbol = int.Parse(dr["id_tipo_arbol"].ToString());
                    ra.Tipo_arbol = dr["tipo_arbol"].ToString();
                    Reino.Add(ra);
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
