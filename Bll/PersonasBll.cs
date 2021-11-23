using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Persona;

namespace Bll
{
    public static class PersonasBll
    {
        private static readonly IDaoPersona dao = Fabrica.ObtenerDaoPersona(Tipos.Entity);

        public static IEnumerable<Persona> ConsultarPersonas()
        {
            return dao.ObtenerTodos();
        }

        public static Persona BuscarPorId(long id)
        {
            return dao.ObtenerPorId(id);
        }

        public static IEnumerable<Persona> BuscarPorDni(string dni)
        {
            return dao.ObtenerPorDni(dni);
        }

        public static IEnumerable<Persona> BuscarPorNombre(string nombre)
        {
            return dao.ObtenerPorNombre(nombre);
        }

        public static IEnumerable<Persona> BuscarPorApellido(string apellido)
        {
            return dao.ObtenerPorApellido(apellido);
        }

        public static IEnumerable<Persona> BuscarPorAnioNacimiento(int anio)
        {
            return dao.ObtenerPorAnioNacimiento(anio);
        }

        public static IEnumerable<Propiedad> ConsultarPropiedades()
        {
            return dao.ObtenerPropiedades();
        }

        public static IEnumerable<Vivienda> BuscarPropiedadesPorPersona(long idPropietario)
        {
            return dao.ObtenerPropiedadesPorPersona(idPropietario);
        }

        public static IEnumerable<Persona> BuscarPropietariosPorVivienda(long idVivienda)
        {
            return dao.ObtenerPropietariosPorVivienda(idVivienda);
        }

        public static Propiedad BuscarPropiedadPorId(long propietarioId, long viviendaId)
        {
            return dao.ObtenerPropiedadPorId(propietarioId, viviendaId);
        }

        public static Persona GuardarPersona(Persona persona)
        {
            return dao.Insertar(persona);
        }

        public static Persona  ModificarPersona(Persona persona)
        {
            return dao.Modificar(persona);
        }

        public static void EliminarPersona(long id)
        {
            dao.Eliminar(id);
        }

        public static Propiedad GuardarPropiedad(Propiedad propiedad)
        {
            return dao.Insertar(propiedad);
        }

        public static Propiedad ModificarPropiedad(Propiedad propiedad)
        {
            return dao.Modificar(propiedad);
        }

        public static void EliminarPropiedad(long propietarioId, long viviendaId)
        {
            dao.Eliminar(propietarioId, viviendaId);
        }
    }
}
