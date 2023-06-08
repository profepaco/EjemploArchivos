using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            int opcion;
            administraAlumno = new AdministraAlumno();
            do
            {
                Console.WriteLine("1. Agregar alumno");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Modificar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Mostrar todos");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Selecciona una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    nuevoAlumno();
                }
                else if (opcion == 2)
                {
                    consultarAlumno();
                }
                else if (opcion == 3)
                {
                    modificarAlumno();
                }else if(opcion == 4)
                {
                    eliminarAlumno();
                }
                else if (opcion == 5)
                {
                    mostrarAlumnos();
                }
            } while (opcion != 6);
            administraAlumno.cerrar();
        }

        private static void mostrarAlumnos()
        {
            List<Alumno> alumnos = administraAlumno.todosLosAlumnos();
            foreach(Alumno alumno in alumnos)
            {
                Console.WriteLine(alumno);
            }
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

        private static void modificarAlumno()
        {
            Alumno alumno;
            string noControl;
            string nombre;
            string carrera;
            Console.WriteLine("¿Número de control del alumno?");
            noControl = Console.ReadLine();
            alumno = administraAlumno.buscarAlumno(noControl);
            if (alumno == null)
            {
                Console.WriteLine("Alumno no encontrado");
            }
            else
            {
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Carrera: ");
                carrera = Console.ReadLine();
                alumno =
                    new Alumno(noControl, nombre, carrera);
                administraAlumno.modificarAlumno(alumno);
            }
        }

        private static void eliminarAlumno()
        {
            Alumno alumno;
            string noControl;
            int opcion;
            Console.WriteLine(
                "¿Cual es el numero de control?");
            noControl = Console.ReadLine();
            alumno = administraAlumno.buscarAlumno(noControl);
            if (alumno == null)
            {
                Console.WriteLine("Alumno no encontrado");
            }
            else
            {
                Console.WriteLine(alumno);
                Console.WriteLine("¿Quieres eliminar el alumno?\n1. Si\n2. No");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1){
                    administraAlumno.eliminarAlumno(alumno);
                    Console.WriteLine("Alumno eliminado correctamente");
                }
            }
        }
    }
}
