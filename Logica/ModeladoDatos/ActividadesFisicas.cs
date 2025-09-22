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
    }
}
