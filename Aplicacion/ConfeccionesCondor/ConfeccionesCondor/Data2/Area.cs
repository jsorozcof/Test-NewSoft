using System;
using System.Collections.Generic;

namespace ConfeccionesCondor.Data2
{
    public partial class Area
    {
        public Area()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int AreaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
