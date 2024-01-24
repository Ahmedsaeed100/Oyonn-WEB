

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

namespace OyonnViews.Controllers
{
    public class companyController : Controller
    {
        // GET: company
       
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        // GET: News
        [AuthorizeToken]
        public async Task<ActionResult> Index()
        {

            List<companyDTO> com = new List<companyDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/CompanyAPI/CompanyDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<companyDTO>>(Response);


                }

                return View(com);
            }

        }
        public ActionResult Postcompany(companyDTO com)
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
                if (com.company_id != 0)
                {
                    response = contactus.PostAsJsonAsync("api/CompanyAPI/companyUpdate", com).Result;
                }
                else
                {
                    response = contactus.PostAsJsonAsync("api/CompanyAPI/Postcompany", com).Result;
                }
                if (response.IsSuccessStatusCode != true)
                {
                    var message = "لم يتم تنفيذ الاجراء";
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(message, MediaTypeNames.Text.Plain);
                }
                return RedirectToAction("Allcompanyies");
            }

        }

        public async Task<PartialViewResult> Allcompanyies()
        {

            List<companyDTO> com = new List<companyDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient 

                HttpResponseMessage NewsList = await client.GetAsync("api/CompanyAPI/CompanyDataLoad");

                //Checking the response is successful or not which is sent using HttpClient  
                if (NewsList.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                    

                    var Response = NewsList.Content.ReadAsStringAsync().Result;

                    com = JsonConvert.DeserializeObject<List<companyDTO>>(Response);


                }

                return PartialView("Allcompanyies", com);
            }

        }

        [HttpGet]
        [Route("company/CompanyDataLoadByID/{company_id}")]
        public string CompanyDataLoadByID(long? company_id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.GetAsync("api/CompanyAPI/CompanyDataLoadByID?company_id=" + company_id).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                return res;
            }
        }




        [HttpPost]
        public ActionResult DeleteCurrency(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = client.PostAsJsonAsync("api/CompanyAPI/companyDelete", id).Result;
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