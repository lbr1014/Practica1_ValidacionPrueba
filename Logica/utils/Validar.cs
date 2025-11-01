using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Prueba
namespace Logica.utils
{
    /*
    * Esta clase contiene un conjunto de validaciones para los distintos datos utilizados en la palicación.
    */
    public static class Validar
    {
        // Validación de NIF español
        public static bool NIF(string nif)
        {
            /*
             * Este método valida un NIF español, es decir, que contenga 8 dígitos y una letra al final.
             * Parametros:
             *      nif: NIF a validar.
             * Returns:
             *      true si tiene 8 dígitos y una letra correcta al final; false en caso contrario.
             */

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
            /*
             * Este método valida un IBAN español, es decir, que contenga ES más 22 dígitos aplicando la regla de módulo 97.
             * Parametros:
             *      iban: IBAN a validar.
             * Returns:
             *      true si el IABN cumple el patrón ES y el módulo 97 es 1; false en caso contrario.
             */
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
            /*
             * Este método calcula el resto de dividir la cadena entre 97, procesa el numéro por fragmentos.
             * Parametros:
             *      input: cadena numérica sin espacios.
             * Returns:
             *      el resto de dividir por 97.
             */
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
            /*
             * Este método valida una contraseña, obligando a que tenga más de 12 caracteres, al menos
             * 2 mayusculas, 2 números y 1 caracter especial.
             * Parametros:
             *      password: contraseña sin cifrar.
             * Returns:
             *      true si cumple las condiciones; false en caso contrario.
             */
            int contadorMayusculas = 0;
            int contadorMinusculas = 0;
            int contadorNumeros = 0;
            int contadorCaracteresEspeciales = 0;

            if (string.IsNullOrWhiteSpace(password) || password.Length < 12)
            {
                return false;
            }

            for (int i = 0; i < password.Length; i++)
            {
                char caracterContrasena = password[i];

                if (char.IsUpper(caracterContrasena))
                {
                    contadorMayusculas++;

                }
                else if (char.IsLower(caracterContrasena))
                {
                    contadorMinusculas++;

                }
                else if (char.IsDigit(caracterContrasena))
                {
                    contadorNumeros++;

                }
                else
                {
                    contadorCaracteresEspeciales++;
                }
            }

            return contadorMayusculas >= 2 && contadorMinusculas >= 2 && contadorNumeros >= 1 && contadorCaracteresEspeciales >= 1;
        }



        //EMail
        public static bool Email(string email)
        {
            /*
             * Este método valida un correo electronico, obligando que aparezca un dominio y el @.
             * Parametros:
             *      email: email a validar.
             * Returns:
             *      true si el email cumple las reglas; false en caso contrario.
             */
            if (string.IsNullOrWhiteSpace(email)) { return false; }


            int arroba = email.IndexOf('@');
            if (arroba <= 0 || arroba != email.LastIndexOf('@')) { return false; }

            string usuario = email.Substring(0, arroba);
            string dominio = email.Substring(arroba + 1);

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(dominio))
                return false;

            if (dominio.Contains(".."))
                return false;

            // No permite ".@" ni "@." 
            if (usuario.EndsWith(".") || dominio.StartsWith("."))
                return false;

            int puntoDominio = dominio.LastIndexOf('.');
            if (puntoDominio <= 0 || puntoDominio == dominio.Length - 1) { return false; }

            foreach (char c in email)
            {
                if (!(char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_')) { return false; }
            }


            return true;

        }

        public static bool ComprobarFecha(DateTime ultimoInicioSesion)
        {
            /*
             * Este método valida la fecha, comprobando que no sea futura.
             * Parametros:
             *      ultimoInicioSesion: fecha a validar.
             * Returns:
             *      true si la fecha es pasada; false en caso de que sea futura.
             */
            if (ultimoInicioSesion > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        // Tipo de usuario permitido: ADMIN, NORMAL, PREMIUM
        public static bool TipoUsuario(string tipo)
        {
            /*
             * Este método valida que el tipo de usuario sea uno de los permitidos.
             * Parametros:
             *      tipo: tipo del usuario en formato de texto.
             * Returns:
             *      true si el tipo es alguno de los permitidos; false en caso contrario.
             */
            if (string.IsNullOrWhiteSpace(tipo)) { return false; }
            //string t = tipo.ToUpperInvariant();
            return tipo == "ADMIN" || tipo == "NORMAL" || tipo == "PREMIUM";
        }

        // Estado permitido: 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO
        public static bool Estado(int estado)
        {
            /*
             * Este método valida que el estado de usuario sea uno de los permitidos.
             * Parametros:
             *      estado: estado del usuario.
             * Returns:
             *      true si el estado es alguno de los permitidos; false en caso contrario.
             */
            return estado == 0 || estado == 1 || estado == 2;
        }

        // Peso en kilogramos
        public static bool Peso(float kg)
        {
            /*
             * Este método valida que el peso este en kilogramos y dentro de un rango razonable.
             * Parametros:
             *      kg: peso a validar.
             * Returns:
             *      true si está dentro del rango permitido; false en caso contrario.
             */
            return kg > 0f && kg <= 500f;
        }

        // Altura en metros
        public static bool Altura(float metros)
        {
            /*
             * Este método valida que la altura este en metros y dentro de un rango razonable.
             * Parametros:
             *      metros: altura a validar.
             * Returns:
             *      true si está dentro del rango permitido; false en caso contrario.
             */
            return metros > 0f && metros <= 3.0f;
        }

        // Edad en años
        public static bool Edad(int años)
        {
            /*
             * Este método valida que la edad este dentro de un rango razonable.
             * Parametros:
             *      años: edad a validar.
             * Returns:
             *      true si está dentro del rango permitido; false en caso contrario.
             */
            return años > 0 && años <= 120f;
        }

        public static bool FormatoFechaValido(string fechaTexto, string[] formatos)
        {
            /*
             * Este método valida que la fecha este en un formato valido.
             * Parametros:
             *      fechaTexto: fecha a validar.
             *      formatos: formatos permitidos.
             * Returns:
             *      true si la fecha esta en el formato adecuado; false en caso contrario.
             */
            if (string.IsNullOrWhiteSpace(fechaTexto))
                return false;

            return DateTime.TryParseExact(
                fechaTexto.Trim(),
                formatos,
                CultureInfo.GetCultureInfo("es-ES"),
                DateTimeStyles.None,
                out _);
        }


    }



}
