using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        TrungTamYenMyEntities db = new TrungTamYenMyEntities();

        public PartialViewResult SlidePartial()
        {
            var slide = db.Slides.ToList();
            return PartialView(slide);
        }
    }
}