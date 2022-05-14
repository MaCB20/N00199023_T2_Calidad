using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.Helpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2Test.Repositorios
{
    public class BibliotecaRepositorioTest
    {
        private IQueryable<Biblioteca> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Biblioteca>
            {
                new Biblioteca() { Id = 1, UsuarioId = 1 , LibroId = 1},
                new Biblioteca() { Id = 2, UsuarioId = 2 , LibroId = 2},
                new Biblioteca() { Id = 3, UsuarioId = 3 , LibroId = 3},
                new Biblioteca() { Id = 4, UsuarioId = 4 , LibroId = 4},
                new Biblioteca() { Id = 5, UsuarioId = 5 , LibroId = 5}

            }.AsQueryable();

            var mockAppContextUsuario = new MockDBSet<Biblioteca>(data);
            mockDB = new Mock<AppBibliotecaContext>();

            mockDB.Setup(o => o.Bibliotecas).Returns(mockAppContextUsuario.Object);
        }
        [Test]
        public void AdquirirBibliotecaViewCase01()
        {
            var controller = new BibliotecaRepositorio(mockDB.Object);
            var view = controller.AdquirirBibliotecaIndex(5);

            Assert.AreEqual(1, view.Count);
        }
        [Test]
        public void AñadirBibliotecaViewCase01()
        {
            var controller = new BibliotecaRepositorio(mockDB.Object);
            var view = controller.AñadirBibliotecaAdd(new Biblioteca()
            {
                Id = 2, UsuarioId = 2, LibroId = 2
            });

            Assert.AreEqual(2, view.Id);
        }
        [Test]
        public void ActualizarEstado01Test()
        {
            var controller = new BibliotecaRepositorio(mockDB.Object);
            var view = controller.ActualizarEstado01(2, 2);

            Assert.AreEqual(2, view.Estado);
        }
        [Test]
        public void ActualizarEstado02Test()
        {
            var controller = new BibliotecaRepositorio(mockDB.Object);
            var view = controller.ActualizarEstado02(2, 2);

            Assert.AreEqual(3, view.Estado);
        }
    }
}
