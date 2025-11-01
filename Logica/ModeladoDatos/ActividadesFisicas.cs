using Logica.utils;
using Microsoft.SqlServer.Server;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ModeladoDatos
{
   /*
    * Esta clase representa una actividad física realizada por un usuario.
    * Calcula y almacena información como duración (en horas), la fecha, la descripción, las calorías,
    * el metabolismo basal y MET.
    */
    public class ActividadesFisicas
    {
        /* ATRIBUTOS */
        private string idActividadFisica;
        private string nombreActividadFisica;
        private float duracion;
        private DateTime fecha;
        private string descripcion;
        private float calorias;
        private float metabolismoBasal;
        private float met;

        private Usuario usuario;

        /* CONSTRUCTORES */
        public ActividadesFisicas(string idActividadFisica, string nombreActividadFisica, float duracion, DateTime fecha, string descripcion, Usuario usuario)
        {
            /*
             * Este constructor crea una actividad física completa. 
             * Parametros:
             *      idActividadFisica: Identificador único de la actividad.
             *      nombreActividadFisica: Nombre de la actividad.
             *      duracion: Duración en minutos de la actividad.
             *      fecha:  Fecha en la que se realizó la actividad.
             *      descripcion: Breve descripción de la actividad.
             *      usuario: Usuario al que pertenece la actividad.
             * Excepciones:
             *      ArgumentException: Si la fecha es futura.
             */

            this.idActividadFisica = idActividadFisica;
            this.nombreActividadFisica = nombreActividadFisica;

            // Guardamos duración en horas.
            this.duracion = PasarAHoras(duracion);

            if (!Validar.ComprobarFecha(fecha))
                throw new ArgumentException("La fecha de la actividad no puede ser futura.");
            this.fecha = fecha;

            this.descripcion = descripcion;
            this.usuario = usuario;

            // Si hay usuario, calculamos calorías y metabolismo basal; si no, 0.
            if (usuario != null)
                this.calorias = CalcularCalorias(usuario);

            else
                this.calorias = 0;
            if (usuario != null)
                 this.metabolismoBasal = CalcularMetabolismobasal(usuario);
            else
                this.metabolismoBasal= 0;

            // MET simple en función de la duración.
            this.met = calculaMet(duracion);

        }

        public ActividadesFisicas(string idActividadFisica, Usuario usuario)
        {
            /*
             * Este constructor crea una actividad física únicamente con el id de la 
             * actividad y el del usuario. 
             * Parametros:
             *      idActividadFisica: Identificador único de la actividad.
             *      usuario: Usuario al que pertenece la actividad.
             */

            this.idActividadFisica = idActividadFisica;
            this.usuario = usuario;
        }


        /* MÉTODOS */
        public float calculaMet(float duracion)
        {
            /*
             * Este método calcula un MET aproximado en funcion de la duración dada en minutos.
             * Parametros:
             *      duracion: Duración de la actividad en minutos.
             * Returns:
             *      MET estimado.
             */

            return 10 * PasarAHoras(duracion);
        }

        public float PasarAHoras(float duracion)
        {
            /*
             * Este método convierte la duración de la actividad de minutos a horas.
             * Parametros:
             *      duracion: Duración de la actividad en minutos.
             * Returns:
             *      duración de la actividad en horas.
             */

            return duracion / 60.0f;
        }

        public static DateTime ConvertirFecha(string fechaTexto)
        {
            /*
             * Este método convierte un texto de fecha a DateTime validando el formato y el rango.
             * Parametros:
             *      fechaTexto: Texto con la fecha.
             * Returns:
             *      fecha normalizada.
             * Excepciones:
             *      ArgumentException: Si la fecha est vacía.
             *      FormatException: Si el formato no es válido.
             */

            string[] formatos = { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };

            if (string.IsNullOrWhiteSpace(fechaTexto))
                throw new ArgumentException("La fecha no puede estar vacía.", nameof(fechaTexto));

            if (!Validar.FormatoFechaValido(fechaTexto, formatos))
                throw new FormatException("Fecha inválida. Usa el formato día/mes/año (ej.: 19/09/2025).");
            
            return DateTime.ParseExact(
                fechaTexto.Trim(),
                formatos,
                CultureInfo.GetCultureInfo("es-ES"),
                DateTimeStyles.None
            ).Date;
        }
        

        public float CalcularMetabolismobasal(Usuario usuario)
        {
            /*
             * Este método calcula el metaboismo basal (MB) de un usuario.
             * Parametros:
             *      usuario: Usuario del que se toma sexo, peso, altura y edad.
             * Returns:
             *      metabolismo basal estimado (kcal/día).
             */

            var sexo = usuario.obtenerSexo(usuario);
            float peso = usuario.Peso;
            float altura = usuario.AlturaCentimetros();
            int edad = usuario.Edad;
            float mbr = 0;
            if(sexo == "MUJER")
            {
                mbr = (10 * peso) + (6.25f * usuario.AlturaCentimetros()) -( 5 * edad) - 161; 
            }
            else if (sexo == "HOMBRE")
            {
                mbr = (10 * peso) + (6.25f * usuario.AlturaCentimetros()) - (5 * edad) + 5;
            }
            else
            {
                // Si no ha indicado el sexo, se usa el promedio de fórmulas de hombre y mujer.
                mbr = (((10 * peso) + (6.25f * usuario.AlturaCentimetros()) - (5 * edad) - 161 ) + ((10 * peso) + (6.25f * usuario.AlturaCentimetros()) - (5 * edad) + 5)) / 2;
            }
            return mbr;

        }

        public float CalcularCalorias(Usuario usuario)
        {
            /*
             * Este método calcula las calorías estimadas gastadas en la actividad.
             * Parametros:
             *      usuario: Usuario del que se toma le peso para calcular las calorias.
             * Returns:
             *      calorias gasradas en la realizacion de la actividad.
             */

            calorias = this.met * usuario.Peso * this.duracion;
                
            return calorias;
        }

        /* GETS Y SETS */
        public String NombreActividad {
            /*
             * Este método get obtiene el nombre de la actividad.
             * Returns:
             *      nombre de la actividad.
             */
            get { return this.nombreActividadFisica; }

            /*
             * Este método set actualiza el nombre de la actividad.
             * Parametro:
             *      value nuevo nombre de la actividad.
             */

            set { this.nombreActividadFisica = value; } 
        }
        public float Duracion {
            /*
             * Este método get obtiene la duración de la actividad.
             * Returns:
             *      duración de la actividad.
             */

            get { return this.duracion; }

            /*
             * Este método set actualiza la duración de la actividad.
             * Parametro:
             *      value nueva duración de la actividad.
             */

            set { this.duracion = PasarAHoras( value); } 
        }

        public DateTime Fecha
        {
            /*
             * Este método get obtiene la fecha de realización de la actividad.
             * Returns:
             *      fecha de realización de la actividad.
             */

            get { return this.fecha; }

            /*
             * Este método set actualiza la fecha de realización de la actividad.
             * Parametro:
             *      value nueva fecha de realización de la actividad.
             */

            set
            {
                if (!Validar.ComprobarFecha(value))
                    throw new ArgumentException("La fecha de último inicio de sesión no puede ser futura.");
                this.fecha = value;
            }
        }

        public String Descripcion {
            /*
             * Este método get obtiene la descripción de la actividad.
             * Returns:
             *      descripción de la actividad.
             */

            get { return this.descripcion; }

            /*
             * Este método set actualiza la descripción de la actividad.
             * Parametro:
             *      value nueva descripción de la actividad.
             */

            set { this.descripcion = value; } }
        public Usuario Usuario {
            /*
             * Este método get obtiene el usuario que ha realizado la actividad.
             * Returns:
             *      usuario que ha realizado la actividad.
             */

            get { return this.usuario; }

            /*
             * Este método set actualiza el usuario que ha realizado la actividad.
             * Parametro:
             *      value nuevo usuario que ha realizado la actividad.
             */

            set { this.usuario = value; } }

        public float MET {
            /*
             * Este método get obtiene el MET.
             * Returns:
             *      MET del usuario.
             */

            get { return this.met; }

            /*
             * Este método set actualiza el MET del usuario.
             * Parametro:
             *      value nuevo MET del usuario.
             */

            set { this.met = calculaMet(value); } }

        public String IdActividad {
            /*
             * Este método get obtiene el id de la actividad.
             * Returns:
             *      idActividadFisica de la actividad.
             */

            get { return this.idActividadFisica;  }

            /*
             * Este método set actualiza el id de la actividad.
             * Parametro:
             *      value nuevo id de la actividad.
             */

            set { this.idActividadFisica = value; } }

        /* EQUALS Y HASH */
        public override bool Equals(object obj)
        {
            /*
             * Este método compara la igualdad basandose en los distintos campos de actividad.
             * Parametros:
             *      obj: Objeto a comprar.
             * Returns:
             *      true si son iguales; false en caso de que no lo sean.
             */

            return obj is ActividadesFisicas fisicas &&
                   idActividadFisica == fisicas.idActividadFisica &&
                   nombreActividadFisica == fisicas.nombreActividadFisica &&
                   duracion == fisicas.duracion &&
                   descripcion == fisicas.descripcion &&
                   NombreActividad == fisicas.NombreActividad &&
                   Duracion == fisicas.Duracion &&
                   Descripcion == fisicas.Descripcion;
        }

        public override int GetHashCode()
        {
            /*
             * Este método devuelve un código hash.
             * Returns:
             *      Código hash..
             */

            int hashCode = 1261025783;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idActividadFisica);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreActividadFisica);
            hashCode = hashCode * -1521134295 + duracion.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(descripcion);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombreActividad);
            hashCode = hashCode * -1521134295 + Duracion.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descripcion);
            return hashCode;
        }
    }
}
