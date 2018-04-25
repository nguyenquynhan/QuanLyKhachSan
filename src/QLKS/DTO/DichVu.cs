using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class DichVu
    {
        public int MaDV { get; set; }

        public string TenDV { get; set; }

        public decimal? Gia { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

    }

}
