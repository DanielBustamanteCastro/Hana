using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
            return  new tbl_AveCAD().Buscar_ave_nombre_cientifico(ave);
        }
        
    }
}
