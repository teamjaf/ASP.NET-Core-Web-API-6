using Microsoft.AspNetCore.Mvc;

namespace Card_Api.Controllers;

public class CardsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}