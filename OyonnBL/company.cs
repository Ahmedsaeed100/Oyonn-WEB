//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OyonnBL
{
    using System;
    using System.Collections.Generic;
    
    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            this.products = new HashSet<product>();
        }
    
        public short company_id { get; set; }
        public string company_name_ar { get; set; }
        public string company_name_en { get; set; }
        public string company_img { get; set; }
        public string company_phone { get; set; }
        public string company_mobile { get; set; }
        public string company_address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
