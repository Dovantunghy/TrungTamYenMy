using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class NhanVienController : BaseController
    {
        TrungTamYenMyEntities db = new TrungTamYenMyEntities();
        // GET: Admin/NhanVien
        public ActionResult DsNhanVien()
        {
            var listNhanVien = db.NhanViens.ToList();
            return View(listNhanVien);
        }

        //thêm mới nhân viên
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                TempData["err"] =
                    "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm nhân viên thành công</div>";
                return RedirectToAction("DsNhanVien");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(long MaNV)
        {
            NhanVien nhanVien = db.NhanViens.SingleOrDefault(x => x.MaNV == MaNV);
            if (nhanVien == null)
            {
                return null;
            }
            return View(nhanVien);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            TempData["err"] =
                "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa nhân viên thành công</div>";
            return RedirectToAction("DsTinTuc", "TinTuc");
        }


        public ActionResult Xoa(long maNhanVien)
        {
            NhanVien nhanVien = db.NhanViens.SingleOrDefault(x => x.MaNV == maNhanVien);
            if (nhanVien == null)
            {
                return null;
            }
            return View(nhanVien);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(long maNhanVien)
        {
            NhanVien nhanVien = db.NhanViens.SingleOrDefault(x => x.MaNV == maNhanVien);

            if (nhanVien == null)
            {
                return null;
            }
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            TempData["err"] =
                "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Xóa tin tức thành công</div>";
            return RedirectToAction("DsTinTuc");
        }
    }
}