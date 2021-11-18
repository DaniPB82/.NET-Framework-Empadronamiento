using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Vivienda : IEquatable<Vivienda>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vivienda()
        {
            Personas = new HashSet<Persona>();
            Personas1 = new HashSet<Persona>();
        }

        public long Id { get; set; }

        public long? MunicipioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(5)]
        public string Cp { get; set; }

        public virtual Municipio Municipios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Personas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Personas1 { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vivienda);
        }

        public bool Equals(Vivienda other)
        {
            return other != null &&
                   Id == other.Id &&
                   MunicipioId == other.MunicipioId &&
                   Direccion == other.Direccion &&
                   Cp == other.Cp;
        }

        public override int GetHashCode()
        {
            int hashCode = 1750528066;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + MunicipioId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Direccion);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cp);
            return hashCode;
        }

        public override string ToString() => $"{Id}, {MunicipioId}, {Direccion}, {Cp}";

        public static bool operator ==(Vivienda left, Vivienda right)
        {
            return EqualityComparer<Vivienda>.Default.Equals(left, right);
        }

        public static bool operator !=(Vivienda left, Vivienda right)
        {
            return !(left == right);
        }
    }
}
