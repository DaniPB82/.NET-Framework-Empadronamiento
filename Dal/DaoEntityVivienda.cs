using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityVivienda : IDaoVivienda
    {
        public void Eliminar(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Viviendas.Remove(db.Viviendas.Find(id));
                db.SaveChanges();
            }
        }

        public Vivienda Insertar(Vivienda vivienda)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Viviendas.Add(vivienda);
                db.SaveChanges();
                return vivienda;
            }
        }

        public Vivienda Modificar(Vivienda vivienda)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Entry(vivienda).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return vivienda;
            }
        }

        public IEnumerable<Vivienda> ObtenerPorCp(string cp)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Viviendas.Where(v => v.Cp.Contains(cp)).ToList();
            }
        }

        public IEnumerable<Vivienda> ObtenerPorDireccion(string direccion)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Viviendas.Where(v => v.Direccion.Contains(direccion)).ToList();
            }
        }

        public Vivienda ObtenerPorId(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Viviendas.Find(id);
            }
        }

        public IEnumerable<Vivienda> ObtenerPorMunicipio(long idMunicipio)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Viviendas.Where(v => v.MunicipioId == idMunicipio).ToList();
            }
        }

        public IEnumerable<Vivienda> ObtenerTodos()
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Viviendas.ToList();
            }
        }
    }
}
