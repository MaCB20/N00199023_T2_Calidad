using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> AdquirirBibliotecaIndex(int id);
        Biblioteca AñadirBibliotecaAdd(Biblioteca biblioteca);
        Biblioteca ActualizarEstado01(int lId, int uId);
        Biblioteca ActualizarEstado02(int lId, int uId);
    }
    public class BibliotecaRepositorio : IBibliotecaRepositorio
    {
        private AppBibliotecaContext appBibliotecaContext;
        public BibliotecaRepositorio(AppBibliotecaContext appBibliotecaContext)
        {
            this.appBibliotecaContext = appBibliotecaContext;
        } 
        public List<Biblioteca> AdquirirBibliotecaIndex(int id)
        {
            return appBibliotecaContext.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }
        public Biblioteca AñadirBibliotecaAdd(Biblioteca biblioteca)
        {
            appBibliotecaContext.Bibliotecas.Add(biblioteca);
            appBibliotecaContext.SaveChanges();
            return biblioteca;
        }
        public Biblioteca ActualizarEstado01(int libroId, int usuarioId)
        {
           var libro = appBibliotecaContext.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == usuarioId)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            appBibliotecaContext.SaveChanges();
            return libro;
        }
        public Biblioteca ActualizarEstado02(int libroId, int usuarioId)
        {
            var libro = appBibliotecaContext.Bibliotecas
                 .Where(o => o.LibroId == libroId && o.UsuarioId == usuarioId)
                 .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            appBibliotecaContext.SaveChanges();
            return libro;
        }
    }
}