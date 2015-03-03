using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models.DataTransferObjects;
using Models;

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
            var guest = _guestService.GetGuest(id);

            return View("Edit", guest);
        }

        [HttpPost]
        public ActionResult Edit(Guest editedGuest)
        {
            try
            {
                _guestService.EditGuest(editedGuest);

                return RedirectToAction("Index");
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
