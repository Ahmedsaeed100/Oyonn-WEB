using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
  public  class orderDTO
    {
        public long order_id { get; set; }
        public Nullable<int> shop_id { get; set; }
        public Nullable<decimal> total_orders_price { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<System.TimeSpan> order_time { get; set; }
        public Nullable<System.DateTime> order_delivery_date { get; set; }
        public Nullable<System.TimeSpan> order_delivery_time { get; set; }
        public int Orders_StatusID { get; set; }
        public virtual client_shopDTO client_shop { get; set; }
        public virtual ICollection<order_detailsDTO> order_details { get; set; }
        public virtual Orders_StatusDTO Orders_Status { get; set; }
    }
}
