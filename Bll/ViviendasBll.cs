using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class ViviendasBll
    {
        private static readonly IDaoVivienda dao = Fabrica.ObtenerDaoVivienda(Tipos.Entity);

        public static IEnumerable<Vivienda> Consultar()
        {
            return dao.ObtenerTodos();
        }

        public static Vivienda BuscarPorId(long id)
        {
            return dao.ObtenerPorId(id);
        }

        public static IEnumerable<Vivienda> BuscarPorMunicipio(long idMunicipio)
        {
            return dao.ObtenerPorMunicipio(idMunicipio);
        }

        public static IEnumerable<Vivienda> BuscarPorDireccion(string direccion)
        {
            return dao.ObtenerPorDireccion(direccion);
        }

        public static IEnumerable<Vivienda> BuscarPorCp(string cp)
        {
            return dao.ObtenerPorCp(cp);
        }

        public static Vivienda Guardar(Vivienda vivienda)
        {
            return dao.Insertar(vivienda);
        }

        public static Vivienda Modificar(Vivienda vivienda)
        {
            return dao.Modificar(vivienda);
        }

        public static void Eliminar(long id)
        {
            dao.Eliminar(id);
        }
    }
}
