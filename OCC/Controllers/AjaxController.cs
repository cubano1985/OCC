﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace OCC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IValidateService _validateService;
        private readonly IGuestService _guestService;
        private readonly ISerializeService _serializeService;

        public AjaxController(IValidateService validateService, IGuestService guestService, 
            ISerializeService serializeService)
        {
            _validateService = validateService;
            _guestService = guestService;
            _serializeService = serializeService;
        }

        public JsonResult ValidateNameSurname(string name, string surname)
        {
            var serviceResult = _validateService.IsGuestInDb(name, surname);
            return Json(serviceResult);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int guestId, string newStatus)
        {
            _guestService.ChangeStatus(guestId, newStatus);
            return null;
        }

        public ActionResult SaveAllGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            var savePath = _serializeService.SerializeFullGuestList(path);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SaveAttendingGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            var savePath = _serializeService.SerializeAttendingGuestList(path);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoadAllGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            _serializeService.DeserializeFullGuestList(path);

            return RedirectToAction("Index", "Home");
        }
    }
}