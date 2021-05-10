using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Data.Mapeamento
{
    public class ArtigoMap : EntityTypeConfiguration<Artigo>
    {
        public ArtigoMap()
        {
            ToTable("artigo", "dbo");
            HasKey(t => t.Id);
            Property(x => x.Titulo).IsRequired().HasMaxLength(300).HasColumnName("titulo");
            Property(x => x.Conteudo).IsRequired().HasMaxLength(150).HasColumnName("conteudo");
            Property(x => x.DataPublicacao).IsRequired().HasColumnName("data_publicacao");
            Property(x => x.CategotiaDeArtigoId).IsRequired().HasColumnName("categoria_artigo_id");
            Property(x => x.AutorId).IsRequired().HasColumnName("autor_id");
            Property(x => x.Removido).IsRequired().HasColumnName("removido");

            HasRequired(t => t.CategoriaDeArtigo)
                .WithMany(t => t.Artigos)
                .HasForeignKey(t => t.CategotiaDeArtigoId)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Autor)
                .WithMany(t => t.Artigos)
                .HasForeignKey(t => t.AutorId)
                .WillCascadeOnDelete(false);
        }
    }
}