using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

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
        public String[] Iniciar_sesión(tbl_Correo_electronico cr, tbl_Contraseña cn)
        {
            String[] Rol = new String[3];//Creamos un arreglo para guardar el rol, el mensaje de error y el estado del usuario
            Rol[0] = null;
            Rol[1] = null;
            Rol[2] = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT U.id_usuario,U.nombre_usuario,R.rol,C.contraseña_usuario,CR.correo_usuario,EU.estado_usuario FROM tbl_Rol AS R INNER JOIN tbl_Usuario AS U ON R.id_rol=U.id_rol INNER JOIN tbl_Contraseña AS C ON U.id_contraseña= C.id_contraseña INNER JOIN tbl_Correo_electronico AS CR ON U.id_usuario=CR.id_usuario INNER JOIN tbl_Estado_usuario AS EU ON U.id_estado_usuario=EU.id_estado_usuario  WHERE CR.correo_usuario = '" + cr.correo_electronico + "' AND C.contraseña_usuario='" + cn.contraseña_usuario + "';";
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
                Rol[1] = e.Message;//Si existe algun error se guardara en la posición 1
            }
            return Rol;
        }

        //Registrar usuario
        public String[] Insertar_usuario(tbl_Usuario us, tbl_Contraseña cont, tbl_Ubicacion ub, tbl_Rol rol, tbl_Estado_usuario est, tbl_Correo_electronico cel)
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
                cmd.Parameters.AddWithValue("@nombre", us.nombre_usuario);
                cmd.Parameters.AddWithValue("@apellido", us.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha", us.fecha_nacimiento);
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
                cmd.Parameters.AddWithValue("@apellido_usuario", us.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha", us.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idU", idUb);
                cmd.Parameters.AddWithValue("@idC", idCn);
                cmd.Parameters.AddWithValue("@idR", idR);
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



        //Buscar id usuario enviar correo
        public int Buscar_id_correo(tbl_Usuario tblU, tbl_Contraseña tblC, tbl_Ubicacion tblUb, tbl_Rol tblR, tbl_Correo_electronico tblCe)
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

        //Actualizar contraseña usuario recuperar cuenta
        public String Recuperar_Cuenta(String Contraseña, String Correo)
        {
            String Mensaje = "Error al erecuperar cuenta, intenta nuevamente";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Recuperar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", Correo);
                cmd.Parameters.AddWithValue("@contraseña", Contraseña);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0)
                {
                    Mensaje = "Hemos enviado un correo a " + Correo + ", para recuperar tu cuenta";
                    Enviar_correo_recuperacion(Correo, Contraseña);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Mensaje;
        }

        public bool Enviar_correo_recuperacion(String Correo, String Contrasela)
        {
            bool validacion = false;
            try
            {
                MailMessage Mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                String Mensaje = "Hola <br> Está es tu nueva contraseña " + Contrasela + ", ingrsa con tu contraseña para poder modificarla nuevamente";
                Mail.From = new MailAddress("hanatoshizen@gmail.com");
                Mail.To.Add(new MailAddress(Correo));
                Mail.Body = Mensaje;
                Mail.IsBodyHtml = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("hanatoshizen@gmail.com", "ADSI1129639");
                smtp.EnableSsl = true;
                smtp.Send(Mail);
                validacion = true;
            }
            catch (Exception)
            {

                throw;
            }
            return validacion;
        }
        
        public int  Buscar_id_usu(String correo)
        {
            int id= 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM tbl_Correo_electronico WHERE correo_usuario='" + correo + "'";
                cmd.CommandType = CommandType.Text;
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

        public String[] Cargar_usuario(String correo)
        {
            String[] datos = new String[8];
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT* FROM tbl_Contraseña AS C INNER JOIN tbl_Usuario AS U ON C.id_contraseña = U.id_contraseña INNER JOIN tbl_Correo_electronico AS CE ON U.id_usuario = CE.id_usuario INNER JOIN tbl_Ubicacion AS UB ON U.id_Ubicacion = UB.id_ubicacion WHERE CE.correo_usuario = '"+correo+"'";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@Correo", correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    datos = new string[] {dr["id_contraseña"].ToString(),dr["contraseña_usuario"].ToString(),dr["id_usuario"].ToString(),
                    dr["nombre_usuario"].ToString(),dr["apellido_usuario"].ToString(),Convert.ToDateTime(dr["fecha_nacimiento_usuario"].ToString()).ToString("d MMMM yyyy"),dr["id_Ubicacion"].ToString(),dr["correo_usuario"].ToString(),dr["departamento"].ToString()};
                }
            }
            catch (Exception)
            {

                throw;
            }
            return datos;
        }
        public String[] Cargar_usuario_m(String correo)
        {
            String[] datos = new String[8];
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT* FROM tbl_Contraseña AS C INNER JOIN tbl_Usuario AS U ON C.id_contraseña = U.id_contraseña INNER JOIN tbl_Correo_electronico AS CE ON U.id_usuario = CE.id_usuario INNER JOIN tbl_Ubicacion AS UB ON U.id_Ubicacion = UB.id_ubicacion WHERE CE.correo_usuario = '" + correo + "'";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@Correo", correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    datos = new string[] {dr["id_contraseña"].ToString(),dr["contraseña_usuario"].ToString(),dr["id_usuario"].ToString(),
                    dr["nombre_usuario"].ToString(),dr["apellido_usuario"].ToString(),Convert.ToDateTime(dr["fecha_nacimiento_usuario"].ToString()).ToString("yyyy-MM-dd"),dr["id_Ubicacion"].ToString(),dr["correo_usuario"].ToString(),dr["departamento"].ToString()};
                }
            }
            catch (Exception)
            {

                throw;
            }
            return datos;
        }

        public String Modificar_usuario(tbl_Usuario us, tbl_Contraseña cont, tbl_Ubicacion ub, String CorreoNuevo, tbl_Correo_electronico cel)
        {
            String Insert = "Error al modificar, intenta nuevamente";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_UPDATE_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", us.nombre_usuario);
                cmd.Parameters.AddWithValue("@apellido", us.apellido_usuario);
                cmd.Parameters.AddWithValue("@fecha", us.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idU", ub.id_ubicacion);
                cmd.Parameters.AddWithValue("@Correo", cel.correo_electronico);
                cmd.Parameters.AddWithValue("@Contraseña", cont.contraseña_usuario);
                cmd.Parameters.AddWithValue("@CorreoNuevo", CorreoNuevo);
                con.Open();
                int id = cmd.ExecuteNonQuery();
                con.Close();
                if (id != 0) Insert = "Modificado correctamente";
            }
            catch (Exception e)
            {

                throw;
            }
            return Insert;
        }

        public String Validar_sesion(String Correo)
        {
            String tblUs = "None";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM tbl_Correo_electronico AS C INNER JOIN tbl_Usuario AS U ON C.id_usuario=U.id_usuario INNER JOIN tbl_Rol AS R ON U.id_rol=R.id_rol WHERE C.correo_usuario='"+Correo+"'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    tblUs = dr["rol"].ToString();
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return tblUs;
        }

    }
}
