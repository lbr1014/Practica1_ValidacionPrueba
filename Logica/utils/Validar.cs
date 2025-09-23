using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Prueba
namespace Logica.utils
{
    public static class Validar
    {
        public static bool NIF(string nif)
        {
            if (string.IsNullOrWhiteSpace(nif) || nif.Length != 9)
                return false;

            string numeros = nif.Substring(0, 8);
            char letra = char.ToUpper(nif[8]);

            if (!int.TryParse(numeros, out int numero))
                return false;

            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letraCorrecta = letras[numero % 23];

            return letra == letraCorrecta;
        }

        // Validación de IBAN español
        public static bool IBAN(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
                return false;

            iban = iban.Replace(" ", "").ToUpper();

            if (!Regex.IsMatch(iban, @"^ES\d{22}$"))
                return false;

            // Mover los 4 primeros caracteres al final
            string reformulado = iban.Substring(4) + iban.Substring(0, 4);

            // Convertir letras a números (A=10, B=11, ..., Z=35)
            string numerico = "";
            foreach (char c in reformulado)
            {
                if (char.IsLetter(c))
                    numerico += (c - 'A' + 10).ToString();
                else
                    numerico += c;
            }

            // Validar con módulo 97
            return Modulo97(numerico) == 1;
        }

        private static int Modulo97(string input)
        {
            string fragmento = "";
            foreach (char c in input)
            {
                fragmento += c;
                if (fragmento.Length >= 9)
                {
                    int num = int.Parse(fragmento);
                    fragmento = (num % 97).ToString();
                }
            }
            return int.Parse(fragmento) % 97;
        }

        // Validación de la contraseña
        public static bool Contrasena(string password)
        {
            int contadorMayusculas = 0;
            int contadorMinusculas = 0;
            int contadorNumeros = 0;
            int contadorCaracteresEspeciales = 0;

            if (string.IsNullOrWhiteSpace(password) || password.Length < 12) { 
                return false;
            }

            for (int i = 0; i< password.Length;i++)
            {
                char caracterContrasena = password[i];
                
                if (char.IsUpper(caracterContrasena)) {
                    contadorMayusculas++;

                } else if (char.IsLower(caracterContrasena)) {
                    contadorMinusculas++;

                } else if (char.IsDigit(caracterContrasena)) {
                    contadorNumeros++;

                }
                else {
                    contadorCaracteresEspeciales++;
                }
            }

            return contadorMayusculas >= 2 && contadorMinusculas >= 2 && contadorNumeros >= 1 && contadorCaracteresEspeciales >= 1;
        }



        //EMail
        public static bool Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) {  return false; }
                

            int arroba = email.IndexOf('@');
            if( arroba <= 0 || arroba != email.LastIndexOf('@') ) { return false; }

            string usuario =email.Substring(0, arroba);
            string dominio = email.Substring(arroba + 1);

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(dominio))
                return false;

            int puntoDominio = email.IndexOf('.');
            if (puntoDominio <= 0 || puntoDominio != dominio.Length -1 ) { return false; }

            foreach ( char c in email)
            {
                if(!(char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_')) {  return false; }
            }


            return true;

        }


    }



}
