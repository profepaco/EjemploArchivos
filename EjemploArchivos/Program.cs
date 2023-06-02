using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploArchivos
{
    internal class Program
    {
        private static AdministraAlumno administraAlumno;
        static void Main(string[] args)
        {
            int opcion = 0;
            administraAlumno = new AdministraAlumno();
            do
            {
                Console.WriteLine("1. Agregar alumno");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Modificar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Selecciona una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    nuevoAlumno();
                }else if(opcion == 2)
                {
                    consultarAlumno();
                }
            } while (opcion != 5);
        }

        private static void nuevoAlumno()
        {
            string nombre;
            string noControl;
            string carrera;
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Numero de control:");
            noControl = Console.ReadLine();
            Console.WriteLine("Carrera: ");
            carrera = Console.ReadLine();
            Alumno alumno = 
                new Alumno(noControl, nombre, carrera);
            administraAlumno.agregarAlumno(alumno);
            Console.WriteLine("Alumno agregado correctamente");
        }

        private static void consultarAlumno()
        {
            Alumno alumno = null;
            string noControl;
            Console.WriteLine(
                "¿Cual es el numero de control?");
            noControl = Console.ReadLine();
            alumno = administraAlumno.buscarAlumno(noControl);
            if(alumno == null)
            {
                Console.WriteLine("Alumno no encontrado");
            }
            else
            {
                Console.WriteLine(alumno);
            }
        }
    }
}
