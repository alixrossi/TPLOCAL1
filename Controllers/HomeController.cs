using Microsoft.AspNetCore.Mvc;
using System.IO;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "XlmFile", "DataAvis.xml");
                        var opinions = new OpinionList().GetAvis(xmlPath);
                        return View(id, opinions);
                    case "Form":
                        return View(id, new FormModel());
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            // Date check: must be before 01/01/2021
            if (model.DateDebut.HasValue && model.DateDebut.Value >= new DateTime(2021, 1, 1))
            {
                ModelState.AddModelError("DateDebut", "La date de début doit être antérieure au 01/01/2021.");
            }

            if (!ModelState.IsValid)
            {
                return View("Form", model);
            }

            return View("ValidationForm", model);
        }
    }
}