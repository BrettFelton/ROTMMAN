using ROTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ROTM.Controllers
{

    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "If you have any problems with the managment system please feel free to get into contact with us via this contact page.";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(ContactViewModels contactViewModel)
        {
            ViewBag.Message = "If you have any problems with the managment system please feel free to get into contact with us via this contact page.";

            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(contactViewModel.From);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("info@repsonthemove.com");//Where mail will be sent 
                    msz.Subject = contactViewModel.Subject;
                    msz.Body = contactViewModel.Body;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "nl1-wss2.a2hosting.com";

                    smtp.Port = 25;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("info@repsonthemove.com", "3o3fE@k4");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                   // ModelState.Clear();
                    //info@repsonthemove.com upg$H101
                    //This is for an emal service Remeber this !
                    ViewBag.StatusMessage = $"Your Message has been sent successfully ";
                    return View(contactViewModel);
                }
                catch (Exception ex)
                {

                   // ModelState.Clear();
                    ViewBag.StatusMessage = $"Sorry we are facing a problem here" + ex;
                }
            }
            return View(contactViewModel);
        }
    }
}