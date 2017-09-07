using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace CAD
{

    public class tbl_UsuarioCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);
        tbl_ContraseñaCAD tblCC = new tbl_ContraseñaCAD();
        tbl_UbicacionCAD tblUC = new tbl_UbicacionCAD();
        tbl_RolCAD tblR = new tbl_RolCAD();
        tbl_Estado_usuarioCAD tblE = new tbl_Estado_usuarioCAD();
        tbl_Correo_electronicoCAD tblCR = new tbl_Correo_electronicoCAD();
        //Login
        public String[] Iniciar_sesión(tbl_Correo_electronico cr,tbl_Contraseña cn)
        {
            String[] Rol = new String[3];//Creamos un arreglo para guardar el rol, el mensaje de error y el estado del usuario
            Rol[0] = null;
            Rol[1] = null;
            Rol[2] = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT U.id_usuario,U.nombre_usuario,R.rol,C.contraseña_usuario,CR.correo_usuario,EU.estado_usuario FROM tbl_Rol AS R INNER JOIN tbl_Usuario AS U ON R.id_rol=U.id_rol INNER JOIN tbl_Contraseña AS C ON U.id_contraseña= C.id_contraseña INNER JOIN tbl_Correo_electronico AS CR ON U.id_usuario=CR.id_usuario INNER JOIN tbl_Estado_usuario AS EU ON U.id_estado_usuario=EU.id_estado_usuario  WHERE CR.correo_usuario = '"+cr.correo_electronico+"' AND C.contraseña_usuario='"+ cn.contraseña_usuario + "';";
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "prc_Buscar_Usuario";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@usuario", cr.correo_electronico);
                //cmd.Parameters.AddWithValue("@contraseña", cn.contraseña_usuario);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    Rol[0] = dr["rol"].ToString();//Si el usuario existe traeremos el rol en la posición 0
                    Rol[2] = dr["estado_usuario"].ToString();//Traemos el estado el usuario
                }
                con.Close();
            }
            catch (Exception e)
            {
                Rol[1]=e.Message;//Si existe algun error se guardara en la posición 1
            }
            return Rol;
        }

        //Registrar usuario
        public String[] Insertar_usuario(tbl_Usuario us, tbl_Contraseña cont, tbl_Ubicacion ub, tbl_Rol rol, tbl_Estado_usuario est,tbl_Correo_electronico cel)
        {
                String[] Insert = new String[2];
                Insert[0] = null;
                Insert[1] = null;
            try
            {
                int id = 0;
                int idu = 0;
                int idCn = tblCC.Insertar_Contraseña(cont.contraseña_usuario);
                int idUb = tblUC.Buscar_id(ub.ubicacion_usuario);
                int idR = tblR.Buscar_rol(rol.rol);
                int idE = tblE.Buscar_id(est.estado_usuario);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre",us.nombre_usuario);
                cmd.Parameters.AddWithValue("@apellido",us.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha",us.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idU", idUb);
                cmd.Parameters.AddWithValue("@idC", idCn);
                cmd.Parameters.AddWithValue("@idR", idR);
                cmd.Parameters.AddWithValue("@est", idE);
                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
                if (id != 0) idu = Buscar_id(us, idCn, idUb, idR);
                if (idu != 0) Insert[0] = tblCR.Insertar_correo(cel.correo_electronico, idu).ToString();
            }
            catch (Exception e)
            {

                Insert[1] = e.Message; 
            }
            return Insert;
        }

        //Buscar id usuario
        public int Buscar_id(tbl_Usuario us, int idCn, int idUb, int idR)
        {
            int id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_id_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_usuario", us.nombre_usuario);
                cmd.Parameters.AddWithValue("@apellido_usuario",us.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha",us.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idU", idUb);
                cmd.Parameters.AddWithValue("@idC", idCn);
                cmd.Parameters.AddWithValue("@idR", idR);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id=int.Parse(dr["id_usuario"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            return id;
        }



        //Buscar id usuario enviar correo
        public int Buscar_id_correo(tbl_Usuario tblU,tbl_Contraseña tblC,tbl_Ubicacion tblUb,tbl_Rol tblR, tbl_Correo_electronico tblCe )
        {
            int id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_id_usuario_correo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_usuario", tblU.nombre_usuario);
                cmd.Parameters.AddWithValue("@apellido_usuario", tblU.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha", tblU.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@ubicaion", tblUb.ubicacion_usuario);
                cmd.Parameters.AddWithValue("@contraseña", tblC.contraseña_usuario);
                cmd.Parameters.AddWithValue("@rol", tblR.rol);
                cmd.Parameters.AddWithValue("@coreo", tblCe.correo_electronico);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_usuario"].ToString());
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
