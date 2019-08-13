using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDotNetCore21.Models;
using WebApiDotNetCore21.Repositories;

namespace WebApiDotNetCore21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepositorio<Livro> _repositorio;

        public LivrosController(ILivroRepositorio<Livro> repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IList<Livro> Get()
        {
            return _repositorio.GetAll();
        }

        [HttpGet("{id}")]
        public Livro Get(int id)
        {
            return _repositorio.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Livro obj)
        {
            _repositorio.Post(obj);
            return new ObjectResult("Livro adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Livro obj)
        {
            _repositorio.Put(obj);
            return new ObjectResult("Livro alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Delete(id);
            return new ObjectResult("Livro excluido com sucesso!");
        }
    }
}