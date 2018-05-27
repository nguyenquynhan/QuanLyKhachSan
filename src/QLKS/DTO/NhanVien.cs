﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }

        public string HoTen { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string SDT { get; set; }

        public string CMND { get; set; }

        public string DiaChi { get; set; }

        public string GioiTinh { get; set; }

        public string Email { get; set; }

        public string GhiChu { get; set; }

        public DateTime NgayLamViec { get; set; }

        public DateTime? NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int NguoiSua { get; set; }

        public bool DaXoa { get; set; }

    }

}
