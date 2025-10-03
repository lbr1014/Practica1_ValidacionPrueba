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
        //ATRIBUTOS
        List<Usuario> UsuariosLista = new List<Usuario>();
        List<ActividadesFisicas> ActividadesFisicasLista = new List<ActividadesFisicas>();
        

        //CONSTRUCTOR
        public CapaDatos() 
        {
            
            var usuario1 = new Usuario("a-005", "Alexia", "Putellas", "balondeoro3@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 1, "NORMAL");
            var usuario2 = new Usuario("a-004", "Lando", "Norris", "norris@gmail.com", "ConMasDe12Caracteres!","HOMBRE", 68, 1.75f, 25,  1, "NORMAL");
            GuardaUsuario(usuario1);
            GuardaUsuario(usuario2);

            GuardaActividad(new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio", usuario1));
            GuardaActividad(new ActividadesFisicas("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica", usuario1));
            GuardaActividad(new ActividadesFisicas("AF-003", "Pesas", 50, "Ir al gimnasio y levantar pesas", usuario2));
           

        }  


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
            if (idElemento < 0 || idElemento >= ActividadesFisicasLista.Count)
                return null;
            return ActividadesFisicasLista[idElemento];

        }

        public Usuario LeeUsuario(string email)
        {
            return UsuariosLista.FirstOrDefault(u => u.Email == email);

        }

        public int NumActividades(String idUsuario)
        {
            return ActividadesFisicasLista
           .Count(a => a.Usuario != null && a.Usuario.IdUsuario == idUsuario);
        }

        public int NumUsuarios()
        {
            return UsuariosLista.Distinct().Count(); ;
        }

        public int NumUsuariosActivos()
        {
            return UsuariosLista.Count(u => u.obtenerEstado(u) == "ACTIVO");
        }

        public bool ValidaUsuario(string email, string password)
        {
            var usuario = UsuariosLista.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return false;

            return usuario.ComprobarContraseña(password);
        }

        public bool ActualizaUsuario(Usuario usuario)
        {
            var existente = UsuariosLista.FirstOrDefault(u => u.Email == usuario.Email);
            if (existente == null) return false;

            UsuariosLista.Remove(existente);
            UsuariosLista.Add(usuario);
            return true;
        }

        public bool ActualizaActividad(ActividadesFisicas actividad)
        {
            var existente = ActividadesFisicasLista.FirstOrDefault(a => a.IdActividad == actividad.IdActividad);
            if (existente == null) return false;

            ActividadesFisicasLista.Remove(existente);
            ActividadesFisicasLista.Add(actividad);
            return true;
        }

        public bool EliminaUsuario(string email)
        {
            var usuario = UsuariosLista.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return false;

            UsuariosLista.Remove(usuario);
            return true;
        }

        public bool EliminaActividad(string idActividad)
        {
            var actividad = ActividadesFisicasLista
        .FirstOrDefault(a => a.IdActividad == idActividad);

            if (actividad == null) return false;

            ActividadesFisicasLista.Remove(actividad);
            return true;
        }

        public List<ActividadesFisicas> ObtenerActividadesUsuario(string idUsuario)
        {
            return ActividadesFisicasLista
                .Where(a => a.Usuario != null && a.Usuario.IdUsuario == idUsuario)
                .ToList();
        }

    }
}
