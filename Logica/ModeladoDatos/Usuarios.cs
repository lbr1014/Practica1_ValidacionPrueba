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

        //Constructor
        public Usuario(string idUsuario, string name, string apellidos, string email, string password, int estado, String tipoUsuario)
        {
            this.idUsuario = idUsuario;
            this.name = name;
            this.apellidos = apellidos;
            this.email = email;
            this.password = password;
            this.estado = estado;
            this.tipoUsuario = tipoUsuario;
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

        public String CambiarTipoUsuario(String tipoUsuario)
        {
            return this.tipoUsuario = tipoUsuario;
        }

        public bool ComprobarContraseña(String password)
        {
            bool contraseñaIgual = true;

            if (this.password != password)
            {
                if (contador < 3)
                {
                    contador++;
                    ComprobarContraseña(password);
                }
                else
                {
                    BloquearCuenta();
                }
                contraseñaIgual = false;
            }
            contador = 0;
            return contraseñaIgual;
        }

        public void BloquearCuenta()
        {
            this.estado = 3;
        }

        public String Nombre { get { return this.name; } set { this.name = value; } }

        public String Apellidos { get { return this.apellidos; } set { this.apellidos = value; } }

        public String Email { get { return this.email; } set { this.email = value; } }

        public String Password { set { this.password = Utilidades.EncriptarContraseña(value); } }

        public String TipoUsuario { get { return this.tipoUsuario; } set { this.tipoUsuario = value; } }



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
