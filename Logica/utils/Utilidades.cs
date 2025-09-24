using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.utils
{
    public static class Utilidades
    {
        public static String EncriptarContraseña(String value) {
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
