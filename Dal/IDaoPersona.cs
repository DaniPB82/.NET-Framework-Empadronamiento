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
        Persona ObtenerPorDni(long id);
        IEnumerable<Persona> ObtenerPorNombre(string nombre);
        IEnumerable<Persona> ObtenerPorApellido(string apellido);
    }
}
