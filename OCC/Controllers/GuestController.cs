using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models.DataTransferObjects;

namespace OCC.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;        

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;            
        }

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            var guestList = _guestService.GetGuestList();

            return View("Index", guestList);
        }

        //
        // GET: /Guest/Details/5

        public ActionResult Details(int id)
        {
            return View("Details");
        }

        //
        // GET: /Guest/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        public ActionResult Create(GuestDTO guest)
        {
            bool result;
            string errorMessage;

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    result = _guestService.AddGuest(guest, out errorMessage);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Create");
            }
        }

        //
        // GET: /Guest/Edit/5

        public ActionResult Edit(int id)
        {
            return View("Edit");
        }

        //
        // POST: /Guest/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Edit");
            }
        }

        //
        // GET: /Guest/Delete/5

        public ActionResult Delete(int id)
        {
            return View("Delete");
        }

        //
        // POST: /Guest/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
