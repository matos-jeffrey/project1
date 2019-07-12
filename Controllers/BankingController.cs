using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetBankDB.Models;

namespace NetBankDB.Controllers
{
    public class BankingController : Controller
    {
        private readonly NetBankContext _context;

        public BankingController(NetBankContext context)
        {
            _context = context;
        }

        // GET: Banking
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: Banking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _context.Accounts
                .FirstOrDefaultAsync(m => m.accountID == id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // GET: Banking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userID,accountID,dateCreated,accountType,balance,interest,dateInterest,imf")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accounts);
        }

        // GET: Banking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }
            return View(accounts);
        }

        // POST: Banking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userID,accountID,dateCreated,accountType,balance,interest,dateInterest,imf")] Accounts accounts)
        {
            if (id != accounts.accountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(accounts.accountID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accounts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountChoice(int userID, string accountChoice)
        {
            if (accountChoice == "Checking") { return RedirectToAction("CheckingAccount", "Banking", new { userId = userID }); }
            if (accountChoice == "Business") { return RedirectToAction("BusinessAccount", "Banking", new { userId = userID }); }
            if (accountChoice == "Loan") { return RedirectToAction("LoanAccount", "Banking", new { userId = userID }); }
            if (accountChoice == "Term") { return RedirectToAction("TermAccount", "Banking", new { userId = userID }); }
            return RedirectToAction("ErrorPage", "MainMenu");
        }

        public IActionResult CheckingAccount(int userID)
        {
            var account = new Accounts();
            account.userID = userID;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckingAccount(int userID, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountType = "Checking";
            account.dateCreated = DateTime.Today;
            account.interest = 1.0005;
            account.imf = 3;
            account.dateInterest = DateTime.Today.AddMonths(Convert.ToInt32(account.imf));
            account.balance = balance;

            var transaction = new Transaction();
            transaction.userID = account.userID;
            transaction.accountID = account.accountID;
            transaction.transactionDate = DateTime.Now;
            transaction.transactionProcessed = "Opened Account and Deposited $" + balance;


            _context.Add(account);
            await _context.SaveChangesAsync();
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts", new { userId = account.userID });
        }

        public IActionResult BusinessAccount(int userID)
        {
            var account = new Accounts();
            account.userID = userID;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BusinessAccount(int userID, string accountChoice, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountType = "Business";
            account.dateCreated = DateTime.Today;
            account.balance = balance;

            if (accountChoice == "1")
            {
                account.interest = 1.05;
                account.imf = 12;
            }

            if (accountChoice == "2")
            {
                account.interest = 1.0289;
                account.imf = 6;
            }

            if (accountChoice == "3")
            {
                account.interest = 1.015;
                account.imf = 3;
            }

            account.dateInterest = DateTime.Today.AddMonths(Convert.ToInt32(account.imf));

            var transaction = new Transaction();
            transaction.userID = account.userID;
            transaction.accountID = account.accountID;
            transaction.transactionDate = DateTime.Now;
            transaction.transactionProcessed = "Opened Account and Deposited $" + balance;

            _context.Add(account);
            await _context.SaveChangesAsync();
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts", new { userId = account.userID });
        }

        public IActionResult LoanAccount(int userID)
        {
            var account = new Accounts();
            account.userID = userID;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoanAccount(int userID, string accountChoice)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountType = "Loan";
            account.dateCreated = DateTime.Today;
            account.imf = 12;
            account.dateInterest = DateTime.Today.AddMonths(Convert.ToInt32(account.imf));

            if (accountChoice == "1")
            {
                account.interest = 1.025;
                account.balance = 20000;
            }

            if (accountChoice == "2")
            {
                account.interest = 1.055;
                account.balance = 50000;
            }

            if (accountChoice == "3")
            {
                account.interest = 1.11;
                account.balance = 100000;
            }

            var transaction = new Transaction();
            transaction.userID = account.userID;
            transaction.accountID = account.accountID;
            transaction.transactionDate = DateTime.Now;
            transaction.transactionProcessed = "Took Out a Loan of $" + account.balance;

            _context.Add(account);
            await _context.SaveChangesAsync();
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts", new { userId = account.userID });
        }

        public IActionResult TermAccount(int userID)
        {
            var account = new Accounts();
            account.userID = userID;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TermAccount(int userID, string accountChoice, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.balance = balance;
            account.accountType = "Term";
            account.dateCreated = DateTime.Today;

            if (accountChoice == "1")
            {
                account.interest = 1.045;
                account.imf = 12;
            }

            if (accountChoice == "2")
            {
                account.interest = 1.175;
                account.imf = 60;
            }

            if (accountChoice == "3")
            {
                account.interest = 1.25;
                account.imf = 120;
            }

            account.dateInterest = DateTime.Today.AddMonths(Convert.ToInt32(account.imf));

            _context.Add(account);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Accounts", new { userId = account.userID });
        }

        // GET: Banking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var accounts = await _context.Accounts
                .FirstOrDefaultAsync(m => m.accountID == id);
            if (accounts == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            return View(accounts);
        }

        // POST: Banking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accounts = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.accountID == id);
        }
    }
}
