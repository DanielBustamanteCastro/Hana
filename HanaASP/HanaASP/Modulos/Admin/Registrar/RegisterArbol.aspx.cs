using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAD;
using DTO;

namespace HanaASP.Modulos.Admin
{
    public partial class RegisterAve : System.Web.UI.Page
    {
        tbl_Reino_arbolCAD tblRaC = new tbl_Reino_arbolCAD();
        tbl_Dominio_arbolCAD tblDaC = new tbl_Dominio_arbolCAD();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    ddlDominio.Items.Clear();
            //    List<String> Dominio = tblDaC.Buscar_Dominio();
            //    foreach (var item in Dominio)
            //    {
            //        ddlDominio.Items.Add(item);
            //    }
            //    string script = @"<script type='text/javascript'>alert('Inicio');</script>";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            //}
        }

        //protected void ddlPersistencia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string script = @"<script type='text/javascript'>alert(' "+ddlPersistencia.SelectedValue+" ');</script>";
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        //}

        //protected void ddlDominio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    List<String> Reino = tblRaC.Buscar_Reino(tblDaC.Buscar_id_Dominio(ddlDominio.SelectedValue));
        //    foreach (var item in Reino)
        //    {
        //        ddlReino.Items.Add(item);
        //    }
        //}

        //protected void ddlReino_SelectedIndexChanged(object sender, EventArgs e)
        //{
       
        //}
    }
}