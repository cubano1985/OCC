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

            public ActionResult Index()
        {
            var guestList = _guestService.GetGuestList();

            return View("Index", guestList);
        }

          public ActionResult Details(int id)
        {
            return View("Details");
        }

         public ActionResult Create()
        {
            return View("Create");
        }

            [HttpPost]
        public ActionResult Create(GuestDTO guest)
        {        
            try
            {
                if (ModelState.IsValid)
                {
                    _guestService.AddGuest(guest);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            return View("Edit");
        }

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

        public ActionResult Delete(int id)
        {
            _guestService.DeleteGuest(id);

            return RedirectToAction("Index");
        }

        public ActionResult GenderBalance()
        {
            var genderBalanceViewModel = _guestService.GetGenderBalanceViewModel();
            return PartialView("_genderBalance", genderBalanceViewModel);
        }

     
        
    }
}
