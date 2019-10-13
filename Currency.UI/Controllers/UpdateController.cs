using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using Currency.Data;


namespace Currency.UI.Controllers
{
    public class UpdateController : Controller
    {
        GenericRepository<Tbl_exchange_rates> _repoExchangeRate;

        public UpdateController()
        {
            this._repoExchangeRate = new GenericRepository<Tbl_exchange_rates>();
        }

        // GET: Update
        public ActionResult Index()
        {
            List<Tbl_exchange_rates> ExchangeRates = _repoExchangeRate.GetAll();
            return View(ExchangeRates);
        }

        // GET: Update/Edit/5
        public ActionResult Edit(int? id)
        {
            //Error occurs if no id is get
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_exchange_rates ExchangeRates = _repoExchangeRate.GetById(id.Value);
            //If the record is not found ;
            if (ExchangeRates == null) 
            {
                return HttpNotFound();
            }
            return View(ExchangeRates);
        }

        // POST: Update/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Unit,CurrencyCode,Unit,CurrencyName,ForexBuying,ForexSelling,BanknoteBuying,BanknoteSelling,LastUpdate")] Tbl_exchange_rates ExchangeRates)
        {
            //Modelstate is checked when information is filled
            //Records are updated if specified rules are met
            try
            {
                if (ModelState.IsValid)
                {
                    _repoExchangeRate.Update(ExchangeRates);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            //If the rules are not followed, the information entered by the user is shown again
            return View(ExchangeRates);
        }
    }
}      
    
