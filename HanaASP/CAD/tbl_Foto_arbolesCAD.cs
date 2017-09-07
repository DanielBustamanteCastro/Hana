﻿using System;
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
    }
}
