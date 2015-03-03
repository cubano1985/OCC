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
        #region constructor
        private readonly ISerializeService _serializeService;

        public HomeController(ISerializeService serializeService)
        {            
            _serializeService = serializeService;
        }
        #endregion

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Refresh()
        {            
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
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
