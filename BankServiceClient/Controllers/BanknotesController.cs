using BankServiceClient.ServiceReference;
using System.Web.Mvc;

namespace BankServiceClient.Controllers
{
    public class BanknotesController : Controller
    {
        public ActionResult GetAllBanknotes()
        {
            BanknotesServiceClient banknotesServiceClient = new BanknotesServiceClient();

            BanknoteModel[] banknotes = banknotesServiceClient.GetAllBanknotes();

            return View(banknotes);
        }

        public ActionResult GetBanknote(int denomination)
        {
            BanknotesServiceClient banknotesServiceClient = new BanknotesServiceClient();

            BanknoteModel banknote = banknotesServiceClient.GetBanknote(denomination);

            return View(banknote);
        }
    }
}