﻿using BlogPessoal.Web.Data.Mapeamento;
using BlogPessoal.Web.Models;
using System.Data.Entity;

namespace BlogPessoal.Web.Data.Contexto
{
    public class BlogPessoalContexto : DbContext
    {
        public BlogPessoalContexto()
            : base(typeof(BlogPessoalContexto).Name)
        {

        }

        public DbSet<CategoriaDeArtigo> CategoriaDeArtigo { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaDeArtigoMap());
            modelBuilder.Configurations.Add(new AutorMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}