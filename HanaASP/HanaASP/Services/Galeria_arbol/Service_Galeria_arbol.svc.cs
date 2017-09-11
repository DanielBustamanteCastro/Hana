using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CAD;
using DTO;
using System.Web;
using System.IO;

namespace HanaASP.Services.Galeria_arbol
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Galeria_arbol" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Galeria_arbol.svc o Service_Galeria_arbol.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Galeria_arbol : IService_Galeria_arbol
    {


        public List<string[]> Llamar_arboles()
        {
            return new tbl_ArbolCAD().Llamar_arbol();
        }

        public List<tbl_Fotos_arboles> Llamar_fotos_arboles(String idArbol)
        {
            tbl_Arbol ar = new tbl_Arbol();
            ar.id_arbol = int.Parse(idArbol);
            List<tbl_Fotos_arboles> listaFo = new List<tbl_Fotos_arboles>();
            List<tbl_Fotos_arboles> listaF = new tbl_Foto_arbolesCAD().Buscar_fotos(ar);
            foreach (var item in listaF)
            {
                String fil = HttpContext.Current.Server.MapPath(@"~/images/Fotos_Arbol/" + item.foto_arbol);
                bool existe = File.Exists(fil);
                if (existe)
                {
                    tbl_Fotos_arboles fa = new tbl_Fotos_arboles();
                    StreamReader img = new StreamReader(fil);
                    string imagenes = img.ReadLine();
                    String[] arregloimg = imagenes.Split('~');
                    for (int i = 0; i < arregloimg.Length - 1; i++)
                    {
                        fa.foto_arbol = arregloimg[i];
                        listaFo.Add(fa);
                    }
                }
            }
            return listaFo;
        }
    }
}
