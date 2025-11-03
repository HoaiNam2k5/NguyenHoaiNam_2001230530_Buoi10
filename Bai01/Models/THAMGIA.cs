namespace Bai01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMGIA")]
    public partial class THAMGIA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MASACH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MATACGIA { get; set; }

        [StringLength(50)]
        public string VAITRO { get; set; }

        [StringLength(50)]
        public string VITRI { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
