using Logica.ModeladoDatos;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CapaDatos : ICapaDatos
    {
        //Comentario
        List<Usuario> idUsuarios = new List<Usuario>();
        public bool GuardaActividad(ActividadesFisicas e)
        {
            throw new NotImplementedException();
        }

        public bool GuardaUsuario(Usuario u)
        {
            throw new NotImplementedException();
        }

        public ActividadesFisicas LeeActividad(int idElemento)
        {
            throw new NotImplementedException();
        }

        public Usuario LeeUsuario(string email)
        {
            throw new NotImplementedException();
        }

        public int NumActividades(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public int NumUsuarios()
        {
            throw new NotImplementedException();
        }

        public int NumUsuariosActivos()
        {
            throw new NotImplementedException();
        }

        public bool ValidaUsuario(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
