using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadT2Test.Repositorios
{
    public class LibroRepositorioTest
    {
        private IQueryable<Libro> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Libro>
            {
                new Libro() { Id = 1, AutorId = 1, Nombre = "El libro rojo", Puntaje = 1},
                new Libro() { Id = 2, AutorId = 2, Nombre = "El libro verde", Puntaje = 2},
                new Libro() { Id = 3, AutorId = 3, Nombre = "El libro azul", Puntaje = 3},
                new Libro() { Id = 4, AutorId = 4, Nombre = "El libro amarillo", Puntaje = 4},
                new Libro() { Id = 5, AutorId = 5, Nombre = "El libro negro", Puntaje = 5},

            }.AsQueryable();

            var mockAppContextUsuario = new MockDBSet<Libro>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Libros).Returns(mockAppContextUsuario.Object);
        }
        [Test]
        public void AdquirirLibrosTest01()
        {
            var controller = new LibroRepositorio(mockDB.Object);
            var view = controller.AdquirirLibros();

            Assert.AreEqual(5, view.Count);
        }
        [Test]
        public void ConseguirLibroTest01()
        {
            var controller = new LibroRepositorio(mockDB.Object);
            var view = controller.Llibro(2);

            Assert.AreEqual("El libro verde", view.Nombre);
        }
    }

}
