using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploArchivos
{
    internal class AdministraAlumno
    {
        //Esta lista almacenara los alumnos
        private List<Alumno> listaAlumnos;
        public AdministraAlumno()
        {
            listaAlumnos = new List<Alumno>();
        }

        public void agregarAlumno(Alumno alumno)
        {
            listaAlumnos.Add(alumno);
        }

        public Alumno buscarAlumno(string noControl)
        {
            Alumno alumno = null;
            for(int i = 0; i < listaAlumnos.Count; i++)
            {
                if (listaAlumnos[i].NoControl == noControl)
                {
                    alumno = listaAlumnos[i];
                }
            }
            return alumno;
        }

        public void modificarAlumno(Alumno alumno)
        {
            for(int i = 0; i < listaAlumnos.Count; i++)
            {
                if (listaAlumnos[i].NoControl ==
                    alumno.NoControl)
                {
                    listaAlumnos[i] = alumno;
                }
            }
        }

        public void eliminarAlumno(Alumno alumno)
        {
            listaAlumnos.Remove(alumno);
        }

        public List<Alumno> todosLosAlumnos() {
            return listaAlumnos;
        }
    } 
}
