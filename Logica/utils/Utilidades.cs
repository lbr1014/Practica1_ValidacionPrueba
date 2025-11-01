using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.utils
{
    /*
    * Esta clase contiene utilidades generales para la aplicación.
    */
    public static class Utilidades
    {
        public static String EncriptarContraseña(String value) {
            /*
             * Este método calcula el hash SHA-256 de una contraseña pasada como testo 
             * y lo convierte en formato hexadecimal en minúsculas.
             * Parametros:
             *      value: COntraseña en formato texto sin cifrar.
             * Returns:
             *      ContraseñaCifrada como cadena hexadecimal de 64 caracteres que se corresponde 
             *      con el hash SHA-256 de la contraseña sin cifrar.
             */

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convertir hash a string hexadecimal
                StringBuilder ContraseñaCifrada = new StringBuilder();
                foreach (byte b in hash)
                {
                    ContraseñaCifrada.Append(b.ToString("x2")); // formato hexadecimal
                }
                return ContraseñaCifrada.ToString();
            }
        }
    }
}
