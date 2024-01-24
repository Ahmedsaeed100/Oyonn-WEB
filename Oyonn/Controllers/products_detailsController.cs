using Newtonsoft.Json;
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
    public class products_detailsController : Controller
    {
        // GET: products_details
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        // GET: News
        [AuthorizeToken]
        public async Task<ActionResult> Index()
        {

            List<products_detailsDTO> com = new List<products_detailsDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/products_detailsAPI/product_detailsDataLoad");
                HttpResponseMessage PRO = await client.GetAsync("api/productsAPI/productDataLoad");
                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;
                    var OROD = PRO.Content.ReadAsStringAsync().Result;
                    com = JsonConvert.DeserializeObject<List<products_detailsDTO>>(Response);
                    ViewBag.product = JsonConvert.DeserializeObject<List<productDTO>>(OROD);

                }

                return View(com);
            }

        }
        public ActionResult Postproducts_details(products_detailsDTO com)
        {
            if (!ModelState.IsValid)
            {
                var msgs = "";

                var errors = ViewData.ModelState.Values;

                foreach (var error in errors)
                {
                    for (int i = 0; i < error.Errors.Count; i++)
                    {
                        msgs += Environment.NewLine + error.Errors[i].ErrorMessage;
                    }
                }

                Response.StatusCode = (int)HttpStatusCode.Conflict;
                return Json(msgs, MediaTypeNames.Text.Plain, JsonRequestBehavior.AllowGet);

            }

            using (var contactus = new HttpClient())
            {
                HttpResponseMessage response;
                contactus.BaseAddress = new Uri(Baseurl);

                contactus.DefaultRequestHeaders.Clear();
                //Define request data format  
                contactus.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                if (com.product_details_id != 0)
                {
                    response = contactus.PostAsJsonAsync("api/products_detailsAPI/products_detailsUpdate", com).Result;
                }
                else
                {
                    response = contactus.PostAsJsonAsync("api/products_detailsAPI/Postproducts_details", com).Result;
                }
                if (response.IsSuccessStatusCode != true)
                {
                    var message = "لم يتم تنفيذ الاجراء";
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(message, MediaTypeNames.Text.Plain);
                }
                return RedirectToAction("Allproducts_details");
            }

        }

        public async Task<PartialViewResult> Allproducts_details()
        {

            List<products_detailsDTO> com = new List<products_detailsDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/products_detailsAPI/product_detailsDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<products_detailsDTO>>(Response);


                }

                return PartialView("Allproducts_details", com);
            }

        }

        [HttpGet]
        [Route("products_details/product_detailsDataLoadByID/{product_details_id}")]
        public string product_detailsDataLoadByID(long? product_details_id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.GetAsync("api/products_detailsAPI/product_detailsDataLoadByID?product_details_id=" + product_details_id).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                return res;
            }
        }




        [HttpPost]
        public ActionResult Deleteproducts_details(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.PostAsJsonAsync("api/products_detailsAPI/products_detailsDelete", id).Result;
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
    }
}