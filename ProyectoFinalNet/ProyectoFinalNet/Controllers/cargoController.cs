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
    public class cargoController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /cargo/
        public ActionResult Index()
        {
            return View(db.Cargo.ToList());
        }

        // GET: /cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: /cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /cargo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,salario,horario")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.crearCargo(cargo.nombre, cargo.salario, cargo.horario);
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: /cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: /cargo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,salario,horario")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.editarCargo(cargo.id, cargo.nombre, cargo.salario, cargo.horario);
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: /cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: /cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.eliminarCargo(id);
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
