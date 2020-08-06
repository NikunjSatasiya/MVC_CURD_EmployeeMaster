using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeMaster.Models;

namespace EmployeeMaster.Controllers
{
    public class tblEmployeeMastersController : Controller
    {
        private EmployeeMasterDBContext db = new EmployeeMasterDBContext();

        // GET: tblEmployeeMasters
        public ActionResult Index()
        {
            var tblEmployeeMasters = db.tblEmployeeMasters.Include(t => t.tblDepartment);
            return View(tblEmployeeMasters.ToList());
        }

        // GET: tblEmployeeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeMaster tblEmployeeMaster = db.tblEmployeeMasters.Find(id);
            if (tblEmployeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployeeMaster);
        }

        // GET: tblEmployeeMasters/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: tblEmployeeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,First_Name,Last_Name,Age,Salary,DepartmentID")] tblEmployeeMaster tblEmployeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployeeMasters.Add(tblEmployeeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "DepartmentName", tblEmployeeMaster.DepartmentID);
            return View(tblEmployeeMaster);
        }

        // GET: tblEmployeeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeMaster tblEmployeeMaster = db.tblEmployeeMasters.Find(id);
            if (tblEmployeeMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "DepartmentName", tblEmployeeMaster.DepartmentID);
            return View(tblEmployeeMaster);
        }

        // POST: tblEmployeeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,First_Name,Last_Name,Age,Salary,DepartmentID")] tblEmployeeMaster tblEmployeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployeeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "DepartmentName", tblEmployeeMaster.DepartmentID);
            return View(tblEmployeeMaster);
        }

        // GET: tblEmployeeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeMaster tblEmployeeMaster = db.tblEmployeeMasters.Find(id);
            if (tblEmployeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployeeMaster);
        }

        // POST: tblEmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployeeMaster tblEmployeeMaster = db.tblEmployeeMasters.Find(id);
            db.tblEmployeeMasters.Remove(tblEmployeeMaster);
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
