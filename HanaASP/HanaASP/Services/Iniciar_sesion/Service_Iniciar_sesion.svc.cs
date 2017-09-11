using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;

namespace HanaASP.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Iniciar_sesion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Iniciar_sesion.svc o Service_Iniciar_sesion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Iniciar_sesion : IService_Iniciar_sesion
    {

        public string Iniciar_sesion(string Correo, string Contraseña)
        {
            return Iniciar(Correo, Contraseña);
        }

        public string Recuperar(string Correo)
        {
            Boolean espera = new tbl_Correo_electronicoCAD().Buscar_correo_giardado_login(Correo);
            if (espera)
            {
                return "El correo esta en espera para activacion";
            }
            else
            {
                bool existe = new tbl_Correo_electronicoCAD().Buscar_correo(Correo);
                if (existe)
                {
                    Random rdn = new Random();
                    String contra="";
                    for (int i = 0; i < 9; i++)
			{
			 int a = rdn.Next(65,126);
                       contra= contra + Convert.ToChar(a);

			}

                   return contra;
                }
                else
                {
                    return "El Correo ingresado no a sido registrado";
                }
            }
        }




        public string Iniciar(string Correo, string Contraseña)
        {
            tbl_Contraseña tbl_Contra = new tbl_Contraseña();
            tbl_Correo_electronico tbl_Correo = new tbl_Correo_electronico();
            tbl_UsuarioCAD tbl_UsuarioC = new tbl_UsuarioCAD();
            tbl_Correo_electronicoCAD tbl_CorreoCAD = new tbl_Correo_electronicoCAD();
            String script = "";
            tbl_Contra.contraseña_usuario = Contraseña;
            tbl_Correo.correo_electronico = Correo;
            String[] Rol = tbl_UsuarioC.Iniciar_sesión(tbl_Correo, tbl_Contra);//Buscamos el usuario y resivimos en un String[] el rol y/o el mensaje
            bool espera = tbl_CorreoCAD.Buscar_correo_giardado_login(Correo);//Verificamos que el correo no este ene espera
            if (espera)
            {
                script = "El correo esta en espera para su activación";

            }
            else
            {
                if (Rol[0] == null & Rol[1] != null)
                {//Si el mensaje no es null y el rol es null nos mostrara el mensaje de error
                    script = Rol[1];
                }
                if (Rol[1] == null & Rol[0] == null)
                {//Si el rol es null y el mensaje es null, mostrara el mensaje El correo y/o la contraseña son incorrectos
                    script = "El correo y/o la contraseña son incorrectos";
                }
                if (Rol[1] == null & Rol[0] != null)
                {//Si el rol no es null y el mensaje esta null, cargara en variables de session el rol, el correo y la contraseña
                    if (Rol[2].Equals("Eliminado"))
                    {
                        script = "El correo y/o la contraseña son incorrectos";
                    }
                    if (Rol[2].Equals("Activo"))
                    {//SI el usuario esta activo podra iniciar sesión correctamente
                        if (Rol[0] == "Usuario")
                        {
                            HttpContext.Current.Session["Rol"] = Rol[0];
                            HttpContext.Current.Session["Correo"] = Correo;
                            HttpContext.Current.Session["Contraseña"] = Contraseña;
                            return HttpContext.Current.Session["Rol"].ToString();
                        }
                        if (Rol[0] == "Administrador")
                        {
                            HttpContext.Current.Session["Rol"] = Rol[0];
                            HttpContext.Current.Session["Correo"] = Correo;
                            HttpContext.Current.Session["Contraseña"] = Contraseña;
                            HttpContext.Current.Response.Redirect("indexAdmin.aspx");
                        }
                    }
                    if (Rol[2].Equals("Inactivo"))
                    {//SI el usuario esta inactivo podra iniciar sesión correctamente
                        script = " El usuario esta inactivo";
                    }
                }
            }
            return script;

        }




    }
}
