using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityPersona : IDaoPersona
    {
        public void Eliminar(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Personas.Remove(db.Personas.Find(id));
                db.SaveChanges();
            }
        }

        public Persona Insertar(Persona persona)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return persona;
            }
        }

        public Persona Modificar(Persona persona)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return persona;
            }
        }

        public IEnumerable<Persona> ObtenerPorApellido(string apellido)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.Where(p => p.Apellido.Contains(apellido)).ToList();
            }
        }

        public IEnumerable<Persona> ObtenerPorDni(string dni)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.Where(p => p.Dni.Contains(dni)).ToList();
            }
        }

        public Persona ObtenerPorId(long id)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.Find(id);
            }
        }

        public IEnumerable<Persona> ObtenerPorNombre(string nombre)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.Where(p => p.Nombre.Contains(nombre)).ToList();
            }
        }

        public IEnumerable<Persona> ObtenerTodos()
        {
            using(EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.ToList();
            }
        }
    }
}
