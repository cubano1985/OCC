using System;
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

        public AjaxController(IValidateService validateService, IGuestService guestService)
        {
            _validateService = validateService;
            _guestService = guestService;
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

        
    }
}