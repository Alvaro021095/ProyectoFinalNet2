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
    public class actividadController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /actividad/
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Integrante).Include(a => a.Proyecto);
            return View(actividad.ToList());
        }

        // GET: /actividad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: /actividad/Create
        public ActionResult Create()
        {
            ViewBag.Integrante_id = new SelectList(db.Integrante, "id", "id");
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre");
            return View();
        }

        // POST: /actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,fecha_inicio,fecha_fin,descripcion,Proyecto_id,Integrante_id")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.crearActividad(actividad.nombre, actividad.fecha_inicio, actividad.fecha_fin, actividad.descripcion,
                    actividad.Proyecto_id, actividad.Integrante_id);
                return RedirectToAction("Index");
            }

            ViewBag.Integrante_id = new SelectList(db.Integrante, "id", "id", actividad.Integrante_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", actividad.Proyecto_id);
            return View(actividad);
        }

        // GET: /actividad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Integrante_id = new SelectList(db.Integrante, "id", "id", actividad.Integrante_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", actividad.Proyecto_id);
            return View(actividad);
        }

        // POST: /actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,fecha_inicio,fecha_fin,descripcion,Proyecto_id,Integrante_id")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.editarActividad(actividad.id, actividad.nombre, actividad.fecha_inicio, actividad.fecha_fin, actividad.descripcion,
                    actividad.Proyecto_id, actividad.Integrante_id);
                return RedirectToAction("Index");
            }
            ViewBag.Integrante_id = new SelectList(db.Integrante, "id", "id", actividad.Integrante_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", actividad.Proyecto_id);
            return View(actividad);
        }

        // GET: /actividad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: /actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarActividad(id);
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
