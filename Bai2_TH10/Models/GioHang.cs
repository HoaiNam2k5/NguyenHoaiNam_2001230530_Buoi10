using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2_TH10.Models
{
    [Serializable]
    public class GioHang
    {
        public List<CartItem> Items { get; set; }

        public GioHang()
        {
            Items = new List<CartItem>();
        }

        // Thêm sản phẩm vào giỏ
        public void ThemVaoGio(tbl_SanPham sp)
        {
            var item = Items.FirstOrDefault(i => i.MaSP == sp.MaSP);
            if (item != null)
            {
                item.SoLuong++; // đã có thì tăng số lượng
            }
            else
            {
                Items.Add(new CartItem(sp));
            }
        }

        // Xóa sản phẩm
        public void XoaKhoiGio(string maSP)
        {
            var item = Items.FirstOrDefault(i => i.MaSP == maSP);
            if (item != null)
                Items.Remove(item);
        }

        // Cập nhật số lượng
        public void CapNhat(string maSP, int soLuong)
        {
            var item = Items.FirstOrDefault(i => i.MaSP == maSP);
            if (item != null)
                item.SoLuong = soLuong;
        }

        // Tổng số lượng
        public int TongSoLuong()
        {
            return Items.Sum(i => i.SoLuong);
        }

        // Tổng tiền
        public decimal TongTien()
        {
            return Items.Sum(i => i.ThanhTien);
        }

        // Xóa toàn bộ
        public void XoaGio()
        {
            Items.Clear();
        }
    }
}