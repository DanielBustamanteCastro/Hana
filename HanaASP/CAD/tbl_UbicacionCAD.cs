using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class tbl_UbicacionCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Buscar la ubicacion para listar en un ddl
        public List<String> Buscar_ubicacion()
        {
            List<String> lstUbicacion = new List<String>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_Ubicacion";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    lstUbicacion.Add(dr["departamento"].ToString());
                }
                con.Close(); 
            }
            catch (Exception e)
            {
                lstUbicacion.Add(e.Message);
            }
            return lstUbicacion;  
        }

        //Busca la ubicacion y devuelve el id
        public int Buscar_id(String Ubicacion)
        {
            int id=0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_Ubicacion_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ubicacion", Ubicacion);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_Ubicacion"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }
    }
}
