using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Persona;

namespace Dal
{
    public interface IDaoPersona: IDao<Persona>
    {
        IEnumerable<Persona> ObtenerPorDni(string dni);
        IEnumerable<Persona> ObtenerPorNombre(string nombre);
        IEnumerable<Persona> ObtenerPorApellido(string apellido);
        IEnumerable<Persona> ObtenerPorAnioNacimiento(int anio);
        IEnumerable<Vivienda> ObtenerPropiedadesPorPersona(long propietarioId);
        IEnumerable<Persona> ObtenerPropietariosPorVivienda(long viviendaId);
        IEnumerable<Propiedad> ObtenerPropiedades();
        Propiedad ObtenerPropiedadPorId(long propietarioId, long viviendaId);
        Propiedad Insertar(Propiedad propiedad);
        Propiedad Modificar(Propiedad propiedad);
        void Eliminar(long propietarioId, long viviendaId);
    }
}
