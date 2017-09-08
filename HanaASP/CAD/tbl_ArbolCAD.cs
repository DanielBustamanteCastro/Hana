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
    public class tbl_ArbolCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        public String insertar_flora(tbl_Flora tblFl,tbl_Estado_arbol tblEst,  tbl_Especie_arbol tblEp, tbl_Tipo_arbol tblTp, tbl_Habito_crecimiento tblHc, tbl_Altura_arbol tblAt, tbl_Diametro_arbol tblDm, tbl_Amplitud_copa tblAm, tbl_Forma_de_copa tblFr, tbl_Persistencia_hoja tblPt, tbl_Color_flor tblCf, tbl_Estacion_de_floracion tblEf, tbl_Limitacion_arbol tblLa, tbl_Limitaciones_fruto tblLf, tbl_Longevidad_arbol tblLg, tbl_Piso_termico tblPs, tbl_Funcion_arbol tblFn, tbl_Color_hoja tblCh, tbl_Luminocidad_arbol tblLum)
        {
            String mensaje = "Error al insertar, porfavor intenta de nuevo";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_Flora";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCientifico", tblFl.nombre_cientifico);
                cmd.Parameters.AddWithValue("@nombreComun", tblFl.nombre_comun);
                cmd.Parameters.AddWithValue("@descripcion", tblFl.descripcion_flora);
                cmd.Parameters.AddWithValue("@idTipo", tblTp.id_tipo_arbol);
                cmd.Parameters.AddWithValue("@idEspecie", tblEp.id_especie_arbol);
                cmd.Parameters.AddWithValue("@idCrecimiento", tblHc.id_habito_crecimiento);
                cmd.Parameters.AddWithValue("@idAltura", tblAt.id_altura_arbol);
                cmd.Parameters.AddWithValue("@idDiametro", tblDm.id_diametro_arbol);
                cmd.Parameters.AddWithValue("@idAmplitudC", tblAm.id_amplitud);
                cmd.Parameters.AddWithValue("@idFormaC", tblFr.id_forma_copa);
                cmd.Parameters.AddWithValue("@idPersistencia", tblPt.id_persistencia_hoja);
                cmd.Parameters.AddWithValue("@idColor", tblCf.id_clolor_flor);
                cmd.Parameters.AddWithValue("@idEstacionF", tblEf.id_estacion_floracion);
                cmd.Parameters.AddWithValue("@idLimitacionFl", tblLa.id_limitacion_arbol);
                cmd.Parameters.AddWithValue("@idLimitacionFr", tblLf.id_limitacioin_fruto);
                cmd.Parameters.AddWithValue("@idLongevidad", tblLg.id_longevidad_arbol);
                cmd.Parameters.AddWithValue("@idPisoTermico", tblPs.id_piso_termico);
                cmd.Parameters.AddWithValue("@idLuminocidad", tblLum.id_luminocidad_arbol);
                cmd.Parameters.AddWithValue("@idFuncion", tblFn.id_funcion_arbol);
                cmd.Parameters.AddWithValue("@estadoF", tblEst.id_estado_arbol);
                cmd.Parameters.AddWithValue("@idColorh", tblCh.id_color_hoja);
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

        public int Buscar_id_arbol(tbl_Arbol tblAr)
        {
            int id = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT * FROM tbl_Arbol WHERE nom_cient_arbol=" + tblAr.nom_cient_arbol + " AND nom_com_arbol=" + tblAr.nom_com_arbol + " AND id_especie_arbol =" + tblAr.id_especie_arbol + ";";
                //cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "prc_Buscar_id_arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", tblAr.nom_com_arbol);
                cmd.Parameters.AddWithValue("@nombreCi", tblAr.nom_cient_arbol);
                cmd.Parameters.AddWithValue("@id_especie", tblAr.id_especie_arbol);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                id = int.Parse(dr["id_arbol"].ToString());                    
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return id;

        }

        public int a(tbl_Arbol tblA)
        {
            int a = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "prc_Buscar_id_arbol";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a",tblA.nom_com_arbol);
            cmd.Parameters.AddWithValue("@nombreCi",tblA.nom_cient_arbol);
            cmd.Parameters.AddWithValue("@id_especie", tblA.id_especie_arbol);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var item in dr)
            {
                a=int.Parse(dr["id_arbol"].ToString());
                
            }
            return a;
        }

        public bool buscar_Arbol_con_nombreCientifico(tbl_Arbol tblAr)
        {
            bool existe = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_arbol_nombreCient";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCient", tblAr.nom_cient_arbol);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int id = 0;
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_arbol"].ToString());
                }
                if (id != 0) existe = true;
            }
            catch (Exception)
            {
                
                throw;
            }
            return existe;
        }

        public List<String[]> Llamar_arbol()
        {
            var lista = new List<String[]>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_tbl_Arbol";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    String desc_ave = dr["desc_arbol"].ToString();//0
                    String NombreComun = dr["nom_com_arbol"].ToString();//1
                    String NombreCientifico = dr["nom_cient_arbol"].ToString();//2
                    String EstadoArbol = dr["estado_arbol"].ToString();//3
                    String DominioArbol = dr["dominio_arbol"].ToString();//4
                    String ReinoArbol = dr["reino_arbol"].ToString();//5
                    String DivisionArbol = dr["division_arbol"].ToString();//6
                    String ClaseArbol = dr["clase_arbol"].ToString();//7
                    String OrdenArbol = dr["oreden_arbol"].ToString();//8
                    String FamiliArbol = dr["familia_arbol"].ToString();//9
                    String GeneroArbol = dr["genero_arbol"].ToString();//10
                    String EspecieArbol = dr["especie_arbol"].ToString();//11
                    String TipoArbol = dr["tipo_arbol"].ToString();//12
                    String Crecimiento = dr["crecimiento"].ToString();//13
                    String AlturaArbol = dr["altura_arbol"].ToString();//14
                    String DiametroArbol = dr["diametro_arbol"].ToString();//15
                    String AmplitudCopa = dr["amplitud_copa"].ToString();//16
                    String FormaCopa = dr["forma_copa"].ToString();//17
                    String PersistenciaHoja = dr["persistencia_hoja"].ToString();//18
                    String ColorFlor = dr["color_flor"].ToString();//19
                    String ColorHoja = dr["color_hoja"].ToString();//20
                    String EstacionFloracion = dr["estacion_de_floracion"].ToString();//21
                    String LimitacionArbol = dr["limitaciones_arbol"].ToString();//22
                    String LimitacionFruto = dr["limitaciones_fruto"].ToString();//23
                    String LongevidadArbol = dr["longevidad_arbol"].ToString();//24
                    String PisoTermico = dr["piso_termico"].ToString();//25
                    String LuminocidadArbol = dr["luminocidad_arbol"].ToString();//26
                    String FuncionArbol = dr["funcion_arbol"].ToString();//27
                    String FotoArbol = dr["foto_arbol"].ToString();//28
                    String IdArbol = dr["id_arbol"].ToString();//29
                    lista.Add(new String[] { desc_ave, NombreComun, NombreCientifico,EstadoArbol, DominioArbol,ReinoArbol,DivisionArbol ,ClaseArbol,
                        OrdenArbol,FamiliArbol,GeneroArbol,EspecieArbol,TipoArbol,Crecimiento,AlturaArbol,DiametroArbol,AmplitudCopa,FormaCopa,PersistenciaHoja,
                        ColorFlor,ColorHoja,EstacionFloracion,LimitacionArbol,LimitacionFruto,LongevidadArbol,PisoTermico,LuminocidadArbol,FuncionArbol,FotoArbol,IdArbol});
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
