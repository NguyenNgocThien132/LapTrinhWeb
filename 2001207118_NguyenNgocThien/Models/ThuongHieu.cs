using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2001207118_NguyenNgocThien.Models
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        public ThuongHieu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NSX { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}