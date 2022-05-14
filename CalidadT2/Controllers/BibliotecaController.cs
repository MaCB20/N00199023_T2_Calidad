using System.Linq;
using System.Security.Claims;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly AppBibliotecaContext appBibliotecaContext;
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IBibliotecaRepositorio bibliotecaRepositorio;

        public BibliotecaController(AppBibliotecaContext appBibliotecaContext, IUsuarioRepositorio usuarioRepositorio, IBibliotecaRepositorio bibliotecaRepositorio)
        {
            this.appBibliotecaContext = appBibliotecaContext;
            this.usuarioRepositorio = usuarioRepositorio;
            this.bibliotecaRepositorio = bibliotecaRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = bibliotecaRepositorio.AdquirirBibliotecaIndex(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();

            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            bibliotecaRepositorio.AñadirBibliotecaAdd(biblioteca);

            //TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            bibliotecaRepositorio.ActualizarEstado01(libroId, user.Id);

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            bibliotecaRepositorio.ActualizarEstado02(libroId, user.Id);

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var user = claim.Value;

            return usuarioRepositorio.obtenerUsuario(user);
        }
    }
}
