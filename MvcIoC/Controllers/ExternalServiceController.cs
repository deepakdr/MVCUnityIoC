using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Controllers
{
    public class ExternalServiceController : Controller
    {

        private IExternalMovieService externalMovieService;
        public ExternalServiceController(IExternalMovieService extMvSvc)
        {
            this.externalMovieService = extMvSvc;
        }
        //
        // GET: /ExternalService/

        public ActionResult Index()
        {
            return Content(externalMovieService.GetBoxOfficeHit());
        }

    }
}
