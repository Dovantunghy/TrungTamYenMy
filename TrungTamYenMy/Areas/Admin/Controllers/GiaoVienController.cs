using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class GiaoVienController : BaseController
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();

        //Load danh sách giáo viên
        public ActionResult DsGiaoVien()
        {
            var listGV = db.GiaoViens.ToList();
            return View(listGV);
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //đổ dl vào dropdownlist bằng viewbag
            ViewBag.MaLop=new SelectList(db.LopHocs.ToList().OrderBy(x=>x.TenLop),"MaLop","TenLop");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(GiaoVien giaoVien, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLop=new SelectList(db.LopHocs.ToList().OrderBy(x=>x.TenLop),"MaLop","TenLop");

            //kiểm tra đường dẫn
            if (fileUpload==null)
            {
                ViewBag.ThongBao = "Bạn chưa chọn ảnh cho giáo viên!";
            }

            //thêm vào csdl
            if (ModelState.IsValid)
            {
                //lưu tên của file
                var fileName = Path.GetFileName(fileUpload.FileName);

                //Lưu đường dẫn file
                var duongdan=Path.Combine(Server.MapPath("~/Assets/client/images"), fileName);

                //kiểm tra tồn tại của hình ảnh
                if (System.IO.File.Exists(duongdan))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                }
                giaoVien.Anh = "~/Assets/client/images/" + fileUpload.FileName;
                db.GiaoViens.Add(giaoVien);
                db.SaveChanges();
                TempData["err"] =
               "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm giáo viên thành công</div>";
                return RedirectToAction("DsGiaoVien");
            }
            else
            {
                TempData["err"] =
              "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm giáo viên thất bại</div>";
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(long MaGV)
        {
            GiaoVien giaoVien = db.GiaoViens.SingleOrDefault(x => x.MaGV == MaGV);
            
            if (giaoVien==null)
            {
                return null;
            }

            ViewBag.MaLop = new SelectList(db.LopHocs.ToList().OrderBy(x => x.TenLop), "MaLop", "TenLop");
            return View(giaoVien);
        }

        [HttpPost]
        public ActionResult ChinhSua(GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoVien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["err"] =
                               "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa giáo viên thành công</div>";
                return RedirectToAction("DsGiaoVien");
            }
            else
            {
                TempData["err"] =
               "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa học viên thất bại</div>";
            }
            ViewBag.MaLop = new SelectList(db.LopHocs.ToList().OrderBy(x => x.TenLop), "MaLop", "TenLop");
            return View();
        }

        //Xóa giáo viên
        [HttpGet]
        public ActionResult Xoa(long MaGV) //long MmaGV phải trùng với @MaGV bên view
        {
            GiaoVien giaovien = db.GiaoViens.SingleOrDefault(x => x.MaGV == MaGV);

            if (giaovien == null)
            {
                return null;
            }
            return View(giaovien);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(long MaGV)
        {
            GiaoVien giaovien = db.GiaoViens.SingleOrDefault(x => x.MaGV == MaGV);
            if (giaovien == null)
            {
                TempData["err"] =
              "<br/><div class='alert alert-danger' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Xóa học viên thất bại</div>";
            }
            db.GiaoViens.Remove(giaovien);
            db.SaveChanges();
            TempData["err"] =
                               "<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Xóa giáo viên thành công</div>";
            return RedirectToAction("DsGiaoVien");
        }
    }
}