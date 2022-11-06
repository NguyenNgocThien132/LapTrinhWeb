using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2001207118_NguyenNgocThien.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham()
        {
            this.ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ThuongHieuID { get; set; }
        //[ForeignKey("ThuongHieuID")]
        public virtual ThuongHieu ThuongHieu { get; set; }

        public string TenSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> GiaTien { get; set; }
        public Nullable<double> GiaGiam { get; set; }
        public string NhaSanXuat { get; set; }
        public string HinhAnh { get; set; }

        
        public int IDTheLoai { get; set; }
        [ForeignKey("IDTheLoai")]
        public virtual TheLoai TheLoai { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

    }
}