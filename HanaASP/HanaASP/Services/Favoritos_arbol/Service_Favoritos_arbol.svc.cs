using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace HanaASP.Services.Favoritos_arbol
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Favoritos_arbol" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Favoritos_arbol.svc o Service_Favoritos_arbol.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Favoritos_arbol : IService_Favoritos_arbol
    {
        public string Agregar_favoritos(string nombreCientifico)
        {
            tbl_Arbol tblAr = new tbl_Arbol();
            tblAr.nom_cient_arbol = nombreCientifico;
            int idusu = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            int idAr = new tbl_ArbolCAD().Buscar_id_arbol_cient(tblAr);

            return new tbl_Favoritos_arbolCAD().agregar_arbol(idAr, idusu);
        }

        public List<string[]> Cargar_favoritos()
        {
            tbl_Usuario us = new tbl_Usuario();
            us.id_usuario = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            List<String[]> list = new tbl_Favoritos_arbolCAD().Buscar_arbol(us.id_usuario);
            return new tbl_ArbolCAD().Llamar_arbol_id(list);
        }

        
        public string Eliminar_favoritos(string nombreCientifico)
        {
            tbl_Usuario us = new tbl_Usuario();
            tbl_Arbol tblAr = new tbl_Arbol();
            tblAr.nom_cient_arbol = nombreCientifico;
            us.id_usuario = new tbl_UsuarioCAD().Buscar_id_usu(HttpContext.Current.Session["Correo"].ToString());
            int arbol = new tbl_ArbolCAD().Buscar_id_arbol_cient(tblAr);
            return new tbl_Favoritos_arbolCAD().Eliminar_arbol(arbol, us.id_usuario);
        }

        public string Validar_favoritos(string nombreCientifico)
        {
            return new tbl_Favoritos_arbolCAD().Validar_favoritos(nombreCientifico, HttpContext.Current.Session["Correo"].ToString());
        }
    }
}
