using Newtonsoft.Json;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Oyonn.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        string Baseurl = System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString();
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(AdminDTO user)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response;
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                response = await client.PostAsJsonAsync("api/AdminAPI/AdminLogin", user);

                if (response.IsSuccessStatusCode)
                {
                    DateTime expire = DateTime.Now;
                    if (user.Remember_Me == true)
                    {
                        expire = expire.AddDays(30);
                    }
                    else
                    {
                        expire = expire.AddMinutes(15);
                    }
                    var res = response.Content.ReadAsStringAsync().Result;
                    AdminDTO userdt = JsonConvert.DeserializeObject<AdminDTO>(res);
                    if (userdt != null)
                    {
                        //FormsAuthenticationTicket auth = new FormsAuthenticationTicket(1, userdt.UserName + "|" + userdt.UserID.ToString(), DateTime.Now, expire, user.Remember_Me, JsonConvert.SerializeObject(userdt), "/");
                        //string x= auth.Name;
                        //HttpCookie cooki = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(auth));
                        //cooki.Expires = expire;
                        ////FormsAuthentication.SetAuthCookie(userdt.Email,true);
                        //Response.Cookies.Add(cooki);

                        Session["UserData"] = userdt;
                        return RedirectToAction("Index", "company");
                    }


                }

                else
                {
                    user.UserLoginErrorMassge = "عذرا, يوجد خطاء في اسم المسنخدم او كلمة المرور";

                }
            }

            return View(user);

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "company");
        }
    }
}