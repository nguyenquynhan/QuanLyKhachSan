using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class ChiTietTienThuePhong
    {
        public int MaCTTTP { get; set; }

        public int MaTP { get; set; }

        public string LoaiTienPhong { get; set; }

        public double? Gia { get; set; }

        public double SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }

}
