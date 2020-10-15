using ContactForm.DAL;
using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {
        private IContact contactRepo;
        public HomeController()
        {
            contactRepo = new ContactRepository(new ContactEntities());
        }
        public ActionResult Index()
        {
            TempData["Success"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email,LastName,FirstName,PhoneNo,ContactPurpose,ContactPurposeText,Message")] ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int save = contactRepo.Insert(model);
                    if (save != 0)
                    {
                        ModelState.Clear();
                        TempData["Success"] = true;
                        return View(new ContactUsViewModel());
                    }
                }
                catch(Exception ex)
                {
                    // handle this appropriately
                    Console.WriteLine(ex);
                    return View(model);
                }


            }

            
            return View(model);
        }
    }
}