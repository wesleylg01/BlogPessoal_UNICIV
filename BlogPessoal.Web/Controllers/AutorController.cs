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
    public class AutorController : Controller
    {
        private BlogPessoalContexto _ctx = new BlogPessoalContexto();

        public ActionResult Index()
        {
            var autores = _ctx.Autor
                .OrderBy(t => t.Nome)
                .ToList();

            return View(autores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _ctx.Autor.Add(autor);
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(autor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var autor = _ctx.Autor.Find(id);

            if (autor == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(autor);
            }
        }

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(autor).State = EntityState.Modified;
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(autor);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var autor = _ctx.Autor.Find(id);

            if (autor == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(autor);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var autor = _ctx.Autor.Find(id);

            _ctx.Autor.Remove(autor);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}