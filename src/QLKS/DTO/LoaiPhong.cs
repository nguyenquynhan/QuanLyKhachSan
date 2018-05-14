using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class LoaiPhong
    {
        public int MaLoaiPH { get; set; }

        public string TenLoaiPH { get; set; }

        public double? GiaGioDau { get; set; }

        public double? GiaGioHai { get; set; }

        public double? GiaGioTiepTheo { get; set; }

        public double? GiaTheoNgay { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }

}
