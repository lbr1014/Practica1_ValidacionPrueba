using Logica.utils;
using Practica1.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.ModeladoDatos
{
    /*
      * Esta clase representa un usuario. El cual incluye información propia del usuario, credenciales,
      * estado y tipo de la cuenta.
      */
    public class Usuario
    {
        /* ATRIBUTOS */
        private string idUsuario;
        private string name;
        private string apellidos;
        private string email;
        private string password;       // Almacenado como hash
        private int estado;            // 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO
        private String tipoUsuario;    // ADMIN | NORMAL | PREMIUM
        private String sexo;           // HOMBRE | MUJER | OTRO
        private float peso;            // kg
        private float altura;          // metros
        private int edad;              // años

        private DateTime inicioSesionActual;
        private DateTime ultimoInicioSesion;

        // Contador de intentos fallidos de login consecutivos
        private int contador = 0;



        /* CONSTRUCTORES */
        public Usuario(string idUsuario, string name, string apellidos, string email, string password, string sexo, float peso, float altura, int edad, int estado = 1, string tipoUsuario = "NORMAL")
        {
            /*
             * Este constructor crea un usuario completo. 
             * Parametros:
             *      idUsuario: Identificador único del usuario.
             *      name: Nombre del usuario.
             *      apellidos: Apellidos del usuario.
             *      email:  Email único del usuario.
             *      password: Contraseña del usuario.
             *      sexo: Sexo del usuario, puede ser HOMBRE, MUJER, OTRO.
             *      peso: Peso del usuario en kilogramos.
             *      altura: ALtura del usuario en metros
             *      edad: Edad del usuario en años.
             *      estado: Estad de la cuenta del usuario, puede estar 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO.
             *      tipoUsuario: El tipo de usuario puede ser ADMIN, NORMAL o PREMIUM, por defecto es NORMAL.
             * Excepciones:
             *      ArgumentException: Si algún dato no cumple su validación.
             */

            this.idUsuario = idUsuario;
            this.name = name;
            this.apellidos = apellidos;

            if (!Validar.Email(email))
                throw new ArgumentException("Email inválido.");
            this.email = email;

            if (!Validar.Contrasena(password))
                throw new ArgumentException("La contraseña no cumple la política (mín. 12, 2 mayús., 2 minús., 1 dígito, 1 especial).");
            // Se almacena el hash, nunca la contraseña en claro
            this.password = Utilidades.EncriptarContraseña(password);

            if (!Validar.Estado(estado))
                throw new ArgumentException("Estado inválido. 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO.");
            this.estado = estado;

            if (!Validar.TipoUsuario(tipoUsuario))
                throw new ArgumentException("Tipo de usuario inválido. Valores permitidos: ADMIN, NORMAL, PREMIUM.");
            this.tipoUsuario = tipoUsuario;

            // Normalización de sexo
            if (sexo == "HOMBRE" || sexo == "MUJER")
            {
                this.sexo = sexo;
            }
            else
            {
                this.sexo = "OTRO";
            }

            if (!Validar.Peso(peso))
                throw new ArgumentException("El peso debe estar en kilogramos.");
            this.peso = peso;

            if (!Validar.Altura(altura))
                throw new ArgumentException("La altura debe estar en metros.");
            this.altura = altura;

            if (!Validar.Edad(edad))
                throw new ArgumentException("La edad debe estar entre 1 y 120 años.");
            this.edad = edad;

            
        }

        public Usuario(string idUsuario) {
            /*
             * Este constructor crea un usuario únicamente con su idnetificador. 
             * Parametros:
             *      idUsuario: Identificador único del usuario.
             */
            this.idUsuario = idUsuario;
        }

        /* MÉTODOS */
        public string obtenerEstado(Usuario usuario)
        {
            /*
             * Este método obtiene el estado del usaurio, puede ser INACTIVO, ACTIVO Y BLOQUEADO.
             * Parametros:
             *      usuario: Usuario del que se obtiene el estado.
             * Returns:
             *      cadena con el esatdo del usuario.
             */
            estado = usuario.estado;
            String estadoUsuario = "";
            switch (estado)
            {
                case 0:
                    estadoUsuario = "INACTIVO";
                    break;
                case 1:
                    estadoUsuario = "ACTIVO";
                    break;
                case 2:
                    estadoUsuario = "BLOQUEADO";
                    break;


            }
            return estadoUsuario;
        }

        public String ObtenerTipoUsuario(Usuario usuario)
        {
            /*
             * Este método obtiene el tipo del usaurio, puede ser ADMIN, NORMAL o PREMIUM.
             * Parametros:
             *      usuario: Usuario del que se obtiene el tipo.
             * Returns:
             *      tipo del usuario.
             */

            tipoUsuario = usuario.tipoUsuario;
            String tipo = "";
            switch (tipoUsuario)
            {
                case "ADMIN":
                    tipo = "ADMIN";
                    break;
                case "NORMAL":
                    tipo = "NORMAL";
                    break;
                case "PREMIUM":
                    tipo = "PREMIUM";
                    break;

            }
            return tipo;
        }

        public string obtenerSexo(Usuario usuario)
        {
            /*
             * Este método obtiene el sexo del usaurio, puede ser MUJER, HOMBRE Y OTRO.
             * Parametros:
             *      usuario: Usuario del que se obtiene el sexo.
             * Returns:
             *      sexoUsuario con el sexo del usuario.
             */

            sexo = usuario.sexo;
            String sexoUsuario = "";
            switch (sexo)
            {
                case "HOMBRE":
                    sexoUsuario = "HOMBRE";
                    break;
                case "MUJER":
                    sexoUsuario = "MUJER";
                    break;
                
                default:
                    sexoUsuario = "OTRO";
                    break;

            }
            return sexoUsuario;
        }

        public bool ComprobarContraseña(String password)
        {
            /*
             * Este método comprueba el hash de una contraseña candita con la almacenada.
             * Si falla, incrementa un contador de intentos, tras tres fallso bloqeua la cuenta
             * del usuario.
             * Parametros:
             *      password: Contraseña candidata.
             * Returns:
             *      true si ambas contraseñas coinciden; false si no lo hacen.
             */

            bool contraseñaIgual = true;

            string candidatoHash = Utilidades.EncriptarContraseña(password);
            bool coincide = string.Equals(this.password, candidatoHash, StringComparison.Ordinal);

            if (coincide)
            {
                // reinicia contador de fallos
                this.contador = 0;
                return contraseñaIgual;
            }

            this.contador++;

            if (this.contador >= 3)
            {
                BloquearCuenta();
            }
            contraseñaIgual = false;
            return contraseñaIgual;


        }

        public void BloquearCuenta()
        {
            /*
             * Este método bloquea la cuenta del usuario.
             */
            this.estado = 2;
        }

        public void DesbloquearCuenta(Usuario usuario)
        {
            /*
             * Este método permite a un ADMIN desbloquear la cuenta del usuario.
             * Parametros:
             *      usuario: Usuario bloqueado.
             */
            if (this.tipoUsuario == "ADMIN") {
                usuario.estado = 1;

                // reinicia contador de fallos
                usuario.contador = 0;
            }
            
        }

        public float AlturaCentimetros()
        {
            /*
             * Este método pasa la altura de metros a centimetros
             * Returns:
             *      altura en centrimetros.
             */
            return altura * 100f;;
        }

        public void CambioUltimoInicioSesion()
        {
            /*
             * Este método actualiza la fecha del último inicio de sesión, cambiandolo al actual.
             */
            this.ultimoInicioSesion = this.inicioSesionActual;
        }

        /* GETS Y SETS */
        public String Nombre {
            /*
             * Este método get obtiene el nombre del usuario.
             * Returns:
             *      nombre del usuario.
             */

            get { return this.name; }
            /*
             * Este método set actualiza el nombre del usuario.
             * Parametro:
             *      value nuevo nombre del usuario.
             */
            set { this.name = value; } }

        public String IdUsuario {
            /*
             * Este método get obtiene el id del usuario.
             * Returns:
             *      idUsuario del usuario.
             */

            get { return this.idUsuario; }
            /*
             * Este método set actualiza el idUsuario del usuario.
             * Parametro:
             *      value nuevo idUsuario del usuario.
             */
            set { this.idUsuario = value; } }

        public String Apellidos {
            /*
             * Este método get obtiene los apellidos del usuario.
             * Returns:
             *      apellidos del usuario.
             */

            get { return this.apellidos; }
            /*
             * Este método set actualiza los apellidos del usuario.
             * Parametro:
             *      value nuevos apellidos del usuario.
             */
            set { this.apellidos = value; } }

        public String Email 
        {
            /*
             * Este método get obtiene el email del usuario.
             * Returns:
             *      email del usuario.
             */

            get { return this.email; }
            /*
             * Este método set actualiza el email del usuario.
             * Parametro:
             *      value nuevo email del usuario.
             */
            set
            {
                if (!Validar.Email(value))
                    throw new ArgumentException("Email inválido.");
                this.email = value; 
            } 
        }

        public String Password 
        {
            /*
             * Este método set actualiza la contraseña del usuario.
             * Parametro:
             *      value nuevo password del usuario.
             */
            set
            {
                if (!Validar.Contrasena(value))
                    throw new ArgumentException("La contraseña no cumple la política (mín. 12, 2 mayús., 2 minús., 1 dígito, 1 especial).");
                this.password = Utilidades.EncriptarContraseña(value);
            }
        }

        public String TipoUsuario
        {
            /*
             * Este método set actualiza el tipo del usuario.
             * Parametro:
             *      value nuevo tipoUsuario del usuario.
             */
            set
            {
                if (!Validar.TipoUsuario(value))
                    throw new ArgumentException("Tipo de usuario inválido. Valores permitidos: ADMIN, NORMAL, PREMIUM.");
                this.tipoUsuario = value; 
            } 
        }

        public int Estado 
        {
            /*
             * Este método set actualiza el esatdo del usuario.
             * Parametro:
             *      value nuevo estado del usuario.
             */
            set
            {
                if (!Validar.Estado(value))
                    throw new ArgumentException("Estado inválido. 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO.");
                this.estado = value;
            }
        }

        public String Sexo 
        {
            /*
             * Este método set actualiza el sexo del usuario.
             * Parametro:
             *      value nuevo sexo del usuario.
             */
            set
            {
                if (value == "HOMBRE" || value == "MUJER")
                {
                    this.sexo = value;
                }
                else
                {
                    this.sexo = "OTRO";
                }

            } 
        }

        public float Peso 
        {
            /*
             * Este método get obtiene el peso del usuario.
             * Returns:
             *      peso del usuario.
             */

            get { return this.peso; }
            /*
             * Este método set actualiza el peso del usuario.
             * Parametro:
             *      value nuevo peso del usuario.
             */
            set
            {
                if(!Validar.Peso(value))
                    throw new ArgumentException("El peso debe estar en kilogramos.");
                this.peso = value;
            } 
        }

        public int Edad {
            /*
             * Este método get obtiene la edad del usuario.
             * Returns:
             *      edad del usuario.
             */

            get { return this.edad; }
            /*
             * Este método set actualiza la edad del usuario.
             * Parametro:
             *      value nueva edad del usuario.
             */
            set
            {
                if (!Validar.Edad(value))
                    throw new ArgumentException("La edad debe estar entre 1 y 120 años.");
                this.edad = value;
            } 
        }

        public float Altura 
        {
            /*
             * Este método get obtiene la altura del usuario.
             * Returns:
             *      altura del usuario.
             */

            get { return this.altura; }
            /*
             * Este método set actualiza la altura del usuario.
             * Parametro:
             *      value nueva altura del usuario.
             */
            set
            {
                if (!Validar.Altura(value))
                    throw new ArgumentException("La altura debe estar en metros.");
                this.altura = value;
            }
        }

        public DateTime InicioSesionActual
        {
            /*
             * Este método get obtiene el inicio de sesión actual del usuario.
             * Returns:
             *      inicioSesionActual del usuario.
             */
            get { return this.inicioSesionActual; }
            /*
             * Este método set actualiza el inicio de sesión actual del usuario.
             * Parametro:
             *      value nuevo inicioSesiónActual del usuario.
             */
            set
            {
                if (!Validar.ComprobarFecha(value))
                    throw new ArgumentException("La fecha de último inicio de sesión no puede ser futura.");
                this.inicioSesionActual = value;
            }
        }

        public DateTime UltimoInicioSesion
        {
            /*
             * Este método get obtiene el último inicio de sesión del usuario.
             * Returns:
             *      ultimoInicioSesion del usuario.
             */

            get { return this.ultimoInicioSesion; }
            /*
             * Este método set actualiza el ultimo inicio sesión del usuario.
             * Parametro:
             *      value nuevo UltimoInicioSesion del usuario.
             */
            set
            {
                if (!Validar.ComprobarFecha(value))
                    throw new ArgumentException("La fecha de último inicio de sesión no puede ser futura.");
                this.ultimoInicioSesion = value;
            }
        }

        /* EQUALS Y HASH */
        public override bool Equals(object obj)
        {
            /*
             * Este método compara la igualdad basandose en el id, el email y la contraseña.
             * Parametros:
             *      obj: Objeto a comprar.
             * Returns:
             *      true si son iguales; false en caso de que no lo sean.
             */


            return obj is Usuario usuario &&
                   idUsuario == usuario.idUsuario &&
                   email == usuario.email &&
                   password == usuario.password;
        }

        public override int GetHashCode()
        {
            /*
             * Este método devuelve un código hash.
             * Returns:
             *      Código hash..
             */

            int hashCode = -818170147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            return hashCode;
        }
    }
}
