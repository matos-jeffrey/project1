using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetBankDB.Models;

namespace NetBankDB.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult MainMenu(int userID)
        {
            return View(userID);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}