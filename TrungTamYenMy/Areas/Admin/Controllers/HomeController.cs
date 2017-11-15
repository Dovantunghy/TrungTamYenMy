using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;


namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private TrungTamYenMyEntities db = new TrungTamYenMyEntities();
        // GET: Admin/Home

        public ActionResult Index(string UserName)
        {
            var soHocVien = db.HocViens.Count();
            ViewBag.SoHV = soHocVien;

            var soGiaoVien = db.GiaoViens.Count();
            ViewBag.SoGV = soGiaoVien;

            var soTinTuc = db.TinTucs.Count();
            ViewBag.SoTT = soTinTuc;

            var soPhanHoi = db.FeedBacks.Count();
            ViewBag.SoPhanHoi = soPhanHoi;

            return View();

        }


    }
}