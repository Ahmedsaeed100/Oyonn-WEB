using Newtonsoft.Json;
using Oyonn;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Oyonn.Controllers
{
    public class orderController : Controller
    {
        // GET: order
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        [AuthorizeToken]
        public async Task<ActionResult> Index()
        {

            List<orderDTO> com = new List<orderDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/orderAPI/ordersDataLoad");
                HttpResponseMessage clinstu = await client.GetAsync("api/orderAPI/Orders_StatusDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;
                    var clins = clinstu.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<orderDTO>>(Response);
                    ViewBag.Orders_Status = JsonConvert.DeserializeObject<List<Orders_StatusDTO>>(clins);

                }

                return View(com);
            }

        }

        public async Task<PartialViewResult> Search(int Orders_StatusID)
        {
            using (var MrQueries = new HttpClient())
            {

                List<orderDTO> ErrorLogLIST = new List<orderDTO>();
                MrQueries.BaseAddress = new Uri(Baseurl);

                MrQueries.DefaultRequestHeaders.Clear();
                //Define request data format  
                MrQueries.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await MrQueries.GetAsync("api/orderAPI/OrderDataLoadbyOrders_StatusID?Orders_StatusID=" + Orders_StatusID + "");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved ORDERSTATUSIDfrom web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  

                    ErrorLogLIST = JsonConvert.DeserializeObject<List<orderDTO>>(Response);

                }
                //returning the employee list to view  
                return PartialView("Search", ErrorLogLIST);
            }
        }

        [HttpPost]

        public ActionResult PostUpdateOrders_Status(orderDTO gov)
        {



            using (var client = new HttpClient())
            {
                //gov.InvoiceDetails = gov.InvoiceDetails.Where(g => g.ItemID != 0).ToList();

                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  


                response = client.PostAsJsonAsync("api/orderAPI/UpdateOrders_Status", gov).Result;


                if (response.IsSuccessStatusCode == true)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json('0', JsonRequestBehavior.AllowGet);
                }

            }

        }



        [HttpGet]

        [Route("order/order_detailsbyorder_id/{order_id?}")]
        public string order_detailsbyorder_id(long? order_id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                response = client.GetAsync("api/orderAPI/order_detailsbyorder_id?order_id=" + order_id + "").Result;

                var res = response.Content.ReadAsStringAsync().Result;

                return res;
            }
        }

    }
}