using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HanaASP.Services.Modificar_ave
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService_Modificar_ave" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService_Modificar_ave
    {

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string[] Cargar_ave(string NombreCientifico);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string Modificar_ave(String nombreComun, String nombreCientifico, String descripcion, int tipo, int clase_dieta, int dieta, int comportamiento, int habitat, int reproduccion, int origen, int especie, int color_plumaje, int tamaño_ave);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string Modificar_foto_ave(String imagen);

    }
}
