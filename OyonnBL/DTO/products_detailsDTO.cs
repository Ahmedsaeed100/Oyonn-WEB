using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
  public  class products_detailsDTO
    {
        [Key]
        public Nullable<int> product_details_id { get; set; }
        [Required(ErrorMessage = "الاسم المنتج!")]
        public Nullable<short> product_id { get; set; }
        [Required(ErrorMessage = "الاسم العربي فارغ!")]
        public string product_name_ar { get; set; }
        [Required(ErrorMessage = "الاسم الانجليزي فارغ!")]
        public string product_name_en { get; set; }
        public string product_img { get; set; }
        [Required(ErrorMessage = "كمية المنتج فارعه!")]
        public Nullable<int> product_quantity { get; set; }
        [Required(ErrorMessage = "سعر المنتج فارعه!")]
        public Nullable<decimal> product_price { get; set; }
        public virtual productDTO product { get; set; }
    }
}
