using System;
using System.Collections.Generic;

namespace ConfeccionesCondor.Data2
{
    public partial class Empleado
    {
        public int EmpleadoId { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int AreaId { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Area Area { get; set; }
    }
}
