using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_Final.Models;

namespace TP_Final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ResultsVideojuego(string info)
    {
        ViewBag.Videojuegos = BD.BuscarVideojuegosSegunNombre(info);
        return View();
    }

    public IActionResult ResultsEmpresa(string info2)
    {
        ViewBag.Empresas = BD.BuscarEmpresasSegunNombre(info2);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
