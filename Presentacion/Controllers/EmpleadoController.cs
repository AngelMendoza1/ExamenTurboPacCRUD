using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        public ActionResult Registros()
        {
            Entidad.Result result = Negocio.Empleado.Registros();
            Entidad.Empleado empleado = new Entidad.Empleado();
            empleado.Empleados = result.Objects;
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Formulario(int? idEmpleado) 
        {
            Entidad.Empleado empleado = new Entidad.Empleado();

            if (idEmpleado == null)
            {
                return View(empleado);
            }
            else 
            {


                Entidad.Result result = Negocio.Empleado.Registro(idEmpleado.Value);

                if (result.Correct)
                {
                    empleado = (Entidad.Empleado)result.Object;
                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }

        }

        [HttpPost]
        public ActionResult Formulario(Entidad.Empleado empleado)
        {
            Entidad.Result result = new Entidad.Result();
            if (empleado.idEmpleado == 0)
            {
                result = Negocio.Empleado.Agregar(empleado);
            }
            else
            {
                result = Negocio.Empleado.Actualizar(empleado);
            }

            if (!result.Correct)
            {
                ViewBag.Message = "Ocurrio Un Error " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public ActionResult ActualizarStatus(int? IdEmpleado)
        {
            Entidad.Empleado empleado = new Entidad.Empleado();
            Entidad.Result result = Negocio.Empleado.Registro(IdEmpleado.Value);
            empleado = (Entidad.Empleado)result.Object;
            if (result.Correct)
            {    Entidad.Result ResultStatus = Negocio.Empleado.ActualizarEstatus(empleado);
                if (!ResultStatus.Correct)
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return PartialView("Modal");
            }


            return RedirectToAction("Registros");
        }
	}
}