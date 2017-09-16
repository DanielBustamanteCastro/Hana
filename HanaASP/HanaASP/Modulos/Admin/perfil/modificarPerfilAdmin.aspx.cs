using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CAD;

namespace HanaASP.Modulos.Usuario
{
    public partial class Register : System.Web.UI.Page
    {
    //    tbl_UbicacionCAD tblUC = new tbl_UbicacionCAD();
    //    tbl_Ubicacion tblU = new tbl_Ubicacion();
    //    tbl_Rol tblR = new tbl_Rol();
    //    tbl_Estado_usuario tblE = new tbl_Estado_usuario();
    //    tbl_Usuario tblUs = new tbl_Usuario();
    //    tbl_UsuarioCAD tblUsC = new tbl_UsuarioCAD();
    //    tbl_Contraseña tblC = new tbl_Contraseña();
    //    tbl_Correo_electronico tblCe = new tbl_Correo_electronico();
    //    tbl_Correo_electronicoCAD tblCeC = new tbl_Correo_electronicoCAD();

        protected void Page_Load(object sender, EventArgs e)
        {
        //    ddlMunicipio.Items.Clear();
        //    List<String> Ubicacion = tblUC.Buscar_ubicacion();
        //    foreach (var item in Ubicacion)
        //    {
        //        ddlMunicipio.Items.Add(item);
        //    }
        //    txtNombre.Attributes.Add("onkeypress", "a(event)");
        }

       
        //    DateTime ahora = DateTime.Now;
        //    DateTime fecha = Convert.ToDateTime(txtFecha.Text);
        //    Boolean Dio = tblCeC.Buscar_correo(txtCorreo.Text);
        //    Boolean existe = tblCeC.Buscar_correo_guardado(txtCorreo.Text);
        //    if (existe)
        //    {
        //        if (Dio)
        //        {
        //            string script = @"<script type='text/javascript'>alert('El correo ya esta siendo usado por un usuario');</script>";
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //        }
        //        else
        //        {
        //            if (fecha >= ahora)
        //            {
        //                string script = @"<script type='text/javascript'>alert('Tu fecha de nacimiento no puede ser mayor a la fecha actual ');</script>";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //            }
        //            else
        //            {
        //                tblU.ubicacion_usuario = ddlMunicipio.SelectedValue;
        //                tblR.rol = "Usuario";
        //                tblE.estado_usuario = "Inactivo";
        //                tblUs.nombre_usuario = txtNombre.Text;
        //                tblUs.apellido_usuario = txtApellido.Text;
        //                tblUs.fecha_nacimiento = fecha;
        //                tblC.contraseña_usuario = txtContraseña.Text;
        //                tblCe.correo_electronico = txtCorreo.Text;
        //                string script = @"<script type='text/javascript'>alert('Enviamos un correo para activar tu cuenta');</script>";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //                tblCeC.Envio_correo(tblUs, tblC, tblU, tblR, tblCe, tblE);
        //                txtNombre.Text = "";
        //                txtApellido.Text = "";
        //                txtCorreo.Text = "";
        //                txtFecha.Text = DateTime.Now.ToString();
        //                txtContraseña.Text = "";
        //                txtConfrirmar.Text = "";
        //            }

        //        }
        //    }
        //    else
        //    {
        //        string script = @"<script type='text/javascript'>alert('El correo esta en espera para activar cuenta');</script>";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //    }

        }
    }
