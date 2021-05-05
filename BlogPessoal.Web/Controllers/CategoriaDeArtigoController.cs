using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriaDeArtigoController : Controller
    {
        private BlogPessoalContexto _ctx = new BlogPessoalContexto();
        // GET: CategoriaDeArtigo
        public ActionResult Index()
        {
            var categorias = _ctx.CategoriaDeArtigo
                .OrderBy(t => t.Nome)
                .ToList();

            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.CategoriaDeArtigo.Add(categoria);
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
            var categoria = _ctx.CategoriaDeArtigo.Find(id);

            if(categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        [HttpPost]
        public ActionResult Edit (CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(categoria).State = EntityState.Modified;
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = _ctx.CategoriaDeArtigo.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult Delete (int id)
        {
            var categoria = _ctx.CategoriaDeArtigo.Find(id);

            _ctx.CategoriaDeArtigo.Remove(categoria);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}