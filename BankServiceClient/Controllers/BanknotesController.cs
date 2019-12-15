using BankServiceClient.ServiceReference;
using System.Web.Mvc;

namespace BankServiceClient.Controllers
{
    public sealed class BanknotesController : Controller
    {
        private readonly BanknotesServiceClient _banknotesServiceClient;

        public BanknotesController()
        {
            _banknotesServiceClient = new BanknotesServiceClient();
        }

        public ActionResult GetAllBanknotes()
        {
            BanknoteModel[] banknotes = _banknotesServiceClient.GetAllBanknotes();

            return View(banknotes);
        }

        public ActionResult BanknoteDetail(int denomination)
        {
            BanknoteModel banknote = _banknotesServiceClient.GetBanknote(denomination);

            return View(banknote);
        }

        public ActionResult AddOrChangeBanknote()
        {
            BanknoteModel model = new BanknoteModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrChangeBanknote(BanknoteModel banknote)
        {
            if (banknote.Denomination < 1 || banknote.Quantity < 0)
            {
                return View("AddOrChangeBanknoteError");
            }

            bool success = _banknotesServiceClient.AddOrChangeBanknote(banknote.Denomination, banknote.Quantity);

            if (!success)
            {
                return View("AddOrChangeBanknoteError");
            }

            return Redirect("/Banknotes/GetAllBanknotes");
        }

        public ActionResult AddOrChangeBanknoteError()
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
                BanknoteModel banknote = _banknotesServiceClient.GetBanknote(value);

                if (banknote != null)
                {
                    return RedirectToAction("BanknoteDetail", new { denomination = value });
                }
            }

            return View("BanknoteDetailError");
        }

        public ActionResult BanknoteDetailError()
        {
            return View();
        }
    }
}