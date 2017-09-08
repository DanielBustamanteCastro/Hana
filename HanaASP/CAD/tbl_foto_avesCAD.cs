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
    }
}
