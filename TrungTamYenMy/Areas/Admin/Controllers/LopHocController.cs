using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class LopHocController : BaseController
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        // GET: Admin/LopHoc
        public ActionResult DsLopHoc()
        {
            var listLopHoc = db.LopHocs.ToList();
            return View(listLopHoc);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult ThemMoi()
        {
            ViewBag.MaLoaiLop = new SelectList(db.LoaiLopHocs.ToList().OrderBy(x => x.TenLoaiLop), "MaLoaiLop", "TenLoaiLop");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(LopHoc lopHoc, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLoaiLop = new SelectList(db.LoaiLopHocs.ToList().OrderBy(x => x.TenLoaiLop), "MaLoaiLop", "TenLoaiLop");
            //kiểm tra đường dẫn
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Bạn chưa chọn ảnh bài viết!";
                return View();
            }

            //Thêm vào csdl
            if (ModelState.IsValid)
            {
                //Lưu tên của file
                var filename = Path.GetFileName(fileUpload.FileName);

                //Lưu đường dẫm của fileName
                var duongDan = Path.Combine(Server.MapPath("~/Assets/client/images"), filename);

                //kiểm tra tồn tại của hình ảnh
                if (System.IO.File.Exists(duongDan))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(duongDan);
                }

                lopHoc.HinhAnh = fileUpload.FileName;
                db.LopHocs.Add(lopHoc);
                db.SaveChanges();
                TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm lớp học thành công</div>";
                return RedirectToAction("DsLopHoc");
            }
            else
            {
                TempData["err"] =
              "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm lớp học thất bại</div>";
            }
            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult ChinhSua(long MaLop)
        {
            ViewBag.MaLoaiLop = new SelectList(db.LoaiLopHocs.ToList().OrderBy(x => x.TenLoaiLop), "MaLoaiLop", "TenLoaiLop");

            var lopHoc = db.LopHocs.SingleOrDefault(x => x.MaLop == MaLop);

            return View(lopHoc);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(LopHoc lopHoc)
        {
            ViewBag.MaLoaiLop = new SelectList(db.LoaiLopHocs.ToList().OrderBy(x => x.TenLoaiLop), "MaLoaiLop", "TenLoaiLop");
            if (ModelState.IsValid)
            {
                db.Entry(lopHoc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa lớp học thành công</div>";
                return RedirectToAction("DsLopHoc");
            }
            else
            {
                TempData["err"] =
                "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa lớp học thất bại</div>";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Xoa(long MaLop)
        {
            var lopHoc = db.LopHocs.SingleOrDefault(x => x.MaLop == MaLop);

            return View(lopHoc);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(long MaLop)
        {
            var lopHoc = db.LopHocs.SingleOrDefault(x => x.MaLop == MaLop);
            if (lopHoc==null)
            {
                return null;
            }
            db.LopHocs.Remove(lopHoc);
            db.SaveChanges();
            TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Xóa lớp học thành công</div>";
            return RedirectToAction("DsLopHoc");
        }

        public ActionResult Thh()
        {
            return View();
        }
    }
}