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
    public class tbl_Dominio_arbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);
        
        //Buscamos en id del dominio con el nombre del dominio
        public int Buscar_id_Dominio (String Dominio)
        {
            int id = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Dominio_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dominio", Dominio);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_dominio_arbol"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }
        //Busca los dominios
        public List<tbl_Dominio_arbol> Buscar_Dominio()
        {
            List<tbl_Dominio_arbol> dominio = new List<tbl_Dominio_arbol>(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Dominio_arbol_todos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Dominio_arbol dominio_A = new tbl_Dominio_arbol();
                    dominio_A.dominio_arbol = dr["dominio_arbol"].ToString();
                    dominio_A.id_dominio_arbol = int.Parse(dr["id_dominio_arbol"].ToString());
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
