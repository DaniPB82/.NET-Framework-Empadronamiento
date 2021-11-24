using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlConsola
{
    // Clase inacabada con la idea de que el/la que descargue el repositorio
    // complete esta clase muy similar a las que están acabadas.
    internal class ViviendaOp
    {
        internal static void MenuViviendas()
        {
            Console.Clear();

            Program.Cabecera("MENÚ VIVIENDAS");

            Console.WriteLine("1 - Listado");
            Console.WriteLine("2 - Búsqueda por ID");
            Console.WriteLine("3 - Búsqueda por MUNICIPIO");
            Console.WriteLine("4 - Búsqueda por DIRECCIÓN");
            Console.WriteLine("5 - Búsqueda por CP");
            Console.WriteLine("6 - Insertar");
            Console.WriteLine("7 - Modificar");
            Console.WriteLine("8 - Eliminar");
            Console.WriteLine("9 - Volver al MENÚ PRINCIPAL");

            int accion = Program.OpcionMenu();

            //AccionMenuViviendas(accion);
        }
    }
}
