using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EjemploListaEnlazada2.Tests
{
    [TestClass]
    public class EstudianteTests
    {
        [TestMethod]
        public void Estudiante_NombreMenor10Caracteres_NoValido()
        {
            var estudiante = new Estudiante("Juan", 75, "Ingenieria");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("El nombre del estudiante es requerido y debe tener al menos 10 caracteres"));
        }

        [TestMethod]
        public void Estudiante_NombreCon10Caracteres_Valido()
        {
            var estudiante = new Estudiante("Edisson", 75, "Ingenieria");
            Assert.IsTrue(estudiante.EstudianteValido());
        }

        [TestMethod]
        public void Estudiante_CarreraNoPermitida_NoValido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 75, "Arquitectura");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("La carrera del estudiante es requerida y debe ser una de las siguientes: Ingenieria, Medicina, Derecho, Auditoria"));
        }

        [TestMethod]
        public void Estudiante_CarreraPermitida_Valido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 75, "Ingenieria");
            Assert.IsTrue(estudiante.EstudianteValido());
        }

        [TestMethod]
        public void Estudiante_PunteoFueraDeRango_NoValido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 101, "Ingenieria");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("El punteo del estudiante debe ser entre 0 y 100"));
        }

        [TestMethod]
        public void Estudiante_PunteoEnRango_Valido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 85, "Ingenieria");
            Assert.IsTrue(estudiante.EstudianteValido());
        }

        [TestMethod]
        public void Estudiante_MedicinaCon85_Aprobado()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 85, "Medicina");
            Assert.IsTrue(estudiante.EsAprobado());
        }

        [TestMethod]
        public void Estudiante_IngenieriaCon70_Aprobado()
        {
            var estudiante = new Estudiante("JuanCarlos", 70, "Derecho");
            Assert.IsTrue(estudiante.EsAprobado());
        }


        [TestMethod]
        public void Estudiante_NombreVacio_NoValido()
        {
            var estudiante = new Estudiante("", 75, "Ingenieria");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("El nombre del estudiante es obligatorio y debe tener al menos 10 caracteres"));
        }

        [TestMethod]
        public void Estudiante_PunteoNoAsignado_NoValido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", -1, "Ingenieria");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("El punteo del estudiante es obligatorio y debe ser entre 0 y 100"));
        }

        [TestMethod]
        public void Estudiante_CarreraVacia_NoValido()
        {
            var estudiante = new Estudiante("Edisson Estuardo", 75, "");
            Assert.IsFalse(estudiante.EstudianteValido());
            Assert.IsTrue(estudiante.Errores.Contains("La carrera del estudiante es obligatoria y debe ser una de las siguientes: Ingenieria, Medicina, Derecho, Auditoria"));
        }

    }
}
