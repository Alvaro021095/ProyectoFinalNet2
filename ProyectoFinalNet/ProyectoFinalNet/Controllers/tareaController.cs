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
    public class tareaController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /tarea/
        public ActionResult Index()
        {
            return View(db.Tarea.ToList());
        }

        // GET: /tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: /tarea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,fecha_inicio,fecha_fin,porcentaje,estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.crearTarea(tarea.nombre, tarea.fecha_inicio, tarea.fecha_fin, tarea.porcentaje, tarea.estado);
                return RedirectToAction("Index");
            }

            return View(tarea);
        }

        // GET: /tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: /tarea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,fecha_inicio,fecha_fin,porcentaje,estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.editarTarea(tarea.id, tarea.nombre, tarea.fecha_inicio, tarea.fecha_fin, tarea.porcentaje, tarea.estado);
                return RedirectToAction("Index");
            }
            return View(tarea);
        }

        // GET: /tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: /tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarTarea(id);
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
