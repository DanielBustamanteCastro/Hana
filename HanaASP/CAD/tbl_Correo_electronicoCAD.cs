using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DTO;

namespace CAD
{
    public class tbl_Correo_electronicoCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Insertar Correo
        public int Insertar_correo(String correo,int idU)
        {
            int id=0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_Correo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo",correo);
                cmd.Parameters.AddWithValue("@id",idU);
                con.Open();
                id=cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            return id;
        } 


        //Buscar Correo
        public Boolean Buscar_correo(String correo)
        {
           int id=0;
           Boolean Existe = false;
           try
           {
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con;
               //cmd.CommandText = "prc_Buscar_Correo";
               //cmd.CommandType = CommandType.StoredProcedure;
               //cmd.Parameters.AddWithValue("@Correo", correo);
               cmd.CommandText = "SELECT * FROM tbl_Usuario AS U INNER JOIN tbl_Correo_electronico AS C ON U.id_usuario = C.id_usuario WHERE C.correo_usuario = '"+correo+"'";
               cmd.CommandType = CommandType.Text;
               con.Open();
               SqlDataReader dr = cmd.ExecuteReader();
               foreach (var item in dr)
               {
                   id = int.Parse(dr["id_correo"].ToString());
               }
               if (id != 0) Existe = true;
               con.Close();
           }
           catch (Exception e)
           {
               
           }
           return Existe;
        }


        //Enviar correo
        public void Envio_correo(tbl_Usuario tblUs,tbl_Contraseña tblC,tbl_Ubicacion tblUb,tbl_Rol tblR, tbl_Correo_electronico tblCe,tbl_Estado_usuario tblEs)
        {   
            try 
            {
                Guardar_registro(tblCe.correo_electronico, "Espera");
                tbl_UsuarioCAD tblCuC= new tbl_UsuarioCAD();
                tbl_ContraseñaCAD tblCC= new tbl_ContraseñaCAD();
                String Nombre=tblCC.Encriptacion(tblUs.nombre_usuario);
                String Apellido=tblCC.Encriptacion(tblUs.apellido_usuario);
                String Fecha=tblCC.Encriptacion(tblUs.fecha_nacimiento.ToString());
                String Contraseña = tblCC.Encriptacion(tblC.contraseña_usuario);
                String Ubicacion = tblCC.Encriptacion(tblUb.ubicacion_usuario);
                String Rol = tblCC.Encriptacion(tblR.rol);
                String Estado = tblCC.Encriptacion(tblEs.estado_usuario);
                String Correo = tblCC.Encriptacion(tblCe.correo_electronico);
                MailMessage Mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                String link = "http://localhost:56328/Modulos/Validacion.aspx?Nombre=" + Nombre + "&Apellido=" + Apellido + "&Fecha=" + Fecha + "&Contraseña=" + Contraseña + "&Ubicaion=" + Ubicacion + "&Rol=" + Rol + "&Estado=" + Estado + "&Correo=" + Correo;
              
                Mail.From = new MailAddress("hanatoshizen@gmail.com");
                Mail.To.Add(new MailAddress(tblCe.correo_electronico));
                Mail.Body = link;
                //Mail.IsBodyHtml = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("hanatoshizen@gmail.com", "ADSI1129639");
                smtp.EnableSsl = true;
                smtp.Send(Mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        //Guardar registro de correo
        public void Guardar_registro(String correo,String estado)
        {
            try
            {
                DateTime fecha_actual = DateTime.Now;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_tbl_Correo_registro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo",correo);
                cmd.Parameters.AddWithValue("@estado",estado);
                cmd.Parameters.AddWithValue("@fecha", fecha_actual);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }

        //Validar correo
        public String[] Validar_Corrreo(String Correo)
        {
            String[] valor = new String[2];
            valor[0] = null;
            valor[1] = null;
            try
            {
                String correoAnt="";
                int id=0;
                String estado="";
                DateTime fecha= new DateTime();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Correo_registro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", Correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    correoAnt = dr["correo_registro"].ToString();
                    id = int.Parse(dr["id_correo_registro"].ToString());
                    estado = dr["estado_correo"].ToString();
                    fecha = Convert.ToDateTime(dr["fecha_correo"]);
                }
                con.Close();
                if (estado.Equals("Espera"))
                {
                    DateTime actual = DateTime.Now;
                    TimeSpan dias = actual.Subtract(fecha);
                    if (dias.Days >= 1)
                    {
                        if (!correoAnt.Equals("") && id != 0)
                        {
                            Eliminar_correo_registrado(correoAnt, id);
                        }
                        valor[0] = "Fuera de tiempo";
                    }
                    if (dias.Days < 1)
                    {
                        if (!correoAnt.Equals("") && id != 0)
                        {
                            Eliminar_correo_registrado(correoAnt, id);
                        }
                        valor[0] = "A tiempo";

                    }
                }
                else
                {
                   
                    valor[0] = "Eliminada";
                }
            }
            catch (Exception e)
            {
                valor[1] = e.Message;
                
            }
            return valor;
        }
        public void Eliminar_correo_registrado(String correo,int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_DELETE_tbl_Correo_registro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo",correo);
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Buscar_correo_giardado_login(String Correo)
        {
            bool existe = false;
            try
            {
                int id = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Correo_registro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", Correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    id = int.Parse(dr["id_correo_registro"].ToString());
                }
                if (id != 0) existe = true;
            }
            catch (Exception)
            {
                
                throw;
            }
            return existe;
        }
        public Boolean Buscar_correo_guardado(String correo)
        {
            Boolean existe = true;
            try
            {
                String estado = "";
                int id = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_SELECT_tbl_Correo_registro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo",correo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    estado = dr["estado_correo"].ToString();
                    id = int.Parse(dr["id_correo_registro"].ToString());
                }
                con.Close();
                if (id!=0 && estado.Equals("Espera"))
                {
                    existe = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return existe;
        }
    }
}
