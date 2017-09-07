using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;
using CAD;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace HanaASP.Services.Registrar_arbol
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Registrar_arbol" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Registrar_arbol.svc o Service_Registrar_arbol.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Registrar_arbol : IService_Registrar_arbol
    {

        public List<tbl_Dominio_arbol> Dominio()
        {
            return new tbl_Dominio_arbolCAD().Buscar_Dominio();
        }

        public List<tbl_Reino_arbol> Reino(int id_dominio)
        {
            return new tbl_Reino_arbolCAD().Buscar_Reino(id_dominio);
        }

        public List<tbl_Division_arbol> Division(int id_reino)
        {
            return new tbl_Division_arbolCAD().Buscar_division(id_reino);
        }

        public List<tbl_Clase_arbol> Clase(int id_division)
        {
            return new tbl_Clase_arbolCAD().Buscar_clase(id_division);
        }

        public List<tbl_Orden_arbol> Orden(int id_clase)
        {
            return new tbl_Orden_arbolCAD().Buscar_orden(id_clase);
        }
        
        public List<tbl_Familia_arbol> Familia(int id_orden)
        {
            return new tbl_Familia_arbolCAD().Buscar_familia(id_orden);
        }

        public List<tbl_Genero_arbol> Genero(int id_familia)
        {
            return new tbl_Genero_arbolCAD().Buscar_Genero(id_familia);
        }

        public List<tbl_Especie_arbol> Especie(int id_genero)
        {
            return new tbl_Especie_arbolCAD().Buscar_especie(id_genero);
        }

        public List<tbl_Tipo_arbol> Tipo()
        {
            return new tbl_Tipo_arbolCAD().Buscar_Tipo();
        }

        public List<tbl_Habito_crecimiento> Habito_crecimiento()
        {
            return new tbl_Habito_crecimientoCAD().Habito_crecimiento();
        }

        public List<tbl_Altura_arbol> Altura_arbol()
        {
            return new tbl_Altura_arbolCAD().Altura_arbol();
        }

        public List<tbl_Diametro_arbol> Diametro_arbol()
        {
            return new tbl_Diametro_arbolCAD().Diametro_arbol();
        }

        public List<tbl_Amplitud_copa> Amplitud()
        {
            return new tbl_Amplitud_copaCAD().Diametro_arbol();
        }

        public List<tbl_Forma_de_copa> Forma_copa()
        {
            return new tbl_Forma_de_copaCAD().Forma_copa(); 
        }

        public List<tbl_Persistencia_hoja> Persistencia_Hoja()
        {
            return new tbl_Persistencia_hojaCAD().Persistencia_hoja();
        }

        public List<tbl_Color_flor> Color_Flor()
        {
            return new tbl_Color_florCAD().Color_flor();
        }
        public List<tbl_Estacion_de_floracion> Estacion_floracion()
        {
            return new tbl_Estacion_de_floracionCAD().Esacion_floracion();
        }

        public List<tbl_Limitacion_arbol> Limitacion_arbol()
        {
            return new tbl_Limitacion_arbolCAD().Limitacion_arbol();
        }

        public List<tbl_Limitaciones_fruto> Limitacion_fruto()
        {
            return new tbl_Limitaciones_frutoCAD().Limitacion_fruto();
        }

        public List<tbl_Longevidad_arbol> Longevidad_arbol()
        {
            return new tbl_Longevidad_arbolCAD().longevidad_arbol();
        }

        public List<tbl_Piso_termico> Piso_termico()
        {
            return new tbl_Piso_termicoCAD().Piso_termico();
        }

        public List<tbl_Luminocidad_arbol> Luminocidad_arbol()
        {
            return new tbl_Luminocidad_arbolCAD().Luminocidad_arbol();
        }

        public List<tbl_Funcion_arbol> Funcion_arbol()
        {
            return new tbl_Funcion_arbolCAD().Funcion_arbol();
        }

        public List<tbl_Color_hoja> Color_hoja()
        {
            return new tbl_Color_hojaCAD().Buscar_color_hoja();
        }

        public string Insertar_arbol(string nombreComun, string nombreCientifico, int dominio, int reino, int division, int clase, int orden, int familia, int genero, int especie, int tipo, int habitoC, int altura, int diametro, int amplitudC, int formaC, int persistenciaH, int colorF, int estacionFl, int limitacionAr, int limitacionFru, int longevidad, int piso, int funcionA, int colorH, int luminocidad, string descripcion)
        {
            tbl_Flora tblFl = new tbl_Flora();
            tbl_Especie_arbol tblEsa = new tbl_Especie_arbol();
            tbl_Dominio_arbol tblDo = new tbl_Dominio_arbol();
            tbl_Reino_arbol tblRn = new tbl_Reino_arbol();
            tbl_Division_arbol tblDv = new tbl_Division_arbol();
            tbl_Clase_arbol tblCl = new tbl_Clase_arbol();
            tbl_Orden_arbol tblOr = new tbl_Orden_arbol();
            tbl_Familia_arbol tblFm = new tbl_Familia_arbol();
            tbl_Genero_arbol tblGn = new tbl_Genero_arbol();
            tbl_Especie_arbol tblEp = new tbl_Especie_arbol();
            tbl_Tipo_arbol tblTp = new tbl_Tipo_arbol();
            tbl_Habito_crecimiento tblHc = new tbl_Habito_crecimiento();
            tbl_Altura_arbol tblAt = new tbl_Altura_arbol();
            tbl_Diametro_arbol tblDm = new tbl_Diametro_arbol();
            tbl_Amplitud_copa tblAm = new tbl_Amplitud_copa();
            tbl_Forma_de_copa tblFr = new tbl_Forma_de_copa();
            tbl_Persistencia_hoja tblPt = new tbl_Persistencia_hoja();
            tbl_Color_flor tblCf = new tbl_Color_flor();
            tbl_Estacion_de_floracion tblEf = new tbl_Estacion_de_floracion();
            tbl_Limitacion_arbol tblLa = new tbl_Limitacion_arbol();
            tbl_Limitaciones_fruto tblLf = new tbl_Limitaciones_fruto();
            tbl_Longevidad_arbol tblLg = new tbl_Longevidad_arbol();
            tbl_Piso_termico tblPs = new tbl_Piso_termico();
            tbl_Funcion_arbol tblFn = new tbl_Funcion_arbol();
            tbl_Color_hoja tblCh = new tbl_Color_hoja();
            tbl_Luminocidad_arbol tblLum = new tbl_Luminocidad_arbol();
            tbl_Estado_arbol tblEst = new tbl_Estado_arbol();
            tblFl.nombre_comun = nombreComun;
            tblFl.nombre_cientifico = nombreCientifico;
            tblFl.descripcion_flora = descripcion;
            tblEsa.especie_arbol = "Espera";
            tblDo.id_dominio_arbol = dominio;
            tblRn.id_reino_arbol = reino;
            tblDv.id_division_arbol = division;
            tblCl.id_clase_arbol = clase;
            tblOr.id_Orden_arbol = orden;
            tblFm.id_Familia_arbol = familia;
            tblGn.id_Genero_arbol = genero;
            tblEp.id_especie_arbol = especie;
            tblTp.id_tipo_arbol = tipo;
            tblHc.id_habito_crecimiento = habitoC;
            tblAt.id_altura_arbol = altura;
            tblDm.id_diametro_arbol = diametro;
            tblAm.id_amplitud = amplitudC;
            tblFr.id_forma_copa = formaC;
            tblPt.id_persistencia_hoja = persistenciaH;
            tblCf.id_clolor_flor = colorF;
            tblEf.id_estacion_floracion = estacionFl;
            tblLa.id_limitacion_arbol = limitacionAr;
            tblLf.id_limitacioin_fruto = limitacionFru;
            tblLg.id_longevidad_arbol = longevidad;
            tblPs.id_piso_termico = piso;
            tblFn.id_funcion_arbol = funcionA;
            tblCh.id_color_hoja = colorH;
            tblLum.id_luminocidad_arbol = luminocidad;
            tblEst.id_estado_arbol = new tbl_Estado_arbolCAD().Buscar_Estado_arbol("Espera");
            return new tbl_ArbolCAD().insertar_flora(tblFl, tblEst, tblEp, tblTp, tblHc, tblAt, tblDm, tblAm, tblFr, tblPt, tblCf, tblEf, tblLa, tblLf, tblLg, tblPs, tblFn, tblCh, tblLum);
            
        }

        public string Insertar_imagen_arbol(string imagen, string nombreCientifico, string nombreComun, int especie)
        {
            tbl_Arbol tblAr = new tbl_Arbol();
            tblAr.nom_cient_arbol = nombreCientifico;
            tblAr.nom_com_arbol = nombreComun;
            tblAr.id_especie_arbol = especie;
            tbl_Fotos_arboles tblfA= new tbl_Fotos_arboles();
            tblfA.id_arbol=new tbl_ArbolCAD().Buscar_id_arbol(tblAr);
            tblfA.foto_arbol=nombreCientifico+".txt";

            string fil = HttpContext.Current.Server.MapPath(@"~/images/Fotos_Arbol/"+nombreCientifico+".txt");
            System.IO.StreamWriter file = new StreamWriter(fil);
            file.WriteLine(imagen); 
            file.Close();
            Boolean foto = System.IO.File.Exists(fil);
            string mensaje="";
            if (foto)
            {
               mensaje= new tbl_Foto_arbolesCAD().insert_foto_arboles(tblfA);
            }
            StreamReader sr = new StreamReader(fil);
            return mensaje;
            //return new tbl_Foto_arbolesCAD().insert_foto_arboles(tblfA);
        }


        public string Buscar_arbol(string nombreCientifico)
        {
            tbl_Arbol tblAr = new tbl_Arbol();
            tblAr.nom_cient_arbol= nombreCientifico;
            string mensaje;
            bool existe = new tbl_ArbolCAD().buscar_Arbol_con_nombreCientifico(tblAr);
            if (existe)
            {
                mensaje = "El árbol ya esta guardado, por favor valida la información.";
            }
            else
            {
                mensaje = "Correcto";
            }
            return mensaje;
        }
    }


}
