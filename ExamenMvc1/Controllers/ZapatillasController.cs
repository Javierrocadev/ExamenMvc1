using Microsoft.AspNetCore.Mvc;

namespace ExamenMvc1.Controllers
{
    public class ZapatillasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
