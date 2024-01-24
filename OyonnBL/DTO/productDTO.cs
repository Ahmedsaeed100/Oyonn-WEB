using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OyonnBL.DTO
{
 public   class productDTO
    {
        [Key]
        public Nullable<short> product_id { get; set; }
        [Required(ErrorMessage = "الاسم العربي فارغ!")]
        public string product_name_ar { get; set; }
        [Required(ErrorMessage = "الاسم الانجليزي فارغ!")]
        public string product_name_en { get; set; }
         [Required(ErrorMessage = "الاسم الانجليزي فارغ!")]
        public short company_id { get; set; }
        public virtual companyDTO company { get; set; }
    }
}
