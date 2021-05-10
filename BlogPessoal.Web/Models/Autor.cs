using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public DateTime Data_Cadastro{ get; set; }

        public virtual ICollection<Artigo> Artigos { get; set; }
    }
}