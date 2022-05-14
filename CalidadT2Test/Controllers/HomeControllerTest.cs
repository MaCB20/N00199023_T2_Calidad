using NUnit.Framework;
using Moq;
using CalidadT2.Repositorio;
using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Test.Controllers
{
    public class HomeControllerTest
    {

        [Test]
        public void IndexViewCase01()
        {
            var mockLibroRepositorio = new Mock<ILibroRepositorio>();
            var controllerIndex = new HomeController(null, mockLibroRepositorio.Object);
            var view = controllerIndex.View() as ViewResult;

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}