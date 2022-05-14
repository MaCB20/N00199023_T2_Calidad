using System.Collections.Generic;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using NUnit.Framework;
using Moq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Test.Controllers
{
    public class BibliotecaControllerTest
    {

        [Test]
        public void IndexViewCase01()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>(){
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            mockUsuarioRepositorio.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var controller = new BibliotecaController(null, mockUsuarioRepositorio.Object, null);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.Index;

            Assert.IsNotNull(view);
        }
        [Test]
        public void AddViewCase01()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>(){
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            mockUsuarioRepositorio.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var controller = new BibliotecaController(null, mockUsuarioRepositorio.Object, mockBiblioteca.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.Add(2);

            Assert.IsNotNull(view);
        }
        [Test]
        public void MarcarComoLeyendoViewCase01()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>(){
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            mockUsuarioRepositorio.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var controller = new BibliotecaController(null, mockUsuarioRepositorio.Object, mockBiblioteca.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.MarcarComoLeyendo(2);

            Assert.IsNotNull(view);
        }
        [Test]
        public void MarcarComoTerminadoViewCase01()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>(){
                new Claim(ClaimTypes.Name, "admin")
            });

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var mockUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            mockUsuarioRepositorio.Setup(o => o.obtenerUsuario("admin")).Returns(new Usuario());

            var mockBiblioteca = new Mock<IBibliotecaRepositorio>();

            var controller = new BibliotecaController(null, mockUsuarioRepositorio.Object, mockBiblioteca.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.MarcarComoTerminado(2);

            Assert.IsNotNull(view);
        }
    }
}
