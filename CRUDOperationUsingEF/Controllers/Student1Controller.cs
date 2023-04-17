using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDOperationUsingEF.Models;

namespace CRUDOperationUsingEF.Controllers
{
    public class Student1Controller : Controller
    {
        private StudentDbContext db = new StudentDbContext();

        // GET: Student1
        public ActionResult Index()
        {
            return View(db.Student1.ToList());
        }

        // GET: Student1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = db.Student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // GET: Student1/Create
        public ActionResult Create()
        {
            ViewBag.TrainerId = db.Trainers.Select(
                t => new SelectListItem() { Text=t.Name,Value=t.TrainerId.ToString()}
                );
            return View();
        }

        // POST: Student1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollNumber,Name,Age,Email,DateOfBirth,AddedDate,City,TrainerId")] Student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.Student1.Add(student1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student1);
        }

        // GET: Student1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = db.Student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }

            ViewBag.TrainerId = db.Trainers.Select(
                t => new SelectListItem() { Text = t.Name, 
                    Value = t.TrainerId.ToString(),
                    Selected=t.TrainerId==student1.TrainerId
                }
                );
            return View(student1);
        }

        // POST: Student1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollNumber,Name,Age,Email,DateOfBirth,AddedDate,City,TrainerId")] Student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student1);
        }

        // GET: Student1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = db.Student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // POST: Student1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student1 student1 = db.Student1.Find(id);
            db.Student1.Remove(student1);
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

        [HttpGet]
        public ActionResult StudentsByTrainers(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            var students = db.Student1.Where(s => s.TrainerId == id);

            return View(students);
        }
    }
}
