using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace HanaASP.Services.Favoritos_ave
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Favoritos_ave" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Favoritos_ave.svc o Service_Favoritos_ave.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Favoritos_ave : IService_Favoritos_ave
    {
        public string Agregar_favoritos(string nombreCientifico)
        {
            tbl_Ave tblAv = new tbl_Ave();
            tblAv.Nombre_cientifico = nombreCientifico;
            tblAv.id_Ave = new tbl_AveCAD().Buscar_id_ave_cient(tblAv);
            int idusu = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            int idAve = new tbl_AveCAD().Buscar_id_ave_cient(tblAv);

            return new tbl_Favoritos_aveCAD().agregar_ave(idAve, idusu);
        }

        public List<String[]> Cargar_favoritos()
        {
            tbl_Usuario us = new tbl_Usuario();
            us.id_usuario = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            List<String[]> list = new tbl_Favoritos_aveCAD().Buscar_ave(us.id_usuario);
            return new tbl_AveCAD().Llamar_aves_id(list);
        }

        public string Eliminar_favoritos(String nombreCientifico)
        {
            tbl_Usuario us = new tbl_Usuario();
            tbl_Ave tblAv = new tbl_Ave();
            tblAv.Nombre_cientifico = nombreCientifico;
            us.id_usuario = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            int ave = new tbl_AveCAD().Buscar_id_ave_cient(tblAv);
            return new tbl_Favoritos_aveCAD().Eliminar_ave(ave, us.id_usuario);

        }

        public string Verificar_favoritos(string nombreCientifico)
        {
            return new tbl_Favoritos_aveCAD().Validar_favoritos(nombreCientifico, HttpContext.Current.Session["Correo"].ToString());
        }
    }
}
