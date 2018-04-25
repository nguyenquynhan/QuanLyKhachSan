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

        public float? Gia { get; set; }

        public int SoLuong { get; set; }

        public float? ThanhTien { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }
}
