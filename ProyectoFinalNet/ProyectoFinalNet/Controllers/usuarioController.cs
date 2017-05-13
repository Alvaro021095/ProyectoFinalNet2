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
    public class usuarioController : Controller
    {
        private ProyNet2Entities db = new ProyNet2Entities();

        // GET: /usuario/
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Tipo_Usuario1);
            return View(usuario.ToList());
        }

        // GET: /usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /usuario/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "id", "tipo");
            return View();
        }

        // POST: /usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,cedula,nombre,apellido,edad,telefono,usuario1,contrasenia,Tipo_Usuario,correo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                String usu = (string)(Session["Usuario"]);
                db.registrarUsuDirector(usuario.cedula, usuario.nombre, usuario.apellido, usuario.edad,
                    usuario.telefono, usu, usuario.contrasenia, 1, usuario.correo);
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "id", "tipo", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // GET: /usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "id", "tipo", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // POST: /usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,cedula,nombre,apellido,edad,telefono,usuario1,contrasenia,Tipo_Usuario,correo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "id", "tipo", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // GET: /usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
