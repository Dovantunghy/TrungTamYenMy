using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models.BusinessModel
{
    public class LopHocDao
    {
        TrungTamYenMyEntities db = null;
        public LopHocDao()
        {
            db = new TrungTamYenMyEntities();
        }
        public LopHoc ViewDetail(long id)
        {
            return db.LopHocs.Find(id);
        }

        public LoaiLopHoc ViewDetail2(long id)
        {
            return db.LoaiLopHocs.Find(id);
        }

        public List<string> ListName(string keyword)
        {
            return db.LopHocs.Where(x => x.TenLop.Contains(keyword)).Select(x => x.TenLop).ToList();
        }

        public List<LopHoc> TimKiem(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 9)
        {
            totalRecord = db.LopHocs.Where(x => x.TenLop == keyword).Count();
            var model = (from a in db.LopHocs
                         join b in db.LoaiLopHocs
                         on a.MaLoaiLop equals b.MaLoaiLop
                         where a.TenLop.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.TenLoaiLop,
                             CreatedDate = a.NgayTao,
                             ID = a.MaLop,
                             Images = a.HinhAnh,
                             Name = a.TenLop,
                             NameTeacher = a.TenGiaoVienDay,
                             MetaTitle = a.MetatTitle,
                             MoTa = a.MoTa
                         }).AsEnumerable().Select(x => new LopHoc()
                         {
                             TenLop = x.Name,
                             NgayTao = x.CreatedDate,
                             MaLop = x.ID,
                             HinhAnh = x.Images,
                             TenGiaoVienDay = x.Name,
                             MetatTitle = x.MetaTitle,
                             MoTa = x.MoTa
                         });
            model.OrderByDescending(x => x.NgayTao).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}