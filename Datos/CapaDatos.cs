using Logica.ModeladoDatos;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /*
    * Esta clase actua como una capa de acceso a datos en memoria, siendo esta no persistente.
    * Mantiene listas estaticas de usuarios y actividades para simular un estado persistente 
    * mientras se usa la aplicación.
    */

    public class CapaDatos : ICapaDatos
    {
        

        /* ATRIBUTOS */

        // Almacén en memoria de usuarios.
        static List<Usuario> UsuariosLista = new List<Usuario>();
        
        // Almacén en memoria de actividades.
        static List<ActividadesFisicas> ActividadesFisicasLista = new List<ActividadesFisicas>();
        

        /* CONSTRUCTOR */
        public CapaDatos() 
        {
            /*
             * Este constructor inicializa los datos de ejemplo cuando se crea la clase. 
             * Simula un estado de persistencia al contener usuarios y actividades por defecto.
             */
            if (!UsuariosLista.Any() && !ActividadesFisicasLista.Any())
            {
                var usuario1 = new Usuario("a-005", "Alexia", "Putellas", "balondeoro3@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 1, "PREMIUM");
                var usuario2 = new Usuario("a-004", "Lando", "Norris", "norris@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 68, 1.75f, 25, 1, "NORMAL");
                var usuarioAdmin = new Usuario("a-029", "Lydia Beatriz ", "Blanco Llorente", "lbbl@gmail.com", "ConMasDe12Caracteres!", "MUJER", 68, 1.75f, 25, 1, "ADMIN");

                // Usuarios iniciales
                GuardaUsuario(usuario1);
                GuardaUsuario(usuario2);
                GuardaUsuario(usuarioAdmin);

                // Actividades iniciales
                GuardaActividad(new ActividadesFisicas("AF-001", "Correr", 30, new DateTime(2025,9,19), "Correr en el gimnasio", usuario1));
                GuardaActividad(new ActividadesFisicas("AF-002", "Nadar", 40, new DateTime(2025, 8, 22), "Hacer largos en una piscina olimpica", usuario1));
                GuardaActividad(new ActividadesFisicas("AF-003", "Pesas", 50, new DateTime(2025, 7, 9), "Ir al gimnasio y levantar pesas", usuario2));

            }

        }

        /* MÉTODOS */
        public bool GuardaActividad(ActividadesFisicas e)
        {
            /*
             * Este método se encarga de guardar las nuevas actividades en la lista de actividades.
             * Parametros:
             *      e: Actividad a guardar.
             * Returns:
             *      true si se ha añadido a la lista; false si la actividad es null.
             */

            if (e == null) {return false;}
            ActividadesFisicasLista.Add(e);
            return true;
        }

        public bool GuardaUsuario(Usuario u)
        {
            /*
             * Este método se encarga de guardar los nuevos usuarios en la lista de usuarios.
             * Parametros:
             *      u: Usuarios a guardar.
             * Returns:
             *      true si se ha añadido a la lista; false si la actividad es null.
             */

            if (u == null) { return false; }
            UsuariosLista.Add(u);
            return true;
        }

        public ActividadesFisicas LeeActividad(int idElemento)
        {
            /*
             * Este método se encarga de leer actividades usando el idElemeto.
             * Parametros:
             *      idElemento: Indice de la lista.
             * Returns:
             *      la actividad si el índice es válido; nul si no lo es.
             */

            if (idElemento < 0 || idElemento >= ActividadesFisicasLista.Count)
                return null;
            return ActividadesFisicasLista[idElemento];

        }

        public Usuario LeeUsuario(string email)
        {
            /*
             * Este método se encarga de leer un usuario usando el email.
             * Parametros:
             *      email: emial que se debe buscar en la lista usuarios.
             * Returns:
             *      el usuario correspondiente al email; null si el email no existe.
             */

            return UsuariosLista.FirstOrDefault(u => u.Email == email);

        }

        public int NumActividades(String idUsuario)
        {
            /*
             * Este método devuleve el número de actividades de un determinado usuario.
             * Parametros:
             *      idUsuario: el id del usuario del que se queire saber el número de actividades.
             * Returns:
             *      el número de actividades del usuario.
             */

            return ActividadesFisicasLista
           .Count(a => a.Usuario != null && a.Usuario.IdUsuario == idUsuario);
        }

        public int NumUsuarios()
        {
            /*
             * Este método devuleve el número de usuarios distintos en la lista usuarios.
             * Returns:
             *      el número de usuarios distintos.
             */

            return UsuariosLista.Distinct().Count(); ;
        }

        public int NumUsuariosActivos()
        {
            /*
             * Este método devuleve el número de usuarios cuyo estado sea activo en la lista usuarios.
             * Returns:
             *      el número de usuarios con estado activo.
             */

            return UsuariosLista.Count(u => u.obtenerEstado(u) == "ACTIVO");
        }

        public bool ValidaUsuario(string email, string password)
        {
            /*
            * Este método valida las credenciales de un usuario, es decir, comprueba que su email
            * y contraseña coincidan.
            * Parametros:
            *      emial: el email del usaurio.
            *      password: contraseña que se debe comparar.
            * Returns:
            *      true si el email existe y la contraseña coincide con la almacenada; false en caso contrario.
            */

            var usuario = UsuariosLista.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return false;

            return usuario.ComprobarContraseña(password);
        }

        public bool ActualizaUsuario(Usuario usuario)
        {
            /*
            * Este método actualiza los datos almacenados de un usuario buscandolo por el email.
            * Parametros:
            *      usuario: el usuario con los datos actualizados.
            * Returns:
            *      true si se ha actualizado correctamente; flase si no.
            */

            var existente = UsuariosLista.FirstOrDefault(u => u.Email == usuario.Email);
            if (existente == null) return false;

            // Elimina el usuario y lo vuelve a insertar
            UsuariosLista.Remove(existente);
            UsuariosLista.Add(usuario);
            return true;
        }

        public bool ActualizaActividad(ActividadesFisicas actividad)
        {
            /*
            * Este método actualiza una actividad buscandola por su id.
            * Parametros:
            *      actividad: la actividad con los datos actualizados.
            * Returns:
            *      true si se ha actualizado correctamente; flase si no.
            */

            var existente = ActividadesFisicasLista.FirstOrDefault(a => a.IdActividad == actividad.IdActividad);
            if (existente == null) return false;

            // Elimina la actividad y la vuelve a insertar
            ActividadesFisicasLista.Remove(existente);
            ActividadesFisicasLista.Add(actividad);
            return true;
        }

        public bool EliminaUsuario(string email)
        {
            /*
            * Este método elimina un usuario buscandolo por su id.
            * Parametros:
            *      email: el email del usuario a eliminar.
            * Returns:
            *      true si se ha eliminado correctamente; flase si no existía un usario con ese email.
            */

            var usuario = UsuariosLista.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return false;

            UsuariosLista.Remove(usuario);
            return true;
        }

        public bool EliminaActividad(string idActividad)
        {
            /*
             * Este método elimina una actividad buscandola por su id.
             * Parametros:
             *      idActividad: el id de la actividad a eliminar.
             * Returns:
             *      true si se ha eliminado correctamente; flase si no existía la actividad.
             */

            var actividad = ActividadesFisicasLista.FirstOrDefault(a => a.IdActividad == idActividad);

            if (actividad == null) return false;

            ActividadesFisicasLista.Remove(actividad);
            return true;
        }

        public List<ActividadesFisicas> ObtenerActividadesUsuario(string idUsuario)
        {
            /*
            * Este método obtiene todas las actividades de un usuario concreto.
            * Parametros:
            *      idUsuario: el id del usuario propietario.
            * Returns:
            *      lista con las actividades del usuario.
            */

            return ActividadesFisicasLista
                .Where(a => a.Usuario != null && a.Usuario.IdUsuario == idUsuario)
                .ToList();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            /*
            * Este método obtiene una copia de la lista de los usuarios.
            * Returns:
            *      la lista de los usuarios.
            */

            return UsuariosLista.ToList();
        }
        public List<ActividadesFisicas> ObtenerActividades()
        {
            /*
            * Este método obtiene una copia de la lista de actividades.
            * Returns:
            *      la lista de las actividades.
            */

            return ActividadesFisicasLista.ToList();
        }

        public static void ResetDatos()
        {
            /*
            * Elimina los datos almacenados tanto de los usuarios como de las actividades.
            */

            UsuariosLista.Clear();
            ActividadesFisicasLista.Clear();
        }



    }
}
