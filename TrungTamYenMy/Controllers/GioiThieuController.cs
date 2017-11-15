using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Controllers
{
    public class GioiThieuController : Controller
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        // GET: GioiThieu
        public ActionResult GioiThieu()
        {
            var GioiThieu = db.Abouts.Take(1).ToList();
            return View(GioiThieu);
        }
    }
}