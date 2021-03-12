using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConfeccionesCondor.Models
{
    public class AreaModel
    {
        [Key]
        public int AreaId { get; set; }


        [DisplayName("Area")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Nombre { get; set; }

        public virtual ICollection<EmpleadoModel> Empleado { get; set; }
    }
}
