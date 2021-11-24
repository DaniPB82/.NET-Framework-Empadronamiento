using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProvinciasController : ApiController
    {
        private static readonly IDaoProvincia dao = Fabrica.ObtenerDaoProvincia(Tipos.Entity);

        // GET: api/Provincias
        public IEnumerable<Provincia> Get()
        {
            return Bll.ProvinciasBll.Consultar();
        }

        // GET: api/Provincias/5
        public Provincia Get(long id)
        {
            return Bll.ProvinciasBll.BuscarPorId(id);
        }

        // GET: api/Provincias/5
        public IEnumerable<Provincia> Get(string nombre)
        {
            IEnumerable<Provincia> provincias;

            provincias = dao.ObtenerPorNombre(nombre);

            //foreach (Provincia p in provincias)
            //{
            //    p.Municipios = null;
            //}

            return provincias;
            //return new List<Producto>() { new Producto() { Nombre = nombre } };
        }

        // POST: api/Provincias
        public void Post([FromBody]Provincia provincia)
        {
            Bll.ProvinciasBll.Guardar(provincia);
        }

        // PUT: api/Provincias/5
        public void Put(long id, [FromBody]Provincia provincia)
        {
            Bll.ProvinciasBll.Modificar(provincia);
        }

        // DELETE: api/Provincias/5
        public void Delete(long id)
        {
            Bll.ProvinciasBll.Eliminar(id);
        }
    }
}
