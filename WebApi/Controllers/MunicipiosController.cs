using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class MunicipiosController : ApiController
    {
        // GET: api/Municipios
        public IEnumerable<Municipio> Get()
        {
            return Bll.MunicipiosBll.Consultar();
        }

        // GET: api/Municipios/5
        public Municipio Get(long id)
        {
            return Bll.MunicipiosBll.BuscarPorId(id);
        }

        // GET: api/Municipios?provinciaId=5
        public IEnumerable<Municipio> GetMunicipiosPorProvincia(long provinciaId)
        {
            return Bll.MunicipiosBll.BuscarPorProvinciaId(provinciaId);
        }

        // GET: api/Municipios?nombre=izc
        public IEnumerable<Municipio> GetMunicipiosPorNombre(string nombre)
        {
            return Bll.MunicipiosBll.BuscarPorNombre(nombre);
        }

        // POST: api/Municipios
        public Municipio Post([FromBody]Municipio municipio)
        {
            return Bll.MunicipiosBll.Guardar(municipio);
        }

        // PUT: api/Municipios/5
        public Municipio Put(long id, [FromBody]Municipio municipio)
        {
            return Bll.MunicipiosBll.Modificar(municipio);
        }

        // DELETE: api/Municipios/5
        public void Delete(long id)
        {
            Bll.MunicipiosBll.Eliminar(id);
        }
    }
}
