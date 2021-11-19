using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Persona : IEquatable<Persona>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Viviendas1 = new HashSet<Vivienda>();
        }

        public long Id { get; set; }

        public long? HogarId { get; set; }

        [Required]
        [StringLength(9)]
        public string Dni { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public virtual Vivienda Viviendas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vivienda> Viviendas1 { get; set; }

        public class Propiedad : IEquatable<Propiedad>
        {
            [Key, Column(Order = 0)]
            public long PropietarioId { get; set; }

            [Key, Column(Order = 1)]
            public long ViviendaId { get; set; }

            [ForeignKey("PropietarioId")]
            public Persona Persona { get; set; }

            [ForeignKey("ViviendaId")]
            public Vivienda Vivienda { get; set; }

            public override string ToString() => $"{PropietarioId}, {ViviendaId}";
            
            public override bool Equals(object obj)
            {
                return Equals(obj as Propiedad);
            }

            public bool Equals(Propiedad other)
            {
                return other != null &&
                       PropietarioId == other.PropietarioId &&
                       ViviendaId == other.ViviendaId;
            }

            public override int GetHashCode()
            {
                int hashCode = -1213599712;
                hashCode = hashCode * -1521134295 + PropietarioId.GetHashCode();
                hashCode = hashCode * -1521134295 + ViviendaId.GetHashCode();
                return hashCode;
            }

            public static bool operator ==(Propiedad left, Propiedad right)
            {
                return EqualityComparer<Propiedad>.Default.Equals(left, right);
            }

            public static bool operator !=(Propiedad left, Propiedad right)
            {
                return !(left == right);
            }
        }

        public override string ToString() => $"{Id}, {HogarId}, {Dni}, {Nombre}, {Apellido}, {FechaNacimiento}";

        public override bool Equals(object obj)
        {
            return Equals(obj as Persona);
        }

        public bool Equals(Persona other)
        {
            return other != null &&
                   Id == other.Id &&
                   HogarId == other.HogarId &&
                   Dni == other.Dni &&
                   Nombre == other.Nombre &&
                   Apellido == other.Apellido &&
                   FechaNacimiento == other.FechaNacimiento;
        }

        public override int GetHashCode()
        {
            int hashCode = 171594515;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + HogarId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            hashCode = hashCode * -1521134295 + FechaNacimiento.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Persona left, Persona right)
        {
            return EqualityComparer<Persona>.Default.Equals(left, right);
        }

        public static bool operator !=(Persona left, Persona right)
        {
            return !(left == right);
        }
    }
}
