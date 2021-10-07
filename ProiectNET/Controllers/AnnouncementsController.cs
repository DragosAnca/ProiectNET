﻿using ProiectNET.Models;
using ProiectNET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectNET.Controllers
{
    public class AnnouncementsController : Controller
    {
        private AnnouncementRepository announcementRepository = new AnnouncementRepository();

        // GET: Announcements
        public ActionResult Index()
        {
            List<AnnouncementModel> announcements = announcementRepository.GetAllAnnouncements();

            return View("Index", announcements);
        }

        // GET: Announcements/Details/5
        public ActionResult Details(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("Details", announcementModel);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: Announcements/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.InsertAnnouncement(announcementModel);

                return RedirectToAction("Index");
            }
            catch
            {

                return View("CreateAnnouncement");
            }
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("EditAnnouncement", announcementModel);
        }

        // POST: Announcements/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.UpdateAnnouncement(announcementModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAnnouncement");
            }
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("Delete", announcementModel);
        }

        // POST: Announcements/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                announcementRepository.DeleteAnnouncement(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
