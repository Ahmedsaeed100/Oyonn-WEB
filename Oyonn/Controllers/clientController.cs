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
    public class clientController : Controller
    {
        // GET: client
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        [AuthorizeToken]
        public async Task<ActionResult> Index()
        {

            List<clientDTO> com = new List<clientDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/clientAPI/clientDataLoad");
                HttpResponseMessage clinstu = await client.GetAsync("api/clientAPI/client_statusDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;
                    var clins = clinstu.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<clientDTO>>(Response);
                    ViewBag.client_status = JsonConvert.DeserializeObject<List<client_statusDTO>>(clins);

                }

                return View(com);
            }

        }

        public async Task<PartialViewResult> Search(int client_status_id)
        {
            using (var MrQueries = new HttpClient())
            {

                List<clientDTO> ErrorLogLIST = new List<clientDTO>();
                MrQueries.BaseAddress = new Uri(Baseurl);

                MrQueries.DefaultRequestHeaders.Clear();
                //Define request data format  
                MrQueries.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await MrQueries.GetAsync("api/clientAPI/clientDataLoadbyclient_status_id?client_status_id=" + client_status_id + "");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved ORDERSTATUSIDfrom web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  

                    ErrorLogLIST = JsonConvert.DeserializeObject<List<clientDTO>>(Response);

                }
                //returning the employee list to view  
                return PartialView("Search", ErrorLogLIST);
            }
        }

        [HttpPost]

        public ActionResult Postupdateclient_status(clientDTO gov)
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


                response = client.PostAsJsonAsync("api/clientAPI/updateclient_status", gov).Result;


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

        [Route("client/client_shopDataLoad/{client_id?}")]
        public string client_shopDataLoad(long? client_id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                response = client.GetAsync("api/clientAPI/client_shopDataLoad?client_id=" + client_id + "").Result;

                var res = response.Content.ReadAsStringAsync().Result;

                return res;
            }
        }
    }
}