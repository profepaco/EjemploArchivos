using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EjemploArchivos
{
    internal class AdministraAlumno
    {
        //Esta lista almacenara los alumnos
        private List<Alumno> listaAlumnos;
        private string path = "archivo.dat";
        public AdministraAlumno()
        {
            if (File.Exists(path))
            {
                listaAlumnos = deserealizar();
            }
            else
            {
                listaAlumnos = new List<Alumno>();
            }
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

        private List<Alumno> deserealizar()
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            List<Alumno> lista = null;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                lista = (List<Alumno>)bf.Deserialize(fs);
                
            }catch(Exception ex) { 
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
            return lista;
        }

        public void cerrar()
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, listaAlumnos);
            }catch(Exception ex){
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    } 
}
