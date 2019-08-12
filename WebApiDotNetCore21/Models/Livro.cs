using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotNetCore21.Models
{
    public class Livro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int LivroID { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public DateTime DataPublicacao { get; set; }

        public Livro()
        {

        }

        public Livro(int _id, string _titulo, string _autor, decimal _preco, DateTime _dataPublicacao)
        {
            this.LivroID        = _id;
            this.Titulo         = _titulo;
            this.Autor          = _autor;
            this.Preco          = _preco;
            this.DataPublicacao = _dataPublicacao;
        }
    }
}