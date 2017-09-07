using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;
using CAD;

namespace HanaASP.Services.Registrar_ave
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Registrar_ave" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Registrar_ave.svc o Registrar_ave.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Registrar_ave : IService_Registrar_ave
    {
        public List<tbl_Dominio_ave> Dominio()
        {

            return new tbl_Dominio_aveCAD().Buscar_Dominio();
        }

        public List<tbl_Reino_ave> Reino(int id_dominio)
        {
            return new tbl_Reino_aveCAD().Buscar_Reino(id_dominio);
        }

        public List<tbl_Filum_ave> Filum(int id_reino)
        {
            return new tbl_Filum_aveCAD().Buscar_Filum(id_reino);
        }
        public List<tbl_Clase_ave> Clase(int id_filum)
        {
            return new tbl_Clase_aveCAD().Buscar_Clase(id_filum);
        }
        
        public List<tbl_Orden_ave> Orden(int id_clase)
        {
            return new tbl_Orden_aveCAD().Buscar_Orden(id_clase);
        }
        public List<tbl_Familia_ave> Familia(int id_orden)
        {
            return new tbl_Familia_aveCAD().Buscar_Familia(id_orden);
        }
        public List<tbl_Genero_Ave> Genero(int id_familia)
        {
            return new tbl_Genero_aveCAD().Buscar_Genero(id_familia);
        }

        public List<tbl_Especie_ave> Especie(int id_genero)
        {
            return new tbl_Especie_aveCAD().Buscar_Especie(id_genero);
        }

        public List<tbl_Origen_ave> Origen()
        {
            return new tbl_Origen_aveCAD().Buscar_Origen();
        }

        public List<tbl_Tipo_ave> Tipo()
        {
            return new tbl_Tipo_aveCAD().Buscar_Tipo();
        }

        public List<tbl_Clase_dieta> Clase_dieta()
        {
            return new tbl_Clase_dietaCAD().Buscar_Clase_dieta();
        }

        public List<tbl_Dieta> Dieta(int idClase_dieta)
        {
            return new tbl_DietaCAD().Buscar_Dieta(idClase_dieta);
        }

        public List<tbl_Comportamiento_ave> Comportamiento_ave()
        {
            return new tbl_Comportamiento_aveCAD().Buscar_Comportamiento_ave();
        }

        public List<tbl_Habitat_ave> Habitat_ave()
        {
            return new tbl_Habitat_aveCAD().Buscar_Habitat_ave();
        }

        public List<tbl_Reproduccion_ave> Reproduccion_ave()
        {
            return new tbl_Reproduccion_aveCAD().Buscar_Reproduccion_ave();
        }

        public List<tbl_Color_plumaje> Color_plumaje()
        {
            return new tbl_Color_plumajeCAD().Buscar_Color_plumaje();
        }

        public List<tbl_Tamaño_ave> Tamaño_ave()
        {
            return new tbl_Tamaño_aveCAD().Buscar_Tamaño_ave();
        }

        public String Buscar_ave_con_nombreCientifico(string nombreCientifico)
        {
            tbl_Ave tblAv = new tbl_Ave();
            tblAv.Nombre_cientifico = nombreCientifico;
            string mensaje;
            bool existe = new tbl_AveCAD().buscar_Ave_con_nombreCientifico(tblAv);
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


        public string Insertar_ave(string nombreComun, string nombreCientifico, string descripcion, int tipo,int clase_dieta, int dieta, int comportamiento, int habitat, int reproduccion, int origen, int especie,int color_plumaje,int tamaño_ave)
        {
            tbl_Ave tblAv = new tbl_Ave();
            tbl_Tipo_ave tblTp = new tbl_Tipo_ave();
            tbl_Clase_dieta tblCld= new tbl_Clase_dieta();
            tbl_Dieta tbldt = new tbl_Dieta();
            tbl_Comportamiento_ave tblComp = new tbl_Comportamiento_ave();
            tbl_Habitat_ave tblHab = new tbl_Habitat_ave();
            tbl_Reproduccion_ave tblRp = new tbl_Reproduccion_ave();
            tbl_Origen_ave tblOv = new tbl_Origen_ave();
            tbl_Especie_ave tblEsp= new tbl_Especie_ave();
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

            tblEst.id_Estado_ave = new tbl_Estado_aveCAD().Buscar_Estado_ave("Espera");
            return new tbl_AveCAD().insertar_ave(tblAv, tblEst, tblEsp, tblOv, tblTp, tblCld, tbldt, tblComp, tblHab, tblRp,tblCp, tblTm);
            
        }
    }
    }
