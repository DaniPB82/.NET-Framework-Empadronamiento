using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Persona;

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

        public IEnumerable<Persona> ObtenerPorAnioNacimiento(int anio)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Personas.Where(p => p.FechaNacimiento.Year == anio).ToList();
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

        public IEnumerable<Vivienda> ObtenerPropiedadesPorPersona(long propietarioId)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                var consulta = from viv in db.Viviendas
                               join pro in db.Propiedades
                               on viv.Id equals pro.ViviendaId
                               where pro.PropietarioId == propietarioId
                               select viv;

                return consulta.ToList();
            }
        }

        public IEnumerable<Persona> ObtenerPropietariosPorVivienda(long viviendaId)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                IEnumerable<Persona> consulta = from per in db.Personas
                               join pro in db.Propiedades
                               on per.Id equals pro.PropietarioId
                               where pro.ViviendaId == viviendaId
                               select per;

                return consulta.ToList();
            }
        }

        public IEnumerable<Propiedad> ObtenerPropiedades()
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Propiedades.ToList();
            }
        }

        public Propiedad Insertar(Propiedad propiedad)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Propiedades.Add(propiedad);
                db.SaveChanges();
                return propiedad;
            }
        }

        public Propiedad Modificar(Propiedad propiedad)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                db.Entry(propiedad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return propiedad;
            }
        }

        public void Eliminar(long propietarioId, long viviendaId)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                //var consulta = from pro in db.Propiedades
                //               where pro.PropietarioId == propietarioId &&
                //               pro.ViviendaId == viviendaId
                //               select pro;
                //Propiedad propiedad = consulta as Propiedad;
                db.Propiedades.Remove(db.Propiedades.Find(propietarioId, viviendaId));
                db.SaveChanges();
            }
        }

        public Propiedad ObtenerPropiedadPorId(long propietarioId, long viviendaId)
        {
            using (EmpadronamientoContext db = new EmpadronamientoContext())
            {
                return db.Propiedades.Find(propietarioId, viviendaId);
            }
        }
    }
}
