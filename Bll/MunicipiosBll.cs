using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class MunicipiosBll
    {
        private static readonly IDaoMunicipio dao = Fabrica.ObtenerDaoMunicipio(Tipos.Entity);

        public static IEnumerable<Municipio> Consultar()
        {
            return dao.ObtenerTodos();
        }

        public static Municipio BuscarPorId(long id)
        {
            return dao.ObtenerPorId(id);
        }

        public static IEnumerable<Municipio> BuscarPorProvinciaId(long provinciaId)
        {
            return dao.ObtenerPorProvinciaId(provinciaId);
        }

        public static IEnumerable<Municipio> BuscarPorNombre(string nombre)
        {
            return dao.ObtenerPorNombre(nombre);
        }

        public static Municipio Guardar(Municipio municipio)
        {
            return dao.Insertar(municipio);
        }

        public static Municipio Modificar(Municipio municipio)
        {
            return dao.Modificar(municipio);
        }

        public static void Eliminar(long id)
        {
            dao.Eliminar(id);
        }
    }
}
