using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;
using TrungTamYenMy.Models.BusinessModel;

namespace TrungTamYenMy.Controllers
{
    public class LopHocController : Controller
    {
        // GET: LopHoc
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        public ActionResult DsLopHocClient()
        {
            var lopHoc = db.LopHocs.Take(6).ToList();
            return View(lopHoc);
        }

        //public ActionResult ChiTietLopHoc(long id)
        //{
        //    var lopHoc = new LopHocDao().ViewDetail(id);
        //    return View(lopHoc);
        //}

        public ActionResult ChiTietLopHoc(long id)
        {
            var lophoc = db.LopHocs.SingleOrDefault(x => x.MaLop == id);
            if (lophoc == null)
            {
                return null;
            }
            return View(lophoc);
        }

        [ChildActionOnly]
        public PartialViewResult LopHocPartial()
        {
            var lopHoc = db.LopHocs.ToList();
            return PartialView(lopHoc);
        }


        public PartialViewResult KhoiHocPartial()
        {
            var khoi = db.LoaiLopHocs.ToList();
            return PartialView(khoi);
        }

        [OutputCache(Duration = int.MaxValue,VaryByParam = "id")]
        public ActionResult KhoiHoc(long id)
        {
            var khoiHoc=new LopHocDao().ViewDetail2(id);

            ViewBag.KhoiHoc = khoiHoc;
            var model = db.LopHocs.Where(x =>x.MaLoaiLop == id).ToList();
            return View(model);
        }

        public JsonResult ListName(string q)
        {
            var data = new LopHocDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TimKiem(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new LopHocDao().TimKiem(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

    }
}