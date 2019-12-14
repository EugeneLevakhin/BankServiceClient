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

        public ActionResult AddBanknote()
        {
            BanknoteModel model = new BanknoteModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddBanknote(BanknoteModel banknote)
        {
            if (banknote.Denomination < 1 || banknote.Quantity < 0)
            {
                return View("AddBanknoteError");
            }

            BanknotesServiceClient banknotesServiceClient = new BanknotesServiceClient();
            bool success = banknotesServiceClient.AddBanknote(banknote.Denomination, banknote.Quantity);

            if (!success)
            {
                return View("AddBanknoteError");
            }

            return Redirect("/Banknotes/GetAllBanknotes");
        }

        public ActionResult AddBanknoteError()
        {
            return View();
        }

        public ActionResult GetBanknoteInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBanknoteInfo(string denomination)
        {
            if (int.TryParse(denomination.ToString(), out int value))
            {
                BanknotesServiceClient banknotesServiceClient = new BanknotesServiceClient();

                BanknoteModel banknote = banknotesServiceClient.GetBanknote(value);

                if (banknote != null)
                {
                    return RedirectToAction("GetBanknote", new { denomination = value });
                }
            }

            return View("GetBanknoteError");
        }

        public ActionResult GetBanknoteError()
        {
            return View();
        }
    }
}