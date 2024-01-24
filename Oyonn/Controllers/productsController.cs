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
    public class productsController : Controller
    {
        // GET: products
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        // GET: News
        [AuthorizeToken]
        public async Task<ActionResult> Index()
        {

            List<productDTO> com = new List<productDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/productsAPI/productDataLoad");
                HttpResponseMessage CON = await client.GetAsync("api/CompanyAPI/CompanyDataLoad");
                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;
                    var CONU = CON.Content.ReadAsStringAsync().Result;
                    com = JsonConvert.DeserializeObject<List<productDTO>>(Response);
                    ViewBag.company = JsonConvert.DeserializeObject<List<companyDTO>>(CONU);

                }

                return View(com);
            }

        }
        public ActionResult Postproduct(productDTO com)
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

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(msgs, MediaTypeNames.Text.Plain);

            }

            using (var contactus = new HttpClient())
            {
                HttpResponseMessage response;
                contactus.BaseAddress = new Uri(Baseurl);

                contactus.DefaultRequestHeaders.Clear();
                //Define request data format  
                contactus.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                if (com.product_id != 0)
                {
                    response = contactus.PostAsJsonAsync("api/productsAPI/productsUpdate", com).Result;
                }
                else
                {
                    response = contactus.PostAsJsonAsync("api/productsAPI/PostproductDataSave", com).Result;
                }
                if (response.IsSuccessStatusCode != true)
                {
                    var message = "لم يتم تنفيذ الاجراء";
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(message, MediaTypeNames.Text.Plain);
                }
                return RedirectToAction("Allproduct");
            }

        }

        public async Task<PartialViewResult> Allproduct()
        {

            List<productDTO> com = new List<productDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/productsAPI/productDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<productDTO>>(Response);


                }

                return PartialView("Allproduct", com);
            }

        }

        [HttpGet]
        [Route("products/productDataLoadByID/{product_id}")]
        public string productDataLoadByID(long? product_id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.GetAsync("api/productsAPI/productDataLoadByID?product_id=" + product_id).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                return res;
            }
        }




        [HttpPost]
        public ActionResult Deleteproducts(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.PostAsJsonAsync("api/productsAPI/productsDelete", id).Result;
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