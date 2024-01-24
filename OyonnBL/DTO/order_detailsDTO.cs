using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
  public  class order_detailsDTO
    {

        public long order_details_id { get; set; }
        public Nullable<long> order_id { get; set; }
        public Nullable<int> product_details_id { get; set; }
        public Nullable<byte> order_quantity { get; set; }
        public Nullable<decimal> order_price { get; set; }
        public virtual products_detailsDTO products_details { get; set; }
    }
}
