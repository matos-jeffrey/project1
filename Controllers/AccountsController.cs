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
    public class AccountsController : Controller
    {
        private readonly NetBankContext _context;

        public AccountsController(NetBankContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index(int? userID)
        {
            return View(await _context.Accounts.Where(a => a.userID == userID).ToListAsync<Accounts>());
        }

        //public async Task<IActionResult> ViewAccounts(int? userID)
        //{
        //    if (userID == null)
        //    {
        //        return NotFound();
        //    }

        //    var accounts = await _context.Accounts.Where(a => a.userID == userID).ToListAsync<Accounts>();
        //    if (accounts == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(accounts);
        //}

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ViewAccounts(int userID)
        //{
        //    if (id != accounts.userID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(accounts);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            //This is wrong
        //            if (!AccountsExists(accounts.userID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userID);
        //}

        // GET: Accounts/Details/5
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

        // GET: Accounts/Create
        public IActionResult Create(int userId)
        {
            var account = new Accounts();
            account.userID = userId;
            account.dateCreated = DateTime.Today;

            return View(account);
        }

        // POST: Accounts/Create
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
                return RedirectToAction("MainMenu", "MainMenu", new { userId = accounts.userID });
                //return RedirectToAction(nameof(Index));
            }
            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Deposit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (accounts.accountType == "Term" || accounts.accountType == "Loan")
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            return View(accounts);
        }

        public async Task<IActionResult> Transactions(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var listTrans = await _context.Transaction.Where(a => a.accountID == id).ToListAsync<Transaction>();
            if (listTrans == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var count = listTrans.Count;
            var tenTrans = listTrans.Skip(count - 10).Reverse();

            return View(tenTrans);
        }

        public async Task<IActionResult> DateRangeTrans(int? id, DateTime date1, DateTime date2)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var listTrans = await _context.Transaction.Where(a => a.accountID == id && a.transactionDate >= date1 && a.transactionDate <= date2).ToListAsync<Transaction>();
            if (listTrans == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }
            var transList = listTrans.Skip(0).Reverse();
            return View("Transactions", transList);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(int userID, int accountID, double amount, string accountType, double interest, DateTime dateCreated, DateTime dateInterest, int imf, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountID = accountID;
            account.accountType = accountType;
            account.interest = interest;
            account.dateCreated = dateCreated;
            account.dateInterest = dateInterest;
            account.imf = imf;
            account.balance = balance + amount;

            if (accountID != account.accountID)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var transaction = new Transaction();
                    transaction.userID = account.userID;
                    transaction.accountID = account.accountID;
                    transaction.transactionDate = DateTime.Now;
                    transaction.transactionProcessed = "Deposited $" + amount + " into " + account.accountType + " (" + accountID + ")";

                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(account.accountID))
                    {
                        return RedirectToAction("ErrorPage", "MainMenu");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts", new { userId = account.userID });
            }
            return View(account);
        }

        public async Task<IActionResult> Withdraw(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (accounts.accountType == "Term" || accounts.accountType == "Loan")
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(int userID, int accountID, double amount, string accountType, double interest, DateTime dateCreated, DateTime dateInterest, int imf, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountID = accountID;
            account.accountType = accountType;
            account.interest = interest;
            account.dateCreated = dateCreated;
            account.dateInterest = dateInterest;
            account.imf = imf;
            account.balance = balance - amount;

            if (accountID != account.accountID)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }
            if (account.accountType == "Checking" && account.balance < 0)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var transaction = new Transaction();
                    transaction.userID = account.userID;
                    transaction.accountID = account.accountID;
                    transaction.transactionDate = DateTime.Now;
                    transaction.transactionProcessed = "Withdrew $" + amount + " from " + account.accountType + " (" + accountID + ")";

                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(account.accountID))
                    {
                        return RedirectToAction("ErrorPage", "MainMenu");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts", new { userId = account.userID });
            }
            return View(account);
        }

        public async Task<IActionResult> Transfer(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var listTrans = await _context.Accounts.Where(a => a.userID == id).ToListAsync<Accounts>();
            if (listTrans == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }
            
            return View(listTrans);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(double amount, int accountsFrom, int accountsTo)
        {
            var accountFrom = await _context.Accounts.FindAsync(accountsFrom);
            var accountTo = await _context.Accounts.FindAsync(accountsTo);

            
            accountFrom.balance -= amount;
            accountTo.balance += amount;

            if (accountFrom.accountType == "Checking" && accountFrom.balance < 0)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string transactionString = "Transferred $" + amount + " From " + accountFrom.accountType + " (" + accountFrom.accountID + ") To " + accountTo.accountType + " (" + accountTo.accountID + ")";
                    ;
                    var transactionFrom = new Transaction();
                    transactionFrom.userID = accountFrom.userID;
                    transactionFrom.accountID = accountFrom.accountID;
                    transactionFrom.transactionDate = DateTime.Now;
                    transactionFrom.transactionProcessed = transactionString;

                    var transactionTo = new Transaction();
                    transactionTo.userID = accountTo.userID;
                    transactionTo.accountID = accountTo.accountID;
                    transactionTo.transactionDate = DateTime.Now;
                    transactionTo.transactionProcessed = transactionString;

                    _context.Update(accountFrom);
                    await _context.SaveChangesAsync();
                    _context.Update(accountTo);
                    await _context.SaveChangesAsync();
                    _context.Update(transactionFrom);
                    await _context.SaveChangesAsync();
                    _context.Update(transactionTo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(accountFrom.accountID))
                    {
                        return RedirectToAction("ErrorPage", "MainMenu");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts", new { userId = accountFrom.userID });
            }
            return View(await _context.Accounts.Where(a => a.userID == accountFrom.userID).ToListAsync<Accounts>());
        }

        public async Task<IActionResult> PayLoan(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (accounts.accountType == "Term" || accounts.accountType == "Checking" || accounts.accountType == "Business")
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayLoan(int userID, int accountID, double amount, string accountType, double interest, DateTime dateCreated, DateTime dateInterest, int imf, double balance)
        {
            var account = new Accounts();

            account.userID = userID;
            account.accountID = accountID;
            account.accountType = accountType;
            account.interest = interest;
            account.dateCreated = dateCreated;
            account.dateInterest = dateInterest;
            account.imf = imf;
            account.balance = balance - amount;

            if (accountID != account.accountID)
            {
                return RedirectToAction("ErrorPage", "MainMenu");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var transaction = new Transaction();
                    transaction.userID = account.userID;
                    transaction.accountID = account.accountID;
                    transaction.transactionDate = DateTime.Now;
                    transaction.transactionProcessed = "Payed $" + amount + " to " + account.accountType + " (" + accountID + ")";

                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(account.accountID))
                    {
                        return RedirectToAction("ErrorPage", "MainMenu");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts", new { userId = account.userID });
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
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

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accounts = await _context.Accounts.FindAsync(id);
            var userID = accounts.userID;
            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts", new { userId = userID });
        }



        private bool AccountsExists(int accountID)
        {
            return _context.Accounts.Any(e => e.accountID == accountID);
        }

        //private bool AccountExists(int userID, int id)
        //{
        //    return _context.Accounts.Any(e => e.accountID == id && e.userID == userID);
        //}
    }
}
