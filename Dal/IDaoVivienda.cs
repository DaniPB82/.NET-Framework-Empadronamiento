using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDaoVivienda: IDao<Vivienda>
    {
        IEnumerable<Vivienda> ObtenerPorMunicipio(long idMunicipio);
        IEnumerable<Vivienda> ObtenerPorDireccion(string direccion);
        IEnumerable<Vivienda> ObtenerPorCp(string cp);
    }
}
