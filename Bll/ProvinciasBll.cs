using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class ProvinciasBll
    {
        private static readonly IDaoProvincia dao = Fabrica.ObtenerDaoProvincia(Tipos.Entity);

        public static IEnumerable<Provincia> Consultar()
        {
            return dao.ObtenerTodos();
        }

        public static Provincia BuscarPorId(long id)
        {
            return dao.ObtenerPorId(id);
        }

        public static IEnumerable<Provincia> BuscarPorNombre(string nombre)
        {
            return dao.ObtenerPorNombre(nombre);
        }

        public static void Guardar(Provincia provincia)
        {
            dao.Insertar(provincia);
        }

        public static void Modificar(Provincia provincia)
        {
            dao.Modificar(provincia);
        }

        public static void Eliminar(long id)
        {
            dao.Eliminar(id);
        }
    }
}
