namespace Bai01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MADONHANG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MASACH { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
