using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ineq_Lusoft.Models;

namespace Ineq_Lusoft.Controllers
{
    public class ComponentsController : Controller
    {
        private Lusoft_Models db = new Lusoft_Models();

        // GET: Components
        public ActionResult Index()
        {
            var component = db.Component.Include(c => c.ComponentType).Include(c => c.Equipment).Include(c => c.EquipmentType);
            return View(component.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        public ActionResult Create()
        {
            ViewBag.ComponentTypeId = new SelectList(db.ComponentType, "Id", "Description");
            ViewBag.Equipment_Id = new SelectList(db.Equipment, "Id", "Serie");
            ViewBag.EquipmentType_Id = new SelectList(db.EquipmentType, "Id", "Description");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Active,ComponentTypeId,Equipment_Id,EquipmentType_Id")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Component.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComponentTypeId = new SelectList(db.ComponentType, "Id", "Description", component.ComponentTypeId);
            ViewBag.Equipment_Id = new SelectList(db.Equipment, "Id", "Serie", component.Equipment_Id);
            ViewBag.EquipmentType_Id = new SelectList(db.EquipmentType, "Id", "Description", component.EquipmentType_Id);
            return View(component);
        }

        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponentTypeId = new SelectList(db.ComponentType, "Id", "Description", component.ComponentTypeId);
            ViewBag.Equipment_Id = new SelectList(db.Equipment, "Id", "Serie", component.Equipment_Id);
            ViewBag.EquipmentType_Id = new SelectList(db.EquipmentType, "Id", "Description", component.EquipmentType_Id);
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Active,ComponentTypeId,Equipment_Id,EquipmentType_Id")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComponentTypeId = new SelectList(db.ComponentType, "Id", "Description", component.ComponentTypeId);
            ViewBag.Equipment_Id = new SelectList(db.Equipment, "Id", "Serie", component.Equipment_Id);
            ViewBag.EquipmentType_Id = new SelectList(db.EquipmentType, "Id", "Description", component.EquipmentType_Id);
            return View(component);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Component.Find(id);
            db.Component.Remove(component);
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
