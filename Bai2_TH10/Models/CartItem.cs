using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2_TH10.Models
{
    public class CartItem
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien
        {
            get { return DonGia * SoLuong; }
        }
        public CartItem(tbl_SanPham sp)
        {
            MaSP = sp.MaSP;
            TenSP = sp.TenSP;
            HinhAnh = sp.HinhAnh;
            DonGia = sp.DonGia ?? 0;  
            SoLuong = 1;
        }

        public CartItem() { }
    }
}