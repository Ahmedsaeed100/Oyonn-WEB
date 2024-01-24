using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{
   public class orderBL
    {
        oyonnEntities DB = new oyonnEntities();

        //orders data loade
        public List<orderDTO> ordersDataLoad()
        {
            var result = DB.orders.OrderByDescending(u => u.order_id).Select(cl => new orderDTO()
            {
                order_id = cl.order_id,
                shop_id = cl.shop_id,
                total_orders_price = cl.total_orders_price,
                order_date = cl.order_date,
                order_time = cl.order_time,
                order_delivery_date = cl.order_delivery_date,
                order_delivery_time = cl.order_delivery_time,
                Orders_StatusID = cl.Orders_StatusID,
                Orders_Status = new Orders_StatusDTO { Status = (cl.Orders_Status != null ? cl.Orders_Status.Status : "") },
                client_shop = new client_shopDTO { shop_Name = (cl.client_shop != null ? cl.client_shop.shop_Name : ""), client_name = (cl.client_shop != null ? cl.client_shop.client.client_name : "") },
                order_details = cl.order_details.Select(ch => new order_detailsDTO()
                {
                    order_details_id = ch.order_details_id,
                    product_details_id = ch.product_details_id,

                    order_quantity = ch.order_quantity,
                    order_price = ch.order_price,

                    products_details = new products_detailsDTO { product_name_ar = (ch.products_details != null ? ch.products_details.product_name_ar : "") },
                    
                }).ToList(),


            }).ToList();

            return result;
        }

        public List<orderDTO> OrderDataLoadbyOrders_StatusID(int Orders_StatusID)
        {
            var result = DB.orders.Where(x=>x.Orders_StatusID== Orders_StatusID).Select(cl => new orderDTO()
            {
                order_id = cl.order_id,
                shop_id = cl.shop_id,
                total_orders_price = cl.total_orders_price,
                order_date = cl.order_date,
                order_time = cl.order_time,
                order_delivery_date = cl.order_delivery_date,
                order_delivery_time = cl.order_delivery_time,
                Orders_StatusID = cl.Orders_StatusID,
                Orders_Status = new Orders_StatusDTO { Status = (cl.Orders_Status != null ? cl.Orders_Status.Status : "") },
                client_shop = new client_shopDTO { shop_Name = (cl.client_shop != null ? cl.client_shop.shop_Name : ""),client_name= (cl.client_shop != null ? cl.client_shop.client.client_name : "") },
                order_details = cl.order_details.Select(ch => new order_detailsDTO()
                {
                    order_details_id = ch.order_details_id,
                    product_details_id = ch.product_details_id,

                    order_quantity = ch.order_quantity,
                    order_price = ch.order_price,

                    products_details = new products_detailsDTO { product_name_ar = (ch.products_details != null ? ch.products_details.product_name_ar : "") },

                }).ToList(),


            }).ToList();

            return result;
        }

        public int UpdateOrders_Status(orderDTO result)
        {
            order CO = AutoMapper.Mapper.Map<orderDTO, order>(result);
            try
            {
                order c = DB.orders.Find(CO.order_id);
                c.Orders_StatusID = CO.Orders_StatusID;
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }


        public List<Orders_StatusDTO> Orders_StatusDataLoad()
        {
            var result = DB.Orders_Status.Select(ev => new Orders_StatusDTO()
            {
                Orders_StatusID = ev.Orders_StatusID,
                Status = ev.Status,

            }).ToList();
            return result;
        }

        public List<order_detailsDTO> order_detailsbyorder_id(int order_id)
        {
            var result = DB.order_details.Where(x => x.order_id == order_id).Select(ch => new order_detailsDTO()
            {
               
               
                    order_details_id = ch.order_details_id,
                    product_details_id = ch.product_details_id,

                    order_quantity = ch.order_quantity,
                    order_price = ch.order_price,

                    products_details = new products_detailsDTO { product_name_ar = (ch.products_details != null ? ch.products_details.product_name_ar : ""), product_img = (ch.products_details != null ? Generic.product_imgPathRelative + ch.products_details.product_img : "") },

                


            }).ToList();

            return result;
        }


    }
}
