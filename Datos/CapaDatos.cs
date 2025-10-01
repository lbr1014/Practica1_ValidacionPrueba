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
        List<Usuario> UsuariosLista = new List<Usuario>();
        List<ActividadesFisicas> ActividadesFisicasLista = new List<ActividadesFisicas>();
        public bool GuardaActividad(ActividadesFisicas e)
        {
            if (e == null) {return false;}
            ActividadesFisicasLista.Add(e);
            return true;
        }

        public bool GuardaUsuario(Usuario u)
        {
            if (u == null) { return false; }
            UsuariosLista.Add(u);
            return true;
        }

        public ActividadesFisicas LeeActividad(int idElemento)
        {
            throw new NotImplementedException();
        }

        public Usuario LeeUsuario(string email)
        {
            throw new NotImplementedException();
        }

        public int NumActividades(String idUsuario)
        {
            return ActividadesFisicasLista
           .Count(a => a.Usuario != null && a.Usuario.IdUsuario == idUsuario);
        }

        public int NumUsuarios()
        {
            return UsuariosLista.Count; ;
        }

        public int NumUsuariosActivos()
        {
            return UsuariosLista.Count(u => u.obtenerEstado(u) == "ACTIVO");
        }

        public bool ValidaUsuario(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
