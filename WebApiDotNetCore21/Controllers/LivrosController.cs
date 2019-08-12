using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDotNetCore21.Models;

namespace WebApiDotNetCore21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : Controller
    {
        private readonly Contexto _contexto;

        public LivrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public List<Livro> Get()
        {
            List<Livro> resultado = new List<Livro>();
            resultado.Add(new Livro(1, "Livro I", "Cássio Matos", 100M, DateTime.Today));
            resultado.Add(new Livro(2, "Livro II", "Cássio Matos", 200M, DateTime.Today));
            resultado.Add(new Livro(3, "Livro III", "Cássio Matos", 300M, DateTime.Today));
            return resultado;
            //return _contexto.Livros.ToList();
        }

        [HttpGet("{id}")]
        public Livro Get(int id)
        {
            List<Livro> resultado = new List<Livro>();
            resultado.Add(new Livro(1, "Livro I", "Cássio Matos", 100M, DateTime.Today));
            resultado.Add(new Livro(2, "Livro II", "Cássio Matos", 200M, DateTime.Today));
            resultado.Add(new Livro(3, "Livro III", "Cássio Matos", 300M, DateTime.Today));
            return resultado.FirstOrDefault(l => l.LivroID == id);
            //return _contexto.Livros.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Livro obj)
        {
            _contexto.Livros.Add(obj);
            _contexto.SaveChanges();
            return new ObjectResult("Livro adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Livro obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            _contexto.SaveChanges();
            return new ObjectResult("Livro alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contexto.Livros.Remove(_contexto.Livros.Find(id));
            _contexto.SaveChanges();
            return new ObjectResult("Livro excluido com sucesso!");
        }
    }
}