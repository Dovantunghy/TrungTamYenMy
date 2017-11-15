using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Controllers
{
    public class GiaoVienController : Controller
    {
        TrungTamYenMyEntities db = new TrungTamYenMyEntities();

        // GET: GiaoVien
        public PartialViewResult DsGiaoVienPartial()
        {
            var listGiaoVien = db.GiaoViens.ToList();
            return PartialView(listGiaoVien);
        }

        public ActionResult ThongTinGiaoVien(long MaGV)
        {
            var giaovien = db.GiaoViens.SingleOrDefault(x => x.MaGV == MaGV);
            if (giaovien == null)
            {
                return null;
            }
            return View(giaovien);
        }

        public ActionResult DoiNguGiaoVien()
        {
            var listGiaoVien = db.GiaoViens.ToList();
            return View(listGiaoVien);
        }


        public ActionResult Order()
        {
            List<GiaoVien> lstFoods = db.GiaoViens.ToList();
            return View(lstFoods);
        }
    }
}