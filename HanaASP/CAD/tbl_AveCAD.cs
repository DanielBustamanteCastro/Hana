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
    public class tbl_AveCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public bool buscar_Ave_con_nombreCientifico(tbl_Ave tblAv)
        {
            bool existe = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_ave_nombreCient";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCient", tblAv.Nombre_cientifico);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int id = 0;
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_ave"].ToString());
                }
                if (id != 0) existe = true;
            }
            catch (Exception)
            {

                throw;
            }
            return existe;
        }
        public String insertar_ave(tbl_Ave tblAv, tbl_Estado_ave tblEst,tbl_Especie_ave tblEpa, tbl_Origen_ave tblOra,tbl_Tipo_ave tblTa,tbl_Clase_dieta tblCld, tbl_Dieta tblD, tbl_Comportamiento_ave tblComp,tbl_Habitat_ave tblHbt,tbl_Reproduccion_ave tblRp, tbl_Color_plumaje tblCpl,tbl_Tamaño_ave tblTma )
        {
            String mensaje = "Error al insertar, porfavor intenta de nuevo";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_cientifico", tblAv.Nombre_cientifico);
                cmd.Parameters.AddWithValue("@nombre_comun", tblAv.Nombre_comun);
                cmd.Parameters.AddWithValue("@descripcion", tblAv.Descripcion);
                cmd.Parameters.AddWithValue("@idTipo", tblTa.id_Tipo_ave);
                cmd.Parameters.AddWithValue("@idDieta", tblD.id_Dieta);
                cmd.Parameters.AddWithValue("@idComportamiento", tblComp.id_Comportamiento_ave);
                cmd.Parameters.AddWithValue("@idHabitat", tblHbt.id_Habitat_ave);
                cmd.Parameters.AddWithValue("@idReproduccion", tblRp.id_Reproduccion_ave);
                cmd.Parameters.AddWithValue("@idEstado", tblEst.id_Estado_ave);
                cmd.Parameters.AddWithValue("@idOrigen", tblOra.id_Origen_ave);
                cmd.Parameters.AddWithValue("@idEspecie", tblEpa.id_Especie_ave);
                cmd.Parameters.AddWithValue("@idTamaño",tblTma.id_Tamaño_ave);
                cmd.Parameters.AddWithValue("@idColor", tblCpl.id_Color_plumaje);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Insertado correctamente";
            }
            catch (Exception e)
            {

                mensaje = e.Message;
            }
            return mensaje;
        }
        public int Buscar_id_ave(tbl_Ave tblAv)
        {
            int id = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_id_ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", tblAv.Nombre_comun);
                cmd.Parameters.AddWithValue("@nombreCi", tblAv.Nombre_cientifico);
                cmd.Parameters.AddWithValue("@id_especie", tblAv.id_Especie_ave);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_ave"].ToString());
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
