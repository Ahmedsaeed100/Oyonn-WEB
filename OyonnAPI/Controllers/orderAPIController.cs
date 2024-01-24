using OyonnBL;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OyonnAPI.Controllers
{
    [RoutePrefix("api/orderAPI")]
    public class orderAPIController : ApiController
    {
        orderBL BL = new orderBL();
        [HttpPost]
        [Route("UpdateOrders_Status")]
        [ActionName("UpdateOrders_Status")]
        public HttpResponseMessage UpdateOrders_Status(orderDTO CL)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var result = BL.UpdateOrders_Status(CL);
                    if (result != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        [Route("ordersDataLoad")]
        public List<orderDTO> ordersDataLoad()
        {
            return BL.ordersDataLoad();
        }
        [HttpGet]
        [Route("OrderDataLoadbyOrders_StatusID/{Orders_StatusID?}")]
        public List<orderDTO> OrderDataLoadbyOrders_StatusID(int Orders_StatusID)
        {

            return BL.OrderDataLoadbyOrders_StatusID(Orders_StatusID);
        }


        [HttpGet]
        [Route("Orders_StatusDataLoad")]
        public List<Orders_StatusDTO> Orders_StatusDataLoad()
        {
            return BL.Orders_StatusDataLoad();
        }


        [HttpGet]
        [Route("order_detailsbyorder_id/{order_id?}")]
        public List<order_detailsDTO> order_detailsbyorder_id(int order_id)
        {

            return BL.order_detailsbyorder_id(order_id);
        }
    }
}

