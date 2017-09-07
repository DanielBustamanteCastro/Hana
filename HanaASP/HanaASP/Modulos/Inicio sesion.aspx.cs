using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CAD;

namespace HanaASP.Modulos
{
    public partial class Inicio_sesion : System.Web.UI.Page
    {
    //    tbl_Contraseña tbl_Contra = new tbl_Contraseña();
    //    tbl_Correo_electronico tbl_Correo = new tbl_Correo_electronico();
    //    tbl_UsuarioCAD tbl_UsuarioC = new tbl_UsuarioCAD();
    //    tbl_Correo_electronicoCAD tbl_CorreoCAD = new tbl_Correo_electronicoCAD();
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnIniciarS_Click(object sender, EventArgs e)
        {
            //tbl_Contra.contraseña_usuario = txtContraseña.Text;
            //tbl_Correo.correo_electronico = txtCorreo.Text;
            //String[] Rol = tbl_UsuarioC.Iniciar_sesión(tbl_Correo, tbl_Contra);//Buscamos el usuario y resivimos en un String[] el rol y/o el mensaje
            //bool espera = tbl_CorreoCAD.Buscar_correo_giardado_login(txtCorreo.Text);//Verificamos que el correo no este ene espera
            //if (espera)
            //{
            //    string script = @"<script type='text/javascript'>alert('El correo esta en espera para su activación');</script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //}
            //else
            //{
            //    if (Rol[0] == null & Rol[1] != null)
            //    {//Si el mensaje no es null y el rol es null nos mostrara el mensaje de error
            //        string script = @"<script type='text/javascript'>alert('" + Rol[1] + " ');</script>";
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //    }
            //    if (Rol[1] == null & Rol[0] == null)
            //    {//Si el rol es null y el mensaje es null, mostrara el mensaje El correo y/o la contraseña son incorrectos
            //        string script = @"<script type='text/javascript'>alert(' El correo y/o la contraseña son incorrectos ');</script>";
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //    }
            //    if (Rol[1] == null & Rol[0] != null)
            //    {//Si el rol no es null y el mensaje esta null, cargara en variables de session el rol, el correo y la contraseña
            //        if (Rol[2].Equals("Eliminado"))
            //        {
            //            string script = @"<script type='text/javascript'>alert(' El correo y/o la contraseña son incorrectos ');</script>";
            //            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //        }
            //        if (Rol[2].Equals("Activo"))
            //        {//SI el usuario esta activo podra iniciar sesión correctamente
            //            Session["Rol"] = Rol[0];
            //            Session["Correo"] = txtCorreo.Text;
            //            Session["Contraseña"] = txtContraseña.Text;
            //        }
            //        if (Rol[2].Equals("Inactivo"))
            //        {//SI el usuario esta inactivo podra iniciar sesión correctamente
            //            string script = @"<script type='text/javascript'>alert(' El usuario esta inactivo ');</script>";
            //            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //        }
            //    }
            //}


        }
    }
}