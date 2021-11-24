using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ViviendasController : ApiController
    {
        // GET: api/Viviendas
        public IEnumerable<Vivienda> Get()
        {
            return Bll.ViviendasBll.Consultar();
        }

        // GET: api/Viviendas/5
        public Vivienda Get(long id)
        {
            return Bll.ViviendasBll.BuscarPorId(id);
        }

        // GET: api/Viviendas/5
        public IEnumerable<Vivienda> GetViviendasPorMunicipio(long municipioId)
        {
            return Bll.ViviendasBll.BuscarPorMunicipio(municipioId);
        }

        // GET: api/Viviendas/5
        public IEnumerable<Vivienda> GetViviendasPorDireccion(string direccion)
        {
            return Bll.ViviendasBll.BuscarPorDireccion(direccion);
        }

        // GET: api/Viviendas/5
        public IEnumerable<Vivienda> GetViviendaPorCp(string cp)
        {
            return Bll.ViviendasBll.BuscarPorCp(cp);
        }

        // POST: api/Viviendas
        public Vivienda Post([FromBody]Vivienda vivienda)
        {
            return Bll.ViviendasBll.Guardar(vivienda);
        }

        // PUT: api/Viviendas/5
        public Vivienda Put(long id, [FromBody]Vivienda vivienda)
        {
            return Bll.ViviendasBll.Modificar(vivienda);
        }

        // DELETE: api/Viviendas/5
        public void Delete(long id)
        {
            Bll.ViviendasBll.Eliminar(id);
        }
    }
}
