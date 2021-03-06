using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDaoMunicipio: IDao<Municipio>
    {
        IEnumerable<Municipio> ObtenerPorNombre(string nombre);
        IEnumerable<Municipio> ObtenerPorProvinciaId(long provinciaId);
    }
}
