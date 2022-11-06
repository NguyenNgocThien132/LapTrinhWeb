using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2001207118_NguyenNgocThien.Models
{
    [Table("ChiTietSanPham")]
    public class ChiTietSanPham
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IDSanPham { get; set; }
        [ForeignKey("IDSanPham")]
        public virtual SanPham SanPham { get; set; }

        public string CPU { get; set; }
        public string ManHinh { get; set; }
        public string RAM { get; set; }
        public string DoHoa { get; set; }
        public string LuuTru { get; set; }
        public string HeDieuHanh { get; set; }
        public string Pin { get; set; }
        public string KhoiLuong { get; set; }




    }
}