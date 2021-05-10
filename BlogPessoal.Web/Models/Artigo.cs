using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPublicacao { get; set; }
        public int CategotiaDeArtigoId { get; set; }
        public int AutorId { get; set; }
        public bool Removido { get; set; }

        public virtual CategoriaDeArtigo CategoriaDeArtigo { get; set; }
        public virtual Autor Autor { get; set; }
    }
}