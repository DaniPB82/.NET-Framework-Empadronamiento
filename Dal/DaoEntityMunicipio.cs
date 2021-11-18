using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityMunicipio : IDaoMunicipio
    {
        public void Eliminar(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Municipios.Remove(db.Municipios.Find(id));
                db.SaveChanges();
            }
        }

        public Municipio Insertar(Municipio municipio)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return municipio;
            }
        }

        public Municipio Modificar(Municipio municipio)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Entry(municipio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return municipio;
            }
        }

        public Municipio ObtenerPorId(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Municipios.Find(id);
            }
        }

        public IEnumerable<Municipio> ObtenerPorNombre(string nombre)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Municipios.Where(m => m.Nombre.Contains(nombre)).ToList();
            }
        }

        public IEnumerable<Municipio> ObtenerTodos()
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Municipios.ToList();
            }
        }
    }
}
