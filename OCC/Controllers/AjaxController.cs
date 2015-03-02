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

        public AjaxController(IValidateService validateService)
        {
            _validateService = validateService;            
        }

        public JsonResult ValidateNameSurname(string name, string surname)
        {
            var serviceResult = _validateService.IsGuestInDb(name, surname);
            return Json(serviceResult);
        }
    }
}