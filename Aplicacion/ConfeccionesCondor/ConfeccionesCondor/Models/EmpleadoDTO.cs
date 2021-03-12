using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConfeccionesCondor.Models
{
    public class EmpleadoDTO
    {
        [Key]
        public int EmpleadoId { get; set; }


        [DisplayName("Tipo Documento")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int TipoDocumentoId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Numero Documento")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string NumeroDocumento { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombres")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Nombres { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Apellidos { get; set; }

        [DisplayName("Area")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int AreaId { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaCreacion { get; set; }

        public string NombreCompleto { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreArea { get; set; }

    }
}
