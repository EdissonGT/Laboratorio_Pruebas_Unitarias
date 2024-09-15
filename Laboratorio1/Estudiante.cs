using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploListaEnlazada2
{
    public class Estudiante
    {
        public string nombre;
        public int Punteo;
        public string Carrera;

        public List<string> Errores { get; private set; }

        public Estudiante()
        {
            nombre = "";
            Punteo = 0;
            Carrera = "";
        }

        public Estudiante(string pNombre, int pPunteo, string pCarrera)
        {
            nombre = pNombre;
            Punteo = pPunteo;
            Carrera = pCarrera;
        }

        public bool EstudianteValido()
        {
            Errores = new List<string>();
            var valido = true;

            // Validación de nombre (obligatorio y mínimo 10 caracteres)
            if (string.IsNullOrWhiteSpace(this.nombre) || this.nombre.Length < 10)
            {
                Errores.Add("El nombre del estudiante es obligatorio y debe tener al menos 10 caracteres");
                valido = false;
            }

            // Validación de punteo (obligatorio y rango entre 0 y 100)
            if (this.Punteo > 100 || this.Punteo < 0)
            {
                Errores.Add("El punteo del estudiante es obligatorio y debe ser entre 0 y 100");
                valido = false;
            }

            // Validación de carrera (obligatorio y dentro de las opciones permitidas)
            var carrerasPermitidas = new List<string> { "Ingenieria", "Medicina", "Derecho", "Auditoria" };
            if (string.IsNullOrWhiteSpace(this.Carrera) || !carrerasPermitidas.Contains(this.Carrera))
            {
                Errores.Add("La carrera del estudiante es obligatoria y debe ser una de las siguientes: Ingenieria, Medicina, Derecho, Auditoria");
                valido = false;
            }

            return valido;
        }


        public bool EsAprobado()
        {
            if (Carrera == "Medicina")
            {
                return Punteo >= 85;
            }
            else
            {
                return Punteo >= 70;
            }
        }
    }

}
