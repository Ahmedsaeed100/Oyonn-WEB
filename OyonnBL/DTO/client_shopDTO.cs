using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
  public  class client_shopDTO
    {
        public int shop_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public string shop_img { get; set; }
       
        public Nullable<short> area_id { get; set; }
        public Nullable<short> city_id { get; set; }
        public string shop_phone { get; set; }
        public string shop_address { get; set; }
        public string Shop_mobile { get; set; }
        public string shop_Name { get; set; }
        public virtual areaDTO area { get; set; }
        public virtual cityDTO city { get; set; }
        public virtual clientDTO client { get; set; }
        //mostafa
        public string client_name { get; set; }


    }
}
