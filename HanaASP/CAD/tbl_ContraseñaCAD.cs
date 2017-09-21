using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace CAD
{
    public class tbl_ContraseñaCAD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

        //Inserta la contraseña en la base de datos
        public int Insertar_Contraseña(String Contra)
        {
            int id = 0;
            String codigo = Codigo().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_INSERT_Contraseña";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contra", Contra);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
                if (id != 0) id=Buscar_Contraseña(codigo);
            }
            catch (Exception)
            {
                
                throw;
            }
            return id;
        }
        //Busca la contraseña en la base de datos
        public int Buscar_Contraseña(String codigo)
        { 
            int id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Buscar_contraseña";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
	            {
                    id = int.Parse(dr["id_contraseña"].ToString());
	            }
                con.Close();
            }
            catch (Exception e)
            {
                
                throw;
            }
            return id;
        }


        public string Desencriptacion(string cipherText)
        {
            string EncryptionKey = "MEDDFPCPD7F1007";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public string Encriptacion(string clearText)
        {
            string EncryptionKey = "MEDDFPCPD7F1007";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //Codigo de incriptacion
        public int Codigo() {
            Random r = new Random((int)DateTime.Now.Ticks);
            int num = r.Next(1, 100);
            return num;
        }

        public string Actualizar_usuario(String correo,String contraN, string contraA)
        {
            String mensaje = "Error al modificar";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prc_Actualizae_contraseña";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contraseñaA", contraA);
                cmd.Parameters.AddWithValue("@contraseñaN", contraN);
                cmd.Parameters.AddWithValue("@correo", correo);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows != 0) mensaje = "Modificado correctamente";
            }
            catch (Exception)
            {

                throw;
            }
            return mensaje;
        }
    }
}
