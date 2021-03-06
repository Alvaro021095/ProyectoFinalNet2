﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Platform.Entity.Entity;

namespace ProyectoFinalNet.Controllers
{
    public class reunionController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /reunion/
        public ActionResult Index()
        {
            var reunion = db.Reunion.Include(r => r.Proyecto);
            return View(reunion.ToList());
        }

        // GET: /reunion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            return View(reunion);
        }

        // GET: /reunion/Create
        public ActionResult Create()
        {
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre");
            return View();
        }

        // POST: /reunion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,lugar,tematica,Proyecto_id")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                db.crearReunion(reunion.lugar, reunion.tematica, reunion.Proyecto_id);
                return RedirectToAction("Index");
            }

            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", reunion.Proyecto_id);
            return View(reunion);
        }

        // GET: /reunion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", reunion.Proyecto_id);
            return View(reunion);
        }

        // POST: /reunion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,lugar,tematica,Proyecto_id")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                db.editarReunion(reunion.id, reunion.lugar, reunion.tematica, reunion.Proyecto_id);
                return RedirectToAction("Index");
            }
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", reunion.Proyecto_id);
            return View(reunion);
        }

        // GET: /reunion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reunion reunion = db.Reunion.Find(id);
            if (reunion == null)
            {
                return HttpNotFound();
            }
            return View(reunion);
        }

        // POST: /reunion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarReunion(id);
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
