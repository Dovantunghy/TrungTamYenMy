using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamYenMy.Models.BusinessModel
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string MaNhomNguoiDung { set; get; }
    }
}