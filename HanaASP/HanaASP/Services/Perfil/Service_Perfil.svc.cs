using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace HanaASP.Services.Perfil
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Perfil" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Perfil.svc o Service_Perfil.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Perfil : IService_Perfil
    {
        public string Cambiar_contraseña(string Antigua, string Nueva)
        {
                String mensaje = new tbl_ContraseñaCAD().Actualizar_usuario(HttpContext.Current.Session["Correo"].ToString(),Nueva,Antigua);
                if (mensaje == "Modificado correctamente") HttpContext.Current.Session.RemoveAll();
                return mensaje;
        }

        public string[] Cargar_perfil()
        {
            try
            {
                return new tbl_UsuarioCAD().Cargar_usuario(HttpContext.Current.Session["Correo"].ToString());
            }
            catch (Exception)
            {
            
                return new String[]{"Mierda"};
            }
        }
        public string[] Cargar_perfil_m()
        {
            try
            {
                return new tbl_UsuarioCAD().Cargar_usuario_m(HttpContext.Current.Session["Correo"].ToString());
            }
            catch (Exception)
            {

                return new String[] { "Mierda" };
            }
        }

        public string Modificar_usuario(string Nombre, string Apellido, string Correo, string Fecha, string Contraseña, string Municipio)
        {
            String[] validacion = validar_usuarios(Contraseña, HttpContext.Current.Session["Correo"].ToString());
            if (validacion[2] == null) 
            {
                return "La contraseña ingresada no es la correcta";
            }
            else
            {
                tbl_Usuario tblUs = new tbl_Usuario();
                tblUs.nombre_usuario = Nombre;
                tblUs.apellido_usuario = Apellido;
                tblUs.fecha_nacimiento = Convert.ToDateTime(Fecha);
                tbl_Contraseña tblCo = new tbl_Contraseña();
                tblCo.contraseña_usuario = Contraseña;
                tbl_Ubicacion tblUb = new tbl_Ubicacion();
                tblUb.ubicacion_usuario = Municipio;
                tblUb.id_ubicacion = int.Parse(Municipio);
                tbl_Correo_electronico tblCr = new tbl_Correo_electronico();
                tblCr.correo_electronico = HttpContext.Current.Session["Correo"].ToString();
                String mensaje= new tbl_UsuarioCAD().Modificar_usuario(tblUs,tblCo,tblUb,Correo,tblCr);
                if (mensaje == "Modificado correctamente") HttpContext.Current.Session["Correo"] = Correo;
                return mensaje;
            }
        }

        public string Validar_usuario(string Contraseña, string Correo)
        {
            String Mensaje = "La contraseña no coincide con el correo, intenta nuevamente";
            String[] mensaje = validar_usuarios(Contraseña, Correo);
            if (mensaje[2] != null) Mensaje = "Existe";
            return Mensaje;
        }
        public String[] validar_usuarios(String Contraseña,string Correo)
        {
            tbl_Correo_electronico tblCr = new tbl_Correo_electronico();
            tblCr.correo_electronico = Correo;
            tbl_Contraseña tblC = new tbl_Contraseña();
            tblC.contraseña_usuario = Contraseña;
            String[] mensaje = new tbl_UsuarioCAD().Iniciar_sesión(tblCr, tblC);
            return mensaje;
        }
    }
}
