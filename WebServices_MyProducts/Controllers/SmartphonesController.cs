using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServices_MyProducts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebServices_MyProducts.Controllers
{
    public class SmartphonesController : Controller
    {
        private SmartPhonesContext db = new SmartPhonesContext();

        // GET: Smartphones
        public ActionResult Index()
        {
            //return View(db.Smartphones.ToList());
            var Smartphones =db.Smartphones;
            
            return Json(Smartphones, JsonRequestBehavior.AllowGet); 
        }

        // GET: Smartphones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // GET: Smartphones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,SousTitre,Description,Image")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Smartphones.Add(smartphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smartphone);
        }

        // GET: Smartphones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,SousTitre,Description,Image")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smartphone);
        }

        // GET: Smartphones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            db.Smartphones.Remove(smartphone);
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
