using Ciber.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    private readonly SignInManager<User> _signInManager;

    public AccountController(SignInManager<User> signInManager)
    {
      _signInManager = signInManager;
    }
    
    public async Task<IActionResult> Index(string returnUrl="")
    {
      await _signInManager.SignOutAsync();
      ViewData["ReturnUrl"] = returnUrl;
      return RedirectToAction("Login");
    }

    public IActionResult Login(string returnUrl = "")
    {
      ViewData["ReturnUrl"] = returnUrl;
      return View();
    }

    public async Task<IActionResult> LoginVerify(string username, string password, string returnUrl = null)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
      {
        ViewBag.error = "Invalid Account";
        return RedirectToAction("Login"); ;
      }
      else
      {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Order");
        }
        else
        {
          ViewBag.error = "Invalid Account";
          return RedirectToAction("Login");
        }
      }
    }

    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Login");
    }
  }
}
