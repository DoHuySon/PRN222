using Assigment_PRN222_01.Models;
using Assigment_PRN222_01.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_PRN222_01.Controllers
{
    public class AccountController : Controller
    {
        private readonly FunewsManagementContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountservice;
        public AccountController(ILogger<AccountController> logger, FunewsManagementContext context, AccountService account)
        {
            _logger = logger;
            _context = context;
            _accountservice = account;
        }
        // GET: AccountController
        public ActionResult View()
        {
            var account = _context.SystemAccounts.ToList();
            return View(account);
        }
        public ActionResult Search(string keyword)
        {
            var account = _accountservice.searchAccount(keyword);
            return View(account);
        }
        public ActionResult Profile()
        {
            string email = HttpContext.Session.GetString("email");
            var account = _context.SystemAccounts.FirstOrDefault(m => m.AccountEmail.Contains(email));
            int id = account.AccountId;
            return Details(id);
        }
        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = _context.SystemAccounts.FirstOrDefault(m => m.AccountId == id);
            return View(account);
        }

        // GET: AccountController/Create
        public ActionResult CreateAccount()
        {
            return View("~/Views/Account/CreateAccount.cshtml");
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(string AccountName, string AccountEmail, int AccountRole, string AccountPassword)
        {
            if (ModelState.IsValid)
            {
                int count = _context.SystemAccounts.Count() + 1;
                var account = new SystemAccount
                {
                    AccountId = (short)count,
                    AccountEmail = AccountEmail,
                    AccountName = AccountName,
                    AccountRole = AccountRole,
                    AccountPassword = AccountPassword
                };
                _context.SystemAccounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(View));
            }
            return View();
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var account = _context.SystemAccounts.FirstOrDefault(m => m.AccountId == id);
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemAccount account)
        {
            if(id == account.AccountId)
            {
                _context.SystemAccounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(View));
            }
            return View();
        }
        [HttpGet]
        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var account = _context.SystemAccounts.FirstOrDefault(m => m.AccountId == id);
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletee(int AccountId)
        {
            var account = _context.SystemAccounts.FirstOrDefault(m => m.AccountId == AccountId);
            _context.SystemAccounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction(nameof(View));
        }
    }
}
