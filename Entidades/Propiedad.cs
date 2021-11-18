using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Propiedad
    {
        [Key, Column(Order = 0)]
        public long? PropietarioId { get; set; }

        [Key, Column(Order = 1)]
        public long? ViviendaId { get; set; }

        [ForeignKey("PropietarioId")]
        public Persona Persona { get; set; }

        [ForeignKey("ViviendaId")]
        public Vivienda Vivienda { get; set; }
    }
}
