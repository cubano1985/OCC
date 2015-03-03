using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace OCC.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly ISerializeService _serializeService;

        public HomeController(ISerializeService serializeService)
        {            
            _serializeService = serializeService;
        }
        
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Refresh()
        {            
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult SaveAllGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            var savePath = _serializeService.SerializeFullGuestList(path);

            return RedirectToAction("Index");
        }

        public ActionResult SaveAttendingGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            var savePath = _serializeService.SerializeAttendingGuestList(path);

            return RedirectToAction("Index");
        }

        public ActionResult LoadAllGuests()
        {
            var path = Server.MapPath("~/SerializedData");
            var isLoadSuccessful = _serializeService.DeserializeFullGuestList(path);
            
            if (isLoadSuccessful == false)
            {
                return View("FailedLoad");
            }

            return RedirectToAction("Index");
        }
    }
}
