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
    public class tbl_Foto_avesCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public String insert_foto_aves(tbl_Fotos_aves tblFa)
        {
            String mensaje = "Error al insertar, intenta nuevamente";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Foto_aves";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@foto", tblFa.Fotos_aves);
                cmd.Parameters.AddWithValue("@idA", tblFa.id_Aves);
                con.Open();
                int rows = 0;
                rows = cmd.ExecuteNonQuery();
                if (rows != 0) mensaje = "Insertado correctamente";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return mensaje;
        }

        public List<tbl_Fotos_aves> Buscar_fotos_aves(tbl_Ave av)
        {
            List<tbl_Fotos_aves> list = new List<tbl_Fotos_aves>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_tbl_Fotos_aves_con_id_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", av.id_Ave);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tbl_Fotos_aves fa = new tbl_Fotos_aves();
                    fa.id_Fotos_aves = int.Parse(dr["id_foto_ave"].ToString());
                    fa.Fotos_aves = dr["foto_ave"].ToString();
                    list.Add(fa);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
        public String Modificar_foto_aves(tbl_Fotos_aves tblFa)
        {
            String mensaje = "Error al modificar, intenta nuevamente";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_UPDATE_tbl_Foto_aves";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@foto", tblFa.Fotos_aves);
                cmd.Parameters.AddWithValue("@idA", tblFa.id_Aves);
                con.Open();
                int rows = 0;
                rows = cmd.ExecuteNonQuery();
                if (rows != 0) mensaje = "Modificado correctamente";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return mensaje;
        }
    }
}
