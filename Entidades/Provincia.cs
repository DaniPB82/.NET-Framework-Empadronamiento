using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Provincia : IEquatable<Provincia>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipios { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Provincia);
        }

        public bool Equals(Provincia other)
        {
            return other != null &&
                   Id == other.Id &&
                   Nombre == other.Nombre;
        }

        public override int GetHashCode()
        {
            int hashCode = -1675956928;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            return hashCode;
        }

        public override string ToString() => $"{Id}, {Nombre}";

        public static bool operator ==(Provincia left, Provincia right)
        {
            return EqualityComparer<Provincia>.Default.Equals(left, right);
        }

        public static bool operator !=(Provincia left, Provincia right)
        {
            return !(left == right);
        }
    }
}
