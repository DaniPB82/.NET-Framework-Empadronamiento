using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDaoPersona: IDao<Persona>
    {
        IEnumerable<Persona> ObtenerPorDni(string dni);
        IEnumerable<Persona> ObtenerPorNombre(string nombre);
        IEnumerable<Persona> ObtenerPorApellido(string apellido);
        IEnumerable<Persona> ObtenerPorAnioNacimiento(int anio);
    }
}
