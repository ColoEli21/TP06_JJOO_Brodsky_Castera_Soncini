using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_JJOO.Models;

namespace TP_JJOO.Controllers;

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
    public IActionResult Deportes()
    {
        ViewBag.Deportes = BD.ListarDeporte();
        return View();
    }
    public IActionResult Paises()
    {
        ViewBag.Paises = BD.ListarPaises();
        return View();
    }
    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.Deporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.Deportistas = BD.ListarDeportistas1(idDeporte);
        return View("DetalleDeporte");
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.Pais = BD.VerInfoPais(idPais);
        ViewBag.Deportistas = BD.ListarDeportistas2(idPais);
        return View("DetallePais");
    }
    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Deportes = BD.ListarDeporte();
        ViewBag.Paises = BD.ListarPaises();
        ViewBag.Deportista = BD.VerInfoDeportista(idDeportista);
        return View("DetalleDeportista");
    }
    public IActionResult AgregarDeportista()
    {
         ViewBag.Paises = BD.ListarPaises();
         ViewBag.Deportes = BD.ListarDeporte();
        return View();
    }
    [HttpPost]
    public IActionResult GuardarDeportista(Deportista dep)
    {
        BD.AgregarDeportista(dep);
        return View("Index");
    }
    public IActionResult EliminarDeportista(int idCandidato)
    {
        BD.EliminarDeportista(idCandidato);
        return View("Index");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Historia()
    {
        return View();
    }
}
