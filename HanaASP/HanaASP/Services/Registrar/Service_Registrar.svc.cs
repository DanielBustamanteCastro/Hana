using CAD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HanaASP.Services.Registrar
{
    //NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Registrar" en el código, en svc y en el archivo de configuración a la vez.
    //NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Registrar.svc o Service_Registrar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Registrar : IService_Registrar
    {
        tbl_UbicacionCAD tblUC = new tbl_UbicacionCAD();
        tbl_Ubicacion tblU = new tbl_Ubicacion();
        tbl_Rol tblR = new tbl_Rol();
        tbl_Estado_usuario tblE = new tbl_Estado_usuario();
        tbl_Usuario tblUs = new tbl_Usuario();
        tbl_UsuarioCAD tblUsC = new tbl_UsuarioCAD();
        tbl_Contraseña tblC = new tbl_Contraseña();
        tbl_Correo_electronico tblCe = new tbl_Correo_electronico();
        tbl_Correo_electronicoCAD tblCeC = new tbl_Correo_electronicoCAD();

        public List<String> Municipios()
        {
            return tblUC.Buscar_ubicacion();
        }

        public Mensajes Registrar(string Nombre, string Apellido, string Correo, string Fecha, string Contraseña, string Municipio)
        {
            DateTime ahora = DateTime.Now;
            DateTime fecha = Convert.ToDateTime(Fecha);
            Boolean Dio = tblCeC.Buscar_correo(Correo);
            Boolean existe = tblCeC.Buscar_correo_guardado(Correo);
            Mensajes Mensaje = new Mensajes();
            if (existe)
            {
                if (Dio)
                {
                    Mensaje.Mensaje = "El correo ya esta siendo usado por un usuario";
                    Mensaje.Tipo = "info";

                }
                else
                {
                    if (fecha >= ahora)
                    {
                        Mensaje.Mensaje = "Tu fecha de nacimiento no puede ser mayor a la fecha actual";
                        Mensaje.Tipo = "error";
                    }
                    else
                    {
                        tblU.ubicacion_usuario = Municipio;
                        tblR.rol = "Usuario";
                        tblE.estado_usuario = "Inactivo";
                        tblUs.nombre_usuario = Nombre;
                        tblUs.apellido_usuario = Apellido;
                        tblUs.fecha_nacimiento = fecha;
                        tblC.contraseña_usuario = Contraseña;
                        tblCe.correo_electronico = Correo;
                        Mensaje.Mensaje = "Te enviamos un correo para activar tu cuenta";
                        Mensaje.Tipo = "success";
                        tblCeC.Envio_correo(tblUs, tblC, tblU, tblR, tblCe, tblE);

                    }

                }
            }
            else
            {
                Mensaje.Mensaje = "El correo esta en espera para activar cuenta";
                Mensaje.Tipo = "info";
            }
            return Mensaje;
        }


    }
 
    }
public class Mensajes{
        public String Mensaje { get; set; }
        public String Tipo { get; set; }
    }