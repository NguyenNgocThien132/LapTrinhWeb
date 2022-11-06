using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2001207118_NguyenNgocThien.Models
{
    [Table("TheLoai")]
    public class TheLoai
    {
        public TheLoai()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        public int ID { get; set; }
        
        public string LoaiSP { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}