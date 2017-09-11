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

namespace HanaASP.Services.Galeria_ave
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Galeria_ave" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Galeria_ave.svc o Service_Galeria_ave.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Galeria_ave : IService_Galeria_ave
    {
    

        public List<string[]> Llamar_aves()
        {
            return new tbl_AveCAD().Llamar_aves();
        }

        public List<tbl_Fotos_aves> Llamar_fotos_aves(String idAve)
        {
            tbl_Ave ar = new tbl_Ave();
            ar.id_Ave = int.Parse(idAve);
            List<tbl_Fotos_aves> listaFo = new List<tbl_Fotos_aves>();
            List<tbl_Fotos_aves> listaF = new tbl_Foto_avesCAD().Buscar_fotos_aves(ar);
            foreach (var item in listaF)
            {
                String fil = HttpContext.Current.Server.MapPath(@"~/images/Fotos_Ave/" + item.Fotos_aves);
                bool existe = File.Exists(fil);
                if (existe)
                {
                    tbl_Fotos_aves fa = new tbl_Fotos_aves();
                    StreamReader img = new StreamReader(fil);
                    string imagenes = img.ReadLine();
                    String[] arregloimg = imagenes.Split('~');
                    for (int i = 0; i < arregloimg.Length - 1; i++)
                    {
                        fa.Fotos_aves = arregloimg[i];
                        listaFo.Add(fa);
                    }
                }
            }
            return listaFo;
        }
    }
}
