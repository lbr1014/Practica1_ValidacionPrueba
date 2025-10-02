using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ModeladoDatos
{
    public class ActividadesFisicas
    {
        private string idActividadFisica;
        private string nombreActividadFisica;
        private float duracion;
        private string descripcion;
        private float calorias;
        private float metabolismoBasal;
        private float met;

        private Usuario usuario;
        

        public ActividadesFisicas(string idActividadFisica, string nombreActividadFisica, float duracion, string descripcion, Usuario usuario)
        {
            this.idActividadFisica = idActividadFisica;
            this.nombreActividadFisica = nombreActividadFisica;
            this.duracion = PasarAHoras(duracion);
            this.descripcion = descripcion;
            this.usuario = usuario;
            calorias = CalcularCalorias(usuario);
            metabolismoBasal = CalcularMetabolismobasal(usuario);
            this.met = calculaMet(duracion);

        }

        public float calculaMet(float duracion)
        {
            return 10 * PasarAHoras(duracion);
        }

        public float PasarAHoras(float duracion)
        {
            return duracion / 60.0f;
        }
        public ActividadesFisicas(string idActividadFisica, Usuario usuario)
        {
            this.idActividadFisica = idActividadFisica;
            this.usuario = usuario;
        }

        public float CalcularMetabolismobasal(Usuario usuario)
        {
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
                mbr = (((10 * peso) + (6.25f * usuario.AlturaCentimetros()) - (5 * edad) - 161 ) + ((10 * peso) + (6.25f * usuario.AlturaCentimetros()) - (5 * edad) + 5)) / 2;
            }
            return mbr;

        }

        public float CalcularCalorias(Usuario usuario)
        {
             
            calorias = this.met * usuario.Peso * this.duracion;
                
            return calorias;
        }

        public String NombreActividad { get { return this.nombreActividadFisica; } set { this.nombreActividadFisica = value; } }
        public float Duracion { get { return this.duracion; } set { this.duracion = PasarAHoras( value); } }

        public String Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public Usuario Usuario { get { return this.usuario; } set { this.usuario = value; } }

        public float MET { get { return this.met; } set { this.met = calculaMet(value); } }


        public override bool Equals(object obj)
        {
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
