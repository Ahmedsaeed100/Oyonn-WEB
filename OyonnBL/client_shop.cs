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
    
    public partial class client_shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client_shop()
        {
            this.orders = new HashSet<order>();
        }
    
        public int shop_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public string shop_Name { get; set; }
        public string shop_img { get; set; }
        public Nullable<short> area_id { get; set; }
        public Nullable<short> city_id { get; set; }
        public string Shop_mobile { get; set; }
        public string shop_phone { get; set; }
        public string shop_address { get; set; }
    
        public virtual area area { get; set; }
        public virtual city city { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}