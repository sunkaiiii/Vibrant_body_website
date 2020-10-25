﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assignment.Controllers
{
    [Authorize(Roles = "Coach, User")]
    public class TrainingCoursesController : Controller
    {
        private FIT5032_Assignment_ModelContainer db = new FIT5032_Assignment_ModelContainer();
        private static readonly int PAGE_LIMIT = 20;

        // GET: TrainingCourses
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var trainingCourses = db.TrainingCourses.Where(course => course.AspNetUserId == userId).ToList();
            return View(trainingCourses);
        }


        public ActionResult AllCourses()
        {
            var trainingCourses = db.TrainingCourses.OrderByDescending(course => course.PublishDate).Take(PAGE_LIMIT).ToList();
            return View("Index",trainingCourses);
        }

        // GET: TrainingCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            return View(trainingCourse);
        }

        [Authorize(Roles = "Coach")]
        public ActionResult ControlBookings(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            var bookings = db.CourseBookings.Where(booking => booking.TrainingCourseId == trainingCourse.Id);
            return View(new ControlBookingViewModel { TrainingCourse = trainingCourse, Bookings = bookings});
        }

        [Authorize(Roles = "Coach")]
        // GET: TrainingCourses/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [Authorize(Roles = "Coach")]
        // POST: TrainingCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseName,CourseCapacity,CourseHeldLocation,CourseDescribtion,LocationLongitude,LocationLatitude")] CourseViewModel course)
        {
            
            if (ModelState.IsValid)
            {
                TrainingCourse trainingCourse = new TrainingCourse();
                trainingCourse.CourseName = course.CourseName;
                trainingCourse.CourseCapacity = course.CourseCapacity;
                trainingCourse.CourseHeldLocation = course.CourseHeldLocation;
                trainingCourse.LocationLatitude = course.LocationLatitude;
                trainingCourse.LocationLongitude = course.LocationLongitude;
                trainingCourse.PublishDate = DateTime.Now;
                trainingCourse.AspNetUserId = User.Identity.GetUserId();
                db.TrainingCourses.Add(trainingCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", User.Identity.GetUserId());
            return View(course);
        }

        [Authorize(Roles = "Coach")]
        // GET: TrainingCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", trainingCourse.AspNetUserId);
            return View(trainingCourse);
        }

        [Authorize(Roles = "Coach")]
        // POST: TrainingCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseName,CourseCapacity,CourseHeldLocation,CourseDescribtion,IsOver,Rate,AspNetUserId,PreRequestId")] TrainingCourse trainingCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", trainingCourse.AspNetUserId);
            return View(trainingCourse);
        }

        [Authorize(Roles = "Coach")]
        // GET: TrainingCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            if (trainingCourse == null)
            {
                return HttpNotFound();
            }
            return View(trainingCourse);
        }

        [Authorize(Roles = "Coach")]
        // POST: TrainingCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCourse trainingCourse = db.TrainingCourses.Find(id);
            db.TrainingCourses.Remove(trainingCourse);
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
