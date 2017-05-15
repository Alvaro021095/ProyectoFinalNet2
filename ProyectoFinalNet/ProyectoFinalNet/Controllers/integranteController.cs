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
    public class integranteController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /integrante/
        public ActionResult Index()
        {
            var integrante = db.Integrante.Include(i => i.Cargo).Include(i => i.Proyecto).Include(i => i.Usuario);
            return View(integrante.ToList());
        }

        // GET: /integrante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integrante integrante = db.Integrante.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            return View(integrante);
        }

        // GET: /integrante/Create
        public ActionResult Create()
        {
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre");
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre");
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "cedula");
            return View();
        }

        // POST: /integrante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Proyecto_id,Cargo_id,Usuario_id")] Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                db.crearIntegrante(integrante.Proyecto_id, integrante.Cargo_id, integrante.Usuario_id);
                return RedirectToAction("Index");
            }

            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", integrante.Cargo_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", integrante.Proyecto_id);
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "cedula", integrante.Usuario_id);
            return View(integrante);
        }

        // GET: /integrante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integrante integrante = db.Integrante.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", integrante.Cargo_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", integrante.Proyecto_id);
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "cedula", integrante.Usuario_id);
            return View(integrante);
        }

        // POST: /integrante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Proyecto_id,Cargo_id,Usuario_id")] Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                db.editarIntegrante(integrante.id, integrante.Proyecto_id, integrante.Cargo_id, integrante.Usuario_id);
                return RedirectToAction("Index");
            }
            ViewBag.Cargo_id = new SelectList(db.Cargo, "id", "nombre", integrante.Cargo_id);
            ViewBag.Proyecto_id = new SelectList(db.Proyecto, "id", "nombre", integrante.Proyecto_id);
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "cedula", integrante.Usuario_id);
            return View(integrante);
        }

        // GET: /integrante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integrante integrante = db.Integrante.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            return View(integrante);
        }

        // POST: /integrante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarIntegrante(id);
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
