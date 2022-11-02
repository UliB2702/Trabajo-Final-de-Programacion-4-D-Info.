using System.Diagnostics;
using System;
using System.Collections.Generic;
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

    public IActionResult AgregarEmpresa()
    {
        return View();
    }

    public IActionResult AgregarVideojuego()
    {
        ViewBag.Empresas = BD.BuscarEmpresas();
        ViewBag.Categorias = BD.BuscarCategorias();
        ViewBag.Clasificaciones = BD.BuscarClasificacion();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarVideojuego(string Nombre, int empresa ,List<int> categoria, int clasificacion ,string Descripción, DateTime fechaLanzamiento, string Caratula, string Banner, string Logo)
    {
        Console.WriteLine(categoria[1]);
        BD.InsertarVideojuego(empresa, fechaLanzamiento, Nombre, Descripción, clasificacion, Caratula, Banner,Logo);
        Videojuego id = BD.BuscarUltimoRegistro();
        BD.InsertarCategorias(categoria, id.IdVideojuego);
        return View("Index");
    }

    [HttpPost]
    public IActionResult GuardarEmpresa(string Nombre, string SedeCentral, string Fundador, DateTime fechaFundacion, string Logo)
    {
        BD.InsertarEmpresa(Nombre, SedeCentral, Fundador, fechaFundacion, Logo);
        return RedirectToAction("Index");
    }

    public IActionResult EliminarVideojuego(int id2)
    {
        Console.WriteLine(id2);
        BD.EliminarVideojuegoDeVXC(id2);
        BD.EliminarVideojuegoSegunId(id2);
        return View("Index");
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

    public IActionResult VerInfoVideojuego(int id)
    {
        ViewBag.Videojuego = BD.BuscarVideojuegoSegunID(id);
        ViewBag.Empresa = BD.BuscarEmpresasSegunID(ViewBag.Videojuego.IdEmpresa);
        ViewBag.Clasificacion = BD.BuscarClasificacionSegunID(ViewBag.Videojuego.IdClasificacion);
        List<int> ids = BD.BuscarCategoriaXVideojuego(id);
        ViewBag.Categorias = BD.BuscarCategoriaPorIdVideojuego(ids);

        return View();
    }

    public IActionResult VerInfoEmpresa(int id2)
    {
        ViewBag.Empresa = BD.BuscarEmpresasSegunID(id2);
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
