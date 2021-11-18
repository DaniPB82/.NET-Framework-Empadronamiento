using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Municipio : IEquatable<Municipio>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Municipio()
        {
            Viviendas = new HashSet<Vivienda>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public long? ProvinciaId { get; set; }

        public virtual Provincia Provincias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vivienda> Viviendas { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Municipio);
        }

        public bool Equals(Municipio other)
        {
            return other != null &&
                   Id == other.Id &&
                   Nombre == other.Nombre &&
                   ProvinciaId == other.ProvinciaId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1987940019;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + ProvinciaId.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{Id}, {Nombre}, {ProvinciaId}";

        public static bool operator ==(Municipio left, Municipio right)
        {
            return EqualityComparer<Municipio>.Default.Equals(left, right);
        }

        public static bool operator !=(Municipio left, Municipio right)
        {
            return !(left == right);
        }
    }
}
