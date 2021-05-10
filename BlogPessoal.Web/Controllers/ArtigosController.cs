﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;

namespace BlogPessoal.Web.Controllers
{
    public class ArtigosController : Controller
    {
        private BlogPessoalContexto db = new BlogPessoalContexto();

        // GET: Artigos
        public ActionResult Index()
        {
            var artigos = db.Artigos.Include(a => a.Autor).Include(a => a.CategoriaDeArtigo);
            return View(artigos.ToList());
        }

        // GET: Artigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // GET: Artigos/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.Autor, "Id", "Nome");
            ViewBag.CategotiaDeArtigoId = new SelectList(db.CategoriaDeArtigo, "Id", "Nome");
            return View();
        }

        // POST: Artigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Conteudo,DataPublicacao,CategotiaDeArtigoId,AutorId,Removido")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Artigos.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.Autor, "Id", "Nome", artigo.AutorId);
            ViewBag.CategotiaDeArtigoId = new SelectList(db.CategoriaDeArtigo, "Id", "Nome", artigo.CategotiaDeArtigoId);
            return View(artigo);
        }

        // GET: Artigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.Autor, "Id", "Nome", artigo.AutorId);
            ViewBag.CategotiaDeArtigoId = new SelectList(db.CategoriaDeArtigo, "Id", "Nome", artigo.CategotiaDeArtigoId);
            return View(artigo);
        }

        // POST: Artigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Conteudo,DataPublicacao,CategotiaDeArtigoId,AutorId,Removido")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.Autor, "Id", "Nome", artigo.AutorId);
            ViewBag.CategotiaDeArtigoId = new SelectList(db.CategoriaDeArtigo, "Id", "Nome", artigo.CategotiaDeArtigoId);
            return View(artigo);
        }

        // GET: Artigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artigo artigo = db.Artigos.Find(id);
            db.Artigos.Remove(artigo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
