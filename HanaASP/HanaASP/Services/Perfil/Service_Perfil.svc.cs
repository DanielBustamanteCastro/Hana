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
            return  new tbl_ContraseñaCAD().Actualizar_usuario(HttpContext.Current.Session["Correo"].ToString(),Nueva,Antigua);
        }

        public string[] Cargar_perfil()
        {
           return new tbl_UsuarioCAD().Cargar_usuario(HttpContext.Current.Session["Correo"].ToString());
        }

        public string Validar_usuario(string Contraseña, string Correo)
        {
            String Mensaje = "La contraseña no coincide con el correo, intenta nuevamente";
            tbl_Correo_electronico tblCr = new tbl_Correo_electronico();
            tblCr.correo_electronico = Correo;
            tbl_Contraseña tblC = new tbl_Contraseña();
            tblC.contraseña_usuario = Contraseña;
            String[] mensaje = new tbl_UsuarioCAD().Iniciar_sesión(tblCr,tblC);
            if (mensaje[2] != null) Mensaje = "Existe";
            return Mensaje;
        }
    }
}
