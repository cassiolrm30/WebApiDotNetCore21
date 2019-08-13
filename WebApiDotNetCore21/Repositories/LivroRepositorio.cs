using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApiDotNetCore21.Models;

namespace WebApiDotNetCore21.Repositories
{
    public class LivroRepositorio<TEntity> : ILivroRepositorio<TEntity> where TEntity : class
    {
        private readonly Contexto _contexto;

        public LivroRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IList<Livro> GetAll()
        {
            IList<Livro> resultado = new List<Livro>();
            try
            {
                resultado.Add(new Livro(1, "Livro I", "Cássio Matos", 100M, DateTime.Today));
                resultado.Add(new Livro(2, "Livro II", "Cássio Matos", 200M, DateTime.Today));
                resultado.Add(new Livro(3, "Livro III", "Cássio Matos", 300M, DateTime.Today));
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return resultado;
        }

        public Livro Get(int Id)
        {
            Livro resultado = new Livro();
            try
            {
                List<Livro> lista = new List<Livro>();
                lista.Add(new Livro(1, "Livro I", "Cássio Matos", 100M, DateTime.Today));
                lista.Add(new Livro(2, "Livro II", "Cássio Matos", 200M, DateTime.Today));
                lista.Add(new Livro(3, "Livro III", "Cássio Matos", 300M, DateTime.Today));
                foreach (var item in lista)
                {
                    if (item.LivroID == Id)
                    {
                        resultado = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return resultado;
        }

        public int Post(Livro objeto)
        {
            int resultado = 1;
            try
            {
                _contexto.Livros.Add(objeto);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            return resultado;
        }

        public int Put(Livro objeto)
        {
            int resultado = 1;
            try
            {
                _contexto.Entry(objeto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            return resultado;
        }

        public int Delete(int Id)
        {
            int resultado = 1;
            try
            {
                _contexto.Livros.Remove(_contexto.Livros.Find(Id));
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            return resultado;
        }
    }
}
