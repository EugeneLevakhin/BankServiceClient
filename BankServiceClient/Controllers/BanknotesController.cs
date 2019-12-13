using BankServiceClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankServiceClient.Controllers
{
    public class BanknotesController : Controller
    {
        // GET: Banknotes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllBanknotes()
        {
            BanknotesServiceClient banknotesServiceClient = new BanknotesServiceClient();

            BanknoteModel[] banknotes = banknotesServiceClient.GetAllBanknotes();

            return View(banknotes);
        }
    }
}