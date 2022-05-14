using System.Collections.Generic;
using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using CalidadT2.Repositorio;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CalidadT2Test.Controllers
{
    public class LibroControllerTest
    {
        [Test]
        public void DetailsViewCase01()
        {
            var mockDetails = new Mock<ILibroRepositorio>();
            var controller = new LibroController(null, mockDetails.Object, null);
            var view = controller.Details(1) as ViewResult;

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void AddComentarioViewCase01()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>(){
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            mockUsuarioRepositorio.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockLibroRepositorio = new Mock<ILibroRepositorio>();
            var controller = new LibroController(null, mockLibroRepositorio.Object, mockUsuarioRepositorio.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.AddComentario(new Comentario() { LibroId = 2, Puntaje = 2});

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
