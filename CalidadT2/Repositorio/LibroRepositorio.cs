using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepositorio
    {
        List<Libro> AdquirirLibros();
        Libro Llibro(int id);
        Libro AñadirComentario(Comentario comentario);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private AppBibliotecaContext appBibliotecaContext;
        public LibroRepositorio (AppBibliotecaContext appBibliotecaContext)
        {
            this.appBibliotecaContext = appBibliotecaContext;
        }
        public List<Libro> AdquirirLibros()
        {
            return appBibliotecaContext.Libros.Include(o => o.Autor).ToList();
        }

        public Libro Llibro(int id){

            return appBibliotecaContext.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public Libro AñadirComentario(Comentario comentario)
        {
            appBibliotecaContext.Comentarios.Add(comentario);

            var libro = appBibliotecaContext.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            appBibliotecaContext.SaveChanges();

            return libro;
        }
    }
}
