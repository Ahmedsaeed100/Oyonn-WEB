using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
 public   class companyDTO
    {
        [Key]
        public Nullable<short> company_id { get; set; }
        [Required(ErrorMessage = "الاسم العربي فارغ!")]
        public string company_name_ar { get; set; }
        [Required(ErrorMessage = "الاسم الانجليزي فارغ!")]
        public string company_name_en { get; set; }
        public string company_img { get; set; }
        public string company_phone { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "من فضلك رقم الموبيل يجب ان يتكون من 11رقم")]
        [Required(ErrorMessage = "رقم الموبيل  فارغ!")]
        public string company_mobile { get; set; }
        public string company_address { get; set; }


    }
}
