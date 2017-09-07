using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HanaASP.Modulos
{
    public partial class Validacion : System.Web.UI.Page
    {
        tbl_UbicacionCAD tblUC = new tbl_UbicacionCAD();
        tbl_Ubicacion tblU = new tbl_Ubicacion();
        tbl_Rol tblR = new tbl_Rol();
        tbl_Estado_usuario tblE = new tbl_Estado_usuario();
        tbl_Usuario tblUs = new tbl_Usuario();
        tbl_UsuarioCAD tblUsC = new tbl_UsuarioCAD();
        tbl_Contraseña tblC = new tbl_Contraseña();
        tbl_Correo_electronico tblCe = new tbl_Correo_electronico();
        tbl_Correo_electronicoCAD tblCeC = new tbl_Correo_electronicoCAD();
        tbl_ContraseñaCAD tblCC = new tbl_ContraseñaCAD();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbnNo_Click(object sender, EventArgs e)
        {

        }

        protected void tbnSi_Click(object sender, EventArgs e)
        {

            tblCe.correo_electronico = tblCC.Desencriptacion(Request.Params["Correo"]);
            Boolean existe= tblCeC.Buscar_correo(tblCe.correo_electronico);
            if (existe)
            {
                string script = @"<script type='text/javascript'>swal('','La cuenta ya está activada','info');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                String[] valor = tblCeC.Validar_Corrreo(tblCe.correo_electronico);
                if (valor[0] != null && valor[1] == null)
                {
                    if (valor[0].Equals("A tiempo"))
                    {
                        tblUs.nombre_usuario = tblCC.Desencriptacion(Request.Params["Nombre"]);
                        tblUs.apellido_usuario = tblCC.Desencriptacion(Request.Params["Apellido"]);
                        tblUs.fecha_nacimiento = Convert.ToDateTime(tblCC.Desencriptacion(Request.Params["Fecha"]));
                        tblC.contraseña_usuario = tblCC.Desencriptacion(Request.Params["Contraseña"]);
                        tblU.ubicacion_usuario = tblCC.Desencriptacion(Request.Params["Ubicaion"]);
                        tblR.rol = tblCC.Desencriptacion(Request.Params["Estado"]);
                        tblE.estado_usuario = "Activo";
                        String[] Insertar = tblUsC.Insertar_usuario(tblUs, tblC, tblU, tblR, tblE, tblCe);
                        if (Insertar[0] == null && Insertar[1] != null)
                        {
                            string script = @"<script type='text/javascript'>swal('Upps..','" + Insertar[1] + "','error');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        }
                        if (Insertar[0] != null && Insertar[1] == null)
                        {
                            string script = @"<script type='text/javascript'>swal('','Activado correctamente','success');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        }
                    }
                    if (valor[0].Equals("Fuera de tiempo"))
                    {
                        string script = @"<script type='text/javascript'>swal('Upps..','Has sobrepasado el tiempo estimado para activar tu cuenta','error');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    if (valor[0].Equals("Eliminada"))
                    {
                        string script = @"<script type='text/javascript'>swal('','Por favor, regístrate de nuevo','info');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
                if (valor[0] == null && valor[1] != null)
                {
                    string script = @"<script type='text/javascript'>swal('Upps..','" + valor[1] + "','error');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
    }
}