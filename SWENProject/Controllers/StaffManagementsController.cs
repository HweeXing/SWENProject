﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWENProject.Models;

namespace SWENProject.Controllers
{
    public class StaffManagementsController : Controller
    {
        private Model1 db = new Model1();

        // GET: StaffManagements
        public ActionResult Index()
        {
            return View(db.StaffManagements.ToList());
        }

        // GET: StaffManagements/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            if (staffManagement == null)
            {
                return HttpNotFound();
            }
            return View(staffManagement);
        }

        // GET: StaffManagements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,StaffName,DateOfBirth,BankAccountNumber,MailingAddress,PhoneNumber,DutyTypes")] StaffManagement staffManagement)
        {
            if (ModelState.IsValid)
            {
                db.StaffManagements.Add(staffManagement);
                db.SaveChanges();
                return RedirectToAction("StaffManagement", "Home");
            }

            return View(staffManagement);
        }

        // GET: StaffManagements/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            if (staffManagement == null)
            {
                return HttpNotFound();
            }
            return View(staffManagement);
        }

        // POST: StaffManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,StaffName,DateOfBirth,BankAccountNumber,MailingAddress,PhoneNumber,DutyTypes")] StaffManagement staffManagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffManagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StaffManagement", "Home");
            }
            return View(staffManagement);
        }

        // GET: StaffManagements/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            if (staffManagement == null)
            {
                return HttpNotFound();
            }
            return View(staffManagement);
        }

        // POST: StaffManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StaffManagement staffManagement = db.StaffManagements.Find(id);
            db.StaffManagements.Remove(staffManagement);
            db.SaveChanges();
            return RedirectToAction("StaffManagement", "Home");
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
