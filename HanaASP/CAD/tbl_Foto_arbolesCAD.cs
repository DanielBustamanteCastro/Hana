using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace CAD
{
    public class tbl_Foto_arbolesCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public String insert_foto_arboles(tbl_Fotos_arboles tblFa)
        {
            String mensaje = "Error al insertar, intenta nuevamente";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Foto_arboles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@foto", tblFa.foto_arbol);
                cmd.Parameters.AddWithValue("@idA", tblFa.id_arbol);
                con.Open();
                int rows =0;
                rows=cmd.ExecuteNonQuery();
                if (rows != 0) mensaje = "Insertado correctamente";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return mensaje;
        }

        public List<tbl_Fotos_arboles> Buscar_fotos(tbl_Arbol ar)
        {
            List<tbl_Fotos_arboles> lista = new List<tbl_Fotos_arboles>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=con;
                cmd.CommandText = "prc_Buscar_tbl_Fotos_arboles_con_id_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ar.id_arbol);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Fotos_arboles fa = new tbl_Fotos_arboles();
                    fa.foto_arbol = dr["foto_arbol"].ToString();
                    fa.id_arbol=int.Parse(dr["id_foto_arbol"].ToString());
                    lista.Add(fa);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
