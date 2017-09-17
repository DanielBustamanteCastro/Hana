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
        public String insertar_ave(tbl_Ave tblAv, tbl_Estado_ave tblEst, tbl_Especie_ave tblEpa, tbl_Origen_ave tblOra, tbl_Tipo_ave tblTa, tbl_Clase_dieta tblCld, tbl_Dieta tblD, tbl_Comportamiento_ave tblComp, tbl_Habitat_ave tblHbt, tbl_Reproduccion_ave tblRp, tbl_Color_plumaje tblCpl, tbl_Tamaño_ave tblTma)
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
                cmd.Parameters.AddWithValue("@idTamaño", tblTma.id_Tamaño_ave);
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
        public List<String[]> Llamar_aves()
        {
            List<String[]> lista = new List<string[]>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_tbl_Ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    String id_ave = dr["id_ave"].ToString();
                    String nom_cient_ave = dr["nom_cient_ave"].ToString();
                    String nom_com_ave = dr["nom_com_ave"].ToString();
                    String desc_ave = dr["desc_ave"].ToString();
                    String estado_ave = dr["estado_ave"].ToString();
                    String dominio_ave = dr["dominio_ave"].ToString();
                    String reino_ave = dr["reino_ave"].ToString();
                    String filum_ave = dr["filum_ave"].ToString();
                    String clase_ave = dr["clase_ave"].ToString();
                    String orden_aves = dr["orden_aves"].ToString();
                    String familia_ave = dr["familia_ave"].ToString();
                    String genero_ave = dr["genero_ave"].ToString();
                    String especie_aves = dr["especie_aves"].ToString();
                    String origen_ave = dr["origen_ave"].ToString();
                    String tipo_ave = dr["tipo_ave"].ToString();
                    String desc_dieta = dr["desc_dieta"].ToString();
                    String comportamiento_ave = dr["comportamiento_ave"].ToString();
                    String habitat_ave = dr["habitat_ave"].ToString();
                    String reproduccion_ave = dr["reproduccion_ave"].ToString();
                    String color_plumaje = dr["color_plumaje"].ToString();
                    String tamaño_ave = dr["tamaño_ave"].ToString();
                    String tipo_dieta = dr["clase_dieta"].ToString();
                    lista.Add(new String[] { id_ave, nom_cient_ave, nom_com_ave, desc_ave,
                    estado_ave,dominio_ave,reino_ave,filum_ave,clase_ave,orden_aves,familia_ave,
                    genero_ave,especie_aves,origen_ave,tipo_ave,desc_dieta,comportamiento_ave,
                    habitat_ave,reproduccion_ave,color_plumaje,tamaño_ave,tipo_dieta});
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public String[] Buscar_ave_nombre_cientifico(tbl_Ave av)
        {
            String[] Save = new String[22];
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_tbl_Ave_nombreCient";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCient", av.Nombre_cientifico);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    Save[0] = dr["id_ave"].ToString();
                    Save[1] = dr["nom_cient_ave"].ToString();
                    Save[2] = dr["nom_com_ave"].ToString();
                    Save[3] = dr["desc_ave"].ToString();
                    Save[4] = dr["id_estado_ave"].ToString();
                    Save[5] = dr["id_dominio_ave"].ToString();
                    Save[6] = dr["id_reino_ave"].ToString();
                    Save[7] = dr["id_filum_ave"].ToString();
                    Save[8] = dr["id_dieta_ave"].ToString();
                    Save[9] = dr["id_orden_ave"].ToString();
                    Save[10] = dr["id_familia_ave"].ToString();
                    Save[11] = dr["id_genero_ave"].ToString();
                    Save[12] = dr["id_especie_ave"].ToString();
                    Save[13] = dr["id_origen_ave"].ToString();
                    Save[14] = dr["id_tipo_ave"].ToString();
                    Save[15] = dr["id_comportamiento_ave"].ToString();
                    Save[16] = dr["id_habitat_ave"].ToString();
                    Save[17] = dr["id_reproduccion_ave"].ToString();
                    Save[18] = dr["id_color_plumaje"].ToString();
                    Save[19] = dr["id_tamaño_ave"].ToString();
                    Save[20] = dr["id_clase_dieta"].ToString();
                    Save[21] = dr["id_clase_ave"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Save;
        }
        public String Modificar_ave(tbl_Ave tblAv, tbl_Estado_ave tblEst, tbl_Especie_ave tblEpa, tbl_Origen_ave tblOra, tbl_Tipo_ave tblTa, tbl_Clase_dieta tblCld, tbl_Dieta tblD, tbl_Comportamiento_ave tblComp, tbl_Habitat_ave tblHbt, tbl_Reproduccion_ave tblRp, tbl_Color_plumaje tblCpl, tbl_Tamaño_ave tblTma)
        {
            String mensaje = "Error al modificar, porfavor intenta de nuevo";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_UPDATE_tbl_Ave";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAve", tblAv.id_Ave);
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
                cmd.Parameters.AddWithValue("@idTamaño", tblTma.id_Tamaño_ave);
                cmd.Parameters.AddWithValue("@idColor", tblCpl.id_Color_plumaje);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Modificado correctamente";
            }
            catch (Exception e)
            {

                mensaje = e.Message;
            }
            return mensaje;
        }
        public int Buscar_id_ave_cient(tbl_Ave tblAv)
        {
            int id = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_id_ave_nomcient";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCi", tblAv.Nombre_cientifico);
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

        public List<String[]> Llamar_aves_id(List<String[]> mustra)
        {
            List<String[]> lista = new List<string[]>();
            try
            {
                foreach (var m in mustra)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "prc_Buscar_tbl_Ave_id";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", m[2]);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    foreach (var item in dr)
                    {
                        String id_ave = dr["id_ave"].ToString();
                        String nom_cient_ave = dr["nom_cient_ave"].ToString();
                        String nom_com_ave = dr["nom_com_ave"].ToString();
                        String desc_ave = dr["desc_ave"].ToString();
                        String estado_ave = dr["estado_ave"].ToString();
                        String dominio_ave = dr["dominio_ave"].ToString();
                        String reino_ave = dr["reino_ave"].ToString();
                        String filum_ave = dr["filum_ave"].ToString();
                        String clase_ave = dr["clase_ave"].ToString();
                        String orden_aves = dr["orden_aves"].ToString();
                        String familia_ave = dr["familia_ave"].ToString();
                        String genero_ave = dr["genero_ave"].ToString();
                        String especie_aves = dr["especie_aves"].ToString();
                        String origen_ave = dr["origen_ave"].ToString();
                        String tipo_ave = dr["tipo_ave"].ToString();
                        String desc_dieta = dr["desc_dieta"].ToString();
                        String comportamiento_ave = dr["comportamiento_ave"].ToString();
                        String habitat_ave = dr["habitat_ave"].ToString();
                        String reproduccion_ave = dr["reproduccion_ave"].ToString();
                        String color_plumaje = dr["color_plumaje"].ToString();
                        String tamaño_ave = dr["tamaño_ave"].ToString();
                        String tipo_dieta = dr["clase_dieta"].ToString();
                        lista.Add(new String[] { id_ave, nom_cient_ave, nom_com_ave, desc_ave,
                    estado_ave,dominio_ave,reino_ave,filum_ave,clase_ave,orden_aves,familia_ave,
                    genero_ave,especie_aves,origen_ave,tipo_ave,desc_dieta,comportamiento_ave,
                    habitat_ave,reproduccion_ave,color_plumaje,tamaño_ave,tipo_dieta});
                    }
                    con.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
