using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace HanaASP.Services.Modificar_ave
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Modificar_ave" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Modificar_ave.svc o Service_Modificar_ave.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Modificar_ave : IService_Modificar_ave
    {
        public string[] Cargar_ave(string NombreCientifico)
        {
            tbl_Ave ave = new tbl_Ave();
            ave.Nombre_cientifico = NombreCientifico;
            HttpContext.Current.Session["ave"] = NombreCientifico;
            return  new tbl_AveCAD().Buscar_ave_nombre_cientifico(ave);
        }

        public string Modificar_ave(string nombreComun, string nombreCientifico, string descripcion, int tipo, int clase_dieta, int dieta, int comportamiento, int habitat, int reproduccion, int origen, int especie, int color_plumaje, int tamaño_ave)
        {
            tbl_Ave tblAv = new tbl_Ave();
            tbl_Ave tblAv2 = new tbl_Ave();
            tbl_Tipo_ave tblTp = new tbl_Tipo_ave();
            tbl_Clase_dieta tblCld = new tbl_Clase_dieta();
            tbl_Dieta tbldt = new tbl_Dieta();
            tbl_Comportamiento_ave tblComp = new tbl_Comportamiento_ave();
            tbl_Habitat_ave tblHab = new tbl_Habitat_ave();
            tbl_Reproduccion_ave tblRp = new tbl_Reproduccion_ave();
            tbl_Origen_ave tblOv = new tbl_Origen_ave();
            tbl_Especie_ave tblEsp = new tbl_Especie_ave();
            tbl_Estado_ave tblEst = new tbl_Estado_ave();
            tbl_Tamaño_ave tblTm = new tbl_Tamaño_ave();
            tbl_Color_plumaje tblCp = new tbl_Color_plumaje();
            tblAv.Nombre_cientifico = nombreCientifico;
            tblAv.Nombre_comun = nombreComun;
            tblAv.Descripcion = descripcion;
            tblTp.id_Tipo_ave = tipo;
            tblCld.id_Clase_dieta = clase_dieta;
            tbldt.id_Dieta = dieta;
            tblComp.id_Comportamiento_ave = comportamiento;
            tblHab.id_Habitat_ave = habitat;
            tblRp.id_Reproduccion_ave = reproduccion;
            tblOv.id_Origen_ave = origen;
            tblEsp.id_Especie_ave = especie;
            tblTm.id_Tamaño_ave = tamaño_ave;
            tblCp.id_Color_plumaje = color_plumaje;
            tblAv2.Nombre_cientifico = HttpContext.Current.Session["ave"].ToString();
            tblEst.id_Estado_ave = new tbl_Estado_aveCAD().Buscar_Estado_ave("Espera");
            tblAv.id_Ave = new tbl_AveCAD().Buscar_id_ave_cient(tblAv2);
            return new tbl_AveCAD().Modificar_ave(tblAv, tblEst, tblEsp, tblOv, tblTp, tblCld, tbldt, tblComp, tblHab, tblRp, tblCp, tblTm);
        }
        public string Modificar_foto_ave(String imagen)
        {
            tbl_Ave tblAv = new tbl_Ave();
            tblAv.Nombre_cientifico = HttpContext.Current.Session["ave"].ToString();
            tbl_Fotos_aves tblfA = new tbl_Fotos_aves();
            Random rn = new Random();
            tblfA.id_Aves = new tbl_AveCAD().Buscar_id_ave_cient(tblAv);
            tblfA.Fotos_aves = tblAv.Nombre_cientifico + rn.Next(1,9999)+".txt";
            string fil = HttpContext.Current.Server.MapPath(@"~/images/Fotos_Ave/" + tblfA.Fotos_aves);
            StreamWriter file = new StreamWriter(fil);
            file.WriteLine(imagen);
            file.Close();
            Boolean foto = System.IO.File.Exists(fil);
            string mensaje = "";
            if (foto)
            {
                mensaje = new tbl_Foto_avesCAD().Modificar_foto_aves(tblfA);
            }
            return mensaje;

        }
    }
}
