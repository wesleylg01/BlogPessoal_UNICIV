using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Data.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor", "dbo");
            HasKey(t => t.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(150).HasColumnName("nome");
            Property(x => x.Email).IsRequired().HasMaxLength(150).HasColumnName("email");
            Property(x => x.Senha).IsRequired().HasMaxLength(150).HasColumnName("senha");
            Property(x => x.Administrador).IsRequired().HasColumnName("administrador");
            Property(x => x.Data_Cadastro).IsOptional().HasColumnName("data_cadastro");
        }
    }
}