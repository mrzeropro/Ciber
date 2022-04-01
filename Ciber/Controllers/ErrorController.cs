using Ciber.Logging;
using Ciber.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
  public class ErrorController : Controller
  {
    private readonly ILoggerManager _logger;
    public ErrorController(ILoggerManager logger)
    {
      _logger = logger;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Index()
    {
      var contextFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
      if (contextFeature != null)
      {
        _logger.LogError($"Something went wrong: {contextFeature.Error}");
      }

      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
