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
        private int estado;
        private String tipoUsuario;
        private int contador = 0;
        private DateTime ultimoInicioSesion;

        //Constructor
        public Usuario(string idUsuario, string name, string apellidos, string email, string password, int estado, String tipoUsuario,  DateTime? ultimoInicioSesion = null)
        {
            this.idUsuario = idUsuario;
            this.name = name;
            this.apellidos = apellidos;
            this.email = email;
            this.password = Utilidades.EncriptarContraseña(password);
            this.estado = estado;
            this.tipoUsuario = tipoUsuario;
            this.ultimoInicioSesion = ultimoInicioSesion ?? DateTime.Now;
      
        }

        public Usuario(string idUsuario) {
            this.idUsuario = idUsuario;
        }

       


        public void CambiarEstado(int estado)
        {
            this.estado = estado;
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
                default:
                    estadoUsuario = "ERROR";
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
                default:
                    tipo = "ERROR";
                    break;

            }
            return tipo;
        }

        public String CambiarTipoUsuario(String tipoUsuario)
        {
            return this.tipoUsuario = tipoUsuario;
        }
        
        public bool ComprobarContraseña(String password)
        {
            bool contraseñaIgual = true;

            string candidatoHash = Utilidades.EncriptarContraseña(password);
            bool coincide = string.Equals(this.password, candidatoHash, StringComparison.Ordinal);

            if (coincide)
            {
                contador = 0;
                return contraseñaIgual;
            }

            contador++;

            if (contador >= 3)
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

        public void DesbloquearCuenta()
        {
            if (tipoUsuario == "ADMIN") {
                this.estado = 1;
            }
            
        }

        public String Nombre { get { return this.name; } set { this.name = value; } }

        public String IdUsuario { get { return this.idUsuario; } set { this.idUsuario = value; } }

        public String Apellidos { get { return this.apellidos; } set { this.apellidos = value; } }

        public String Email { get { return this.email; } set { this.email = value; } }

        public String Password { set { this.password = Utilidades.EncriptarContraseña(value); } }

        public String TipoUsuario { get { return this.tipoUsuario; } set { this.tipoUsuario = value; } }

        public DateTime UltimoInicioSesion { get { return this.ultimoInicioSesion; } set { this.ultimoInicioSesion = value; } }



        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   idUsuario == usuario.idUsuario &&
                   name == usuario.name &&
                   apellidos == usuario.apellidos &&
                   email == usuario.email &&
                   password == usuario.password;
        }

        public override int GetHashCode()
        {
            int hashCode = -818170147;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            return hashCode;
        }
    }
}
