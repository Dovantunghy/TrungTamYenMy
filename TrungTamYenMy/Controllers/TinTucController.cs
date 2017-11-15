using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;
using TrungTamYenMy.Models.BusinessModel;

namespace TrungTamYenMy.Controllers
{
    public class TinTucController : Controller
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        // GET: TinTuc
        public PartialViewResult TinTucMoiPartial(int page=1,int pageSize=4)
        {
            int totalRecord = 0;
            var listTinTucMoi = new PhanTrangTinTuc().ListTinTuc(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return PartialView(listTinTucMoi);
        }

        public PartialViewResult TinTucNoiBatPartial(int page = 1, int pageSize = 4)
        {
            int totalRecord = 0;
            var listTinTucNoiBat = new PhanTrangTinTuc().ListTinTuc(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return PartialView(listTinTucNoiBat);
        }

        public PartialViewResult TinTucThiCuPartial(int page = 1, int pageSize = 4)
        {
            int totalRecord = 0;
            var listTinTucThiCu = new PhanTrangTinTuc().ListTinTuc(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;


            return PartialView(listTinTucThiCu);
        }

        public ActionResult DsTinTuc()
        {
            return View();
        }

        public ViewResult XemTinTuc(long MaTinTuc)
        {
            TinTuc XemTinTuc = db.TinTucs.SingleOrDefault(x => x.MaTinTuc == MaTinTuc);
            if (XemTinTuc==null)
            {
                return null;
            }
            return View(XemTinTuc);
        }

        public ActionResult TinMoiNhat(int page = 1, int pageSize = 12)
        {
            int totalRecord = 0;
            var listTinTucMoiNhat = new PhanTrangTinTuc().ListTinTuc1(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(listTinTucMoiNhat);
        }

        public ActionResult TinNoiBat(int page = 1, int pageSize = 12)
        {
            int totalRecord = 0;
            var listTinTucNoiBat = new PhanTrangTinTuc().ListTinTuc1(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(listTinTucNoiBat);
        }

        public ActionResult TinThiCu(int page = 1, int pageSize = 12)
        {
            int totalRecord = 0;
            var listTinTucThiCu = new PhanTrangTinTuc().ListTinTuc1(ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(listTinTucThiCu);
        }

        public PartialViewResult PhanHoiHocVien()
        {
            var listFeedback = db.FeedBacks.Where(x=>x.TrangThai==true).Take(4).ToList();
            return PartialView(listFeedback);
        }

    }
}