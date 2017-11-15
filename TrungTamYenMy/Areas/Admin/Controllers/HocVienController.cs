using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class HocVienController : BaseController
    {
        private TrungTamYenMyEntities db = new TrungTamYenMyEntities();
        
        public ActionResult DsHocVien()
        {
            var listHV = db.HocViens.ToList();
            return View(listHV);
        }

        //Thêm học viên
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaLop=new SelectList(db.LopHocs.ToList().OrderBy(x=>x.TenLop),"MaLop","TenLop");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(HocVien hocVien)
        {
            ViewBag.MaLop = new SelectList(db.LopHocs.ToList().OrderBy(x => x.TenLop), "MaLop", "TenLop");
            if (ModelState.IsValid)
            {
                db.HocViens.Add(hocVien);
                db.SaveChanges();
                TempData["err"] =
                "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm học viên thành công</div>";
                return RedirectToAction("DsHocVien");
            }
            else
            {
                TempData["err"] =
                "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class'sr-only'></span>Thêm học viên thất bại</div>";
            }
            return View();
        }

        //chỉnh sửa học viên

        [HttpGet]
        public ActionResult ChinhSua(long MaHV)
        {
            ViewBag.MaLop = new SelectList(db.LopHocs.ToList().OrderBy(x => x.TenLop), "MaLop", "TenLop");
            HocVien hocvien = db.HocViens.SingleOrDefault(x => x.MaHV == MaHV);

            if (hocvien==null)
            {
                return null;
            }

            return View(hocvien);
        }

        [HttpPost]
        public ActionResult ChinhSua(HocVien hocVien)
        {
            ViewBag.MaLop = new SelectList(db.LopHocs.ToList().OrderBy(x => x.TenLop), "MaLop", "TenLop");
            if (ModelState.IsValid)
            {
                db.Entry(hocVien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["err"] =
                 "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa học viên thành công</div>";
                return RedirectToAction("DsHocVien");
            }
            else
            {
                TempData["err"] =
               "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class'sr-only'></span>Sửa học viên thất bại</div>";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Xoa(long MaHV)
        {
            var hocVien = db.HocViens.SingleOrDefault(x => x.MaHV == MaHV);

            if (hocVien==null)
            {
                return null;
            }
            return View(hocVien);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(long MaHV)
        {
            var hocVien = db.HocViens.SingleOrDefault(x => x.MaHV == MaHV);

            if (hocVien == null)
            {
                TempData["err"] =
               "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class'sr-only'></span>Xóa học viên thất bại</div>";
            }
            db.HocViens.Remove(hocVien);
            db.SaveChanges();
            TempData["err"] =
                "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span><span class'sr-only'></span>Xóa học viên tành công</div>";
            return RedirectToAction("DsHocVien");
        }
    }
}