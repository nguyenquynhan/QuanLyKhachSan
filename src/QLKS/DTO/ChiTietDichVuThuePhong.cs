using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class ChiTietDichVuThuePhong
    {
        public int MaCTDVTP { get; set; }

        public int MaTP { get; set; }

        public int MaDV { get; set; }

        public string TenDV { get; set; }

        public double? Gia { get; set; }

        public int SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }
}
