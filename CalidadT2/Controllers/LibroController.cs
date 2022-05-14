using System;
using System.Linq;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using CalidadT2.Repositorio;
using System.Security.Claims;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly AppBibliotecaContext appBibliotecaContext;
        private readonly ILibroRepositorio libroRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public LibroController(AppBibliotecaContext appBibliotecaContext, ILibroRepositorio libroRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.appBibliotecaContext = appBibliotecaContext;
            this.libroRepositorio = libroRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = libroRepositorio.Llibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;

            libroRepositorio.AñadirComentario(comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var user = claim.Value;

            return usuarioRepositorio.obtenerUsuario(user);
        }
    }
}
