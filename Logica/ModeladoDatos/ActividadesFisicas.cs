using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ModeladoDatos
{
    internal class ActividadesFisicas
    {
        private string idActividadFisica;
        private string nombreActividadFisica;
        private int duracion;
        private string descripcion;

        public ActividadesFisicas(string idActividadFisica, string nombreActividadFisica, int duracion, string descripcion)
        {
            this.idActividadFisica = idActividadFisica;
            this.nombreActividadFisica = nombreActividadFisica;
            this.duracion = duracion;
            this.descripcion = descripcion;
        }

        public String NombreActividad { get { return this.nombreActividadFisica; } set { this.nombreActividadFisica = value; } }
        public int Duracion { get { return this.duracion; } set { this.duracion = value; } }

        public String Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }

    }
}
