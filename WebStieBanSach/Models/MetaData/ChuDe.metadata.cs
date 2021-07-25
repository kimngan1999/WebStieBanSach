using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebStieBanSach.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            [Key]
            public int MaChuDe { get; set; }

            [Display(Name = "Tên Chủ đề")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(50, ErrorMessage = "{0} không quá 50 kí tự")]
            public string TenChuDe { get; set; }
        }
    }
}