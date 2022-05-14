using CalidadT2.Controllers;
using CalidadT2.Models;
using System.Linq;
using System.Security.Claims;

namespace CalidadT2.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario obtenerUsuario(string user);
    }
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppBibliotecaContext app;
        public UsuarioRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public Usuario obtenerUsuario(string user)
        {
            return app.Usuarios.Where(o => o.Username == user).FirstOrDefault();
        }
    }
}
