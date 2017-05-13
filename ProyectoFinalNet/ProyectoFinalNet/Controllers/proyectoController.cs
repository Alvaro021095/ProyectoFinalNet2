using System;
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
    public class proyectoController : Controller
    {
        private ProyectoNet2Entities1 db = new ProyectoNet2Entities1();

        // GET: /proyecto/
        public ActionResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.Cargo);
            return View(proyecto.ToList());
        }

        // GET: /proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: /proyecto/Create
        public ActionResult Create()
        {
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre");
            return View();
        }

        // POST: /proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,fecha_inicio,fecha_fin,etapa,Cargo_id")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.crearProyecto(proyecto.nombre, proyecto.fecha_inicio, proyecto.fecha_fin, proyecto.etapa, proyecto.Cargo_id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", proyecto.Cargo_id);
            return View(proyecto);
        }

        // GET: /proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", proyecto.Cargo_id);
            return View(proyecto);
        }

        // POST: /proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,fecha_inicio,fecha_fin,etapa,Cargo_id")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.editarProyecto(proyecto.id, proyecto.nombre, proyecto.fecha_inicio, proyecto.fecha_fin, proyecto.etapa,
                    proyecto.Cargo_id);
                return RedirectToAction("Index");
            }
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", proyecto.Cargo_id);
            return View(proyecto);
        }

        // GET: /proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: /proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarProyecto(id);
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
