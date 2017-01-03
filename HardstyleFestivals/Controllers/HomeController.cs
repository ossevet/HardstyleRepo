using HardstyleFestivals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;//nodig voor de "include" (eager loading)

namespace HardstyleFestivals.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {   //de homepage moet een lijst met festivals laten zien.
            
            //haal de lijst op uit de DB.
            //LET OP: om gelinkte objecten ook mee te krijgen (in dit geval de ServiceProvider die hoort bij het festival)
            //moet je die "Include" hier toevoegen. Dit nomen we EAGER LOADING
            var FestivalsList = new List<Festival>();
            var context = new ApplicationDbContext();
            var query =
                from f in context.Festivals
                orderby f.Naam
                select f;           
            FestivalsList = query.Include(f=>f.ServiceProvider).ToList();

            //Zet de lijst in het juiste viewModel;
            var vm = new HardstyleFestivals.ViewModels.FestivalsListViewModel();
            vm.lstFestivals = FestivalsList;


            //Geef viewmodel mee aan view
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}