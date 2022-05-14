using Microsoft.AspNetCore.Mvc;
using CalidadT2.Models;
using CalidadT2.Repositorio;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private AppBibliotecaContext appBibliotecaContext;
        private ILibroRepositorio libroRepositorio;

        public HomeController(AppBibliotecaContext appBibliotecaContext, ILibroRepositorio libroRepositorio)
        {
            this.appBibliotecaContext = appBibliotecaContext;
            this.libroRepositorio = libroRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            var model = libroRepositorio.AdquirirLibros();
            return View(model);
        }
    }
}
