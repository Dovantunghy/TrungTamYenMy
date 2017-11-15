using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class ThoiKhoaBieuController : BaseController
    {
        // GET: Admin/ThoiKhoaBieu
        public ActionResult Index()
        {
            return View();
        }
    }
}