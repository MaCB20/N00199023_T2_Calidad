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
    public class UsuarioRepositorioTest
    {

        private IQueryable<Usuario> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Usuario>
            {
                new Usuario() { Id = 1, Username = "admin" , Password = "123456", Nombres = "Marlon"},
                new Usuario() { Id = 2, Username = "user1" , Password = "123456", Nombres = "Eduardo"}
            }.AsQueryable();

            var mockAppContextUsuario = new MockDBSet<Usuario>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Usuarios).Returns(mockAppContextUsuario.Object);
        }

        [Test]
        public void ObtenerUsuarioTestViewCase01()
        {
            var controller = new UsuarioRepositorio(mockDB.Object);
            var view = controller.obtenerUsuario("admin");

            Assert.AreEqual("admin", view.Username);
        }
    }
}
