﻿using BlogPessoal.Web.Data.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BlogPessoal.Tests
{
    [TestClass]
    public class CategoriaDeArtigoTest
    {
        [TestMethod]
        public void Consultar_artigo_com_sucesso()
        {
            var ctx = new BlogPessoalContexto();
            
            var obj = ctx.CategoriaDeArtigo.FirstOrDefault();

            Assert.IsNotNull(obj);
        }
    }
}
