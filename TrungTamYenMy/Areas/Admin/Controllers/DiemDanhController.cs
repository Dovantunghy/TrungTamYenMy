using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class DiemDanhController : BaseController
    {
        // GET: Admin/DiemDanh
        public ActionResult Index()
        {
            return View();
        }
    }
}