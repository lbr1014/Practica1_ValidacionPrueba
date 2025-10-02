using Logica.utils;
using Practica1.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.ModeladoDatos
{
    public class Usuario
    {
        //Atributos
        private string idUsuario;
        private string name;
        private string apellidos;
        private string email;
        private string password;    
        private int estado;              // 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO
        private String tipoUsuario;     // ADMIN | NORMAL | PREMIUM
        private String sexo;           // HOMBRE | MUJER | OTRO
        private float peso;
        private float altura;
        private int edad;

        private DateTime ultimoInicioSesion;
        private int contador = 0;

        

        //Constructor
        public Usuario(string idUsuario, string name, string apellidos, string email, string password, string sexo, float peso, float altura, int edad, int estado = 1, string tipoUsuario = "NORMAL",  DateTime? ultimoInicioSesion = null)
        {
            this.idUsuario = idUsuario;
            this.name = name;
            this.apellidos = apellidos;

            if (!Validar.Email(email))
                throw new ArgumentException("Email inválido.");
            this.email = email;

            if (!Validar.Contrasena(password))
                throw new ArgumentException("La contraseña no cumple la política (mín. 12, 2 mayús., 2 minús., 1 dígito, 1 especial).");
            this.password = Utilidades.EncriptarContraseña(password);

            if (!Validar.Estado(estado))
                throw new ArgumentException("Estado inválido. 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO.");
            this.estado = estado;

            if (!Validar.TipoUsuario(tipoUsuario))
                throw new ArgumentException("Tipo de usuario inválido. Valores permitidos: ADMIN, NORMAL, PREMIUM.");
            this.tipoUsuario = tipoUsuario;


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

            this.edad = edad;

            DateTime posiblefecha = ultimoInicioSesion ?? DateTime.Now;
            if (!Validar.UltimoInicioSesion(posiblefecha))
                throw new ArgumentException("La fecha de último inicio de sesión no puede ser futura.");
            this.UltimoInicioSesion = posiblefecha;

        }

        public Usuario(string idUsuario) {
            this.idUsuario = idUsuario;
        }

       


        public string obtenerEstado(Usuario usuario)

        {   estado= usuario.estado;
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
            bool contraseñaIgual = true;

            string candidatoHash = Utilidades.EncriptarContraseña(password);
            bool coincide = string.Equals(this.password, candidatoHash, StringComparison.Ordinal);

            if (coincide)
            {
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
            this.estado = 2;
        }

        public void DesbloquearCuenta(Usuario usuario)
        {
            if (this.tipoUsuario == "ADMIN") {
                usuario.estado = 1;
                usuario.contador = 0;
            }
            
        }

        public float AlturaCentimetros()
        {
            return altura * 100f;;
        }



        public String Nombre { get { return this.name; } set { this.name = value; } }

        public String IdUsuario { get { return this.idUsuario; } set { this.idUsuario = value; } }

        public String Apellidos { get { return this.apellidos; } set { this.apellidos = value; } }

        public String Email 
        {
            get { return this.email; }
            set 
            {
                if (!Validar.Email(value))
                    throw new ArgumentException("Email inválido.");
                this.email = value; 
            } 
        }

        public String Password 
        { 
            set 
            {
                if (!Validar.Contrasena(value))
                    throw new ArgumentException("La contraseña no cumple la política (mín. 12, 2 mayús., 2 minús., 1 dígito, 1 especial).");
                this.password = Utilidades.EncriptarContraseña(value);
            }
        }

        public String TipoUsuario
        {
            set 
            {
                if (!Validar.TipoUsuario(value))
                    throw new ArgumentException("Tipo de usuario inválido. Valores permitidos: ADMIN, NORMAL, PREMIUM.");
                this.tipoUsuario = value; 
            } 
        }

        public int Estado 
        {
            set 
            {
                if (!Validar.Estado(value))
                    throw new ArgumentException("Estado inválido. 0=INACTIVO, 1=ACTIVO, 2=BLOQUEADO.");
                this.estado = value;
            }
        }

        public String Sexo 
        { 
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
            get { return this.peso; } 
            set 
            {
                if(!Validar.Peso(value))
                    throw new ArgumentException("El peso debe estar en kilogramos.");
                this.peso = value;
            } 
        }

        public int Edad { get { return this.edad; } set { this.edad = value; } }

        public float Altura 
        { 
            get { return this.altura; } 
            set 
            {
                if (!Validar.Altura(value))
                    throw new ArgumentException("La altura debe estar en metros.");
                this.altura = value;
            }
        }

        public DateTime UltimoInicioSesion
        { 
            get { return this.ultimoInicioSesion; } 
            set 
            {
                if (!Validar.UltimoInicioSesion(value))
                    throw new ArgumentException("La fecha de último inicio de sesión no puede ser futura.");
                this.ultimoInicioSesion = value;
            }
        }



        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   idUsuario == usuario.idUsuario &&
                   email == usuario.email &&
                   password == usuario.password;
        }

        public override int GetHashCode()
        {
            int hashCode = -818170147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            return hashCode;
        }
    }
}
