using ExamenMvc1.Models;
using ExamenMvc1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenMvc1.Controllers
{
    public class PaginacionController : Controller
    {
        private RepositoryZapatilla repo;

        public PaginacionController(RepositoryZapatilla repo)
        {
            this.repo = repo;
        }

        //mis controllers

        //cargar las zapatillas
        public async Task<IActionResult> ZapatillasAjax()
        {
            List<Zapatilla> zapatillas = await this.repo.GetZapatillasAsync();
            return View(zapatillas);
        }

        public async Task<IActionResult> _ImagenesZapatillaAjaxPartial
    (int? posicion, int idzapatilla)
        {
            if (posicion == null)
            {
                //POSICION PARA EL EMPLEADO
                posicion = 1;
            }
            ModelImagenPaginacion model = await
                this.repo.GetImagenZapatillaAsync
                (posicion.Value, idzapatilla);
            Zapatilla zapatilla = await this.repo.FindDepartamentosAsync(idzapatilla);
            ViewData["ZAPATILLASELECCIONADO"] = zapatilla;
            ViewData["REGISTROS"] = model.Registros;
            ViewData["ZAPATILLA"] = idzapatilla;
            int siguiente = posicion.Value + 1;
            //DEBEMOS COMPROBAR QUE NO PASAMOS DEL NUMERO DE REGISTROS
            if (siguiente > model.Registros)
            {
                //EFECTO OPTICO
                siguiente = model.Registros;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }
            ViewData["ULTIMO"] = model.Registros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            ViewData["POSICION"] = posicion;
            //return View(model.Empleado);
            return PartialView("_ImagenesZapatillaAjaxPartial", model.Imagen);
        }


        public IActionResult DetailsPartial( int idzapatilla)
        {
            return View();
        }


        public async Task<IActionResult> ImagenesZapatilla
    (int? posicion, int idzapatilla)
        {
            if (posicion == null)
            {
                //POSICION PARA EL EMPLEADO
                posicion = 1;
            }
            ModelImagenPaginacion model = await
                this.repo.GetImagenZapatillaAsync
                (posicion.Value, idzapatilla);
            Zapatilla zapatilla =
                await this.repo.FindDepartamentosAsync(idzapatilla);
            ViewData["ZAPATILLASELECCIONADO"] = zapatilla;
            ViewData["REGISTROS"] = model.Registros;
            ViewData["ZAPATILLA"] = idzapatilla;
            int siguiente = posicion.Value + 1;
            //DEBEMOS COMPROBAR QUE NO PASAMOS DEL NUMERO DE REGISTROS
            if (siguiente > model.Registros)
            {
                //EFECTO OPTICO
                siguiente = model.Registros;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }
            ViewData["ULTIMO"] = model.Registros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            ViewData["POSICION"] = posicion;
            return View(model.Imagen);
        }


    }
}
