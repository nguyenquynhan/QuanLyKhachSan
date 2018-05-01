using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class ThuePhong
    {
        public int MaTP { get; set; }

        public int MaKH { get; set; }

        public int MaPH { get; set; }

        public DateTime? NgayNhanPH { get; set; }

        public DateTime? NgayTraPH { get; set; }

        public int SoLuongNguoi { get; set; }

        public float? TongTien { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }

}
