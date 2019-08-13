using System.Collections.Generic;
using WebApiDotNetCore21.Models;

namespace WebApiDotNetCore21.Repositories
{
    public interface ILivroRepositorio<TEntity> where TEntity : class
    {
        IList<Livro> GetAll();
        Livro Get(int Id);
        int Post(Livro objeto);
        int Put(Livro objeto);
        int Delete(int Id);
    }
}
