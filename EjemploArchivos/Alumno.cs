using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploArchivos
{
    [Serializable]
    internal class Alumno
    {
        public string NoControl { set;get; }
        public string Nombre { set; get; }
        public string Carrera { set; get; }
        public int Semestre { set; get; }
        public float Promedio { set; get; }

        public Alumno(string noControl, 
            string nombre, 
            string carrera)
        {
            NoControl = noControl;
            Nombre = nombre;
            Carrera = carrera;
            Semestre = 1;
        }
    }
}
