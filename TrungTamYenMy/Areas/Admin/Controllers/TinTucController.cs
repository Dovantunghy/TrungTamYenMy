using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamYenMy.Models;

namespace TrungTamYenMy.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        TrungTamYenMyEntities db=new TrungTamYenMyEntities();
        // GET: Admin/TinTuc

            //Load tin tức
        public ActionResult DsTinTuc()
        {
            var listTinTuc = db.TinTucs.ToList();
            return View(listTinTuc);
        }

        //Thêm mới tin tức
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //đưa dl vào dropdownlist
            ViewBag.MaLoaiTin =new SelectList(db.LoaiTinTucs.ToList().OrderBy(x => x.TenLoaiTin), "MaLoaiTin","TenLoaiTin");
            ViewBag.MaNV = new SelectList(db.NhanViens.ToList().OrderBy(x => x.TenNV), "MaNV", "TenNV");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(TinTuc tintuc,HttpPostedFileBase fileUpload)
        {
           
            //đưa dl vào dropdownlist
            ViewBag.MaLoaiTin = new SelectList(db.LoaiTinTucs.ToList().OrderBy(x => x.TenLoaiTin), "MaLoaiTin", "TenLoaiTin");
            ViewBag.MaNV = new SelectList(db.NhanViens.ToList().OrderBy(x => x.TenNV), "MaNV", "TenNV");

            //kiểm tra đường dẫn
            if (fileUpload==null)
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

                tintuc.HinhAnh = fileUpload.FileName;
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Thêm tin tức thành công</div>";
                return RedirectToAction("DsTinTuc", "TinTuc");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(long MaTinTuc)
        {
            //lấy ra tin tức theo mã
            TinTuc tintuc = db.TinTucs.SingleOrDefault(x => x.MaTinTuc==MaTinTuc);
            if (tintuc==null)
            {
                return null;
            }
            ViewBag.MaLoaiTin = new SelectList(db.LoaiTinTucs.ToList().OrderBy(x => x.TenLoaiTin), "MaLoaiTin", "TenLoaiTin",tintuc.MaLoaiTin);
           return View(tintuc);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TinTuc tintuc)
        {
            //đưa dl vào dropdownlist
           
            if (ModelState.IsValid)
            {
                //cách 1:lấy biến tin tức--thực hiện những cập nhật trong model--khi savechange thì nó cập nhật lại db
                db.Entry(tintuc).State = System.Data.Entity.EntityState.Modified;

                //Cách 2:Dùng truy vấn

                //TinTuc tintucc2 = db.TinTucs.SingleOrDefault(x => x.MaTinTuc == tintuc.MaTinTuc);
                //tintucc2.MaTinTuc = tintuc.MaTinTuc;

                db.SaveChanges();
            }
            ViewBag.MaLoaiTin = new SelectList(db.LoaiTinTucs.ToList().OrderBy(x => x.TenLoaiTin), "MaLoaiTin", "TenLoaiTin");
            ViewBag.MaNV = new SelectList(db.NhanViens.ToList().OrderBy(x => x.TenNV), "MaNV", "TenNV");
            TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Sửa tin tức thành công</div>";
            return RedirectToAction("DsTinTuc", "TinTuc");
        }


        public ActionResult Xoa(long maTinTuc)
        {
            TinTuc tintuc = db.TinTucs.SingleOrDefault(x => x.MaTinTuc == maTinTuc);
            if (tintuc==null)
            {
                return null;
            }
            return View(tintuc);
        }

        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(long maTinTuc)
        {
            TinTuc tinTuc = db.TinTucs.SingleOrDefault(x => x.MaTinTuc == maTinTuc);

            if (tinTuc==null)
            {
                return null;
            }
            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();
            TempData["err"] =
"<br/><div class='alert alert-success' role=alert><span class='glyphicon glyphicon-exclamation-sign hide'></span><span class'sr-only'></span>Xóa tin tức thành công</div>";
            return RedirectToAction("DsTinTuc");
        }
        
    }
}