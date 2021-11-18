using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityProvincia : IDaoProvincia
    {
        public void Eliminar(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Provincias.Remove(db.Provincias.Find(id));
                db.SaveChanges();
            }
        }

        public Provincia Insertar(Provincia provincia)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return provincia;
            }
        }

        public Provincia Modificar(Provincia provincia)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Entry(provincia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return provincia;
            }
        }

        public Provincia ObtenerPorId(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Provincias.Find(id);
            }
        }

        public IEnumerable<Provincia> ObtenerPorNombre(string nombre)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Provincias.Where(p => p.Nombre.Contains(nombre)).ToList();
            }
        }

        public IEnumerable<Provincia> ObtenerTodos()
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Provincias.ToList();
            }
        }
    }
}
