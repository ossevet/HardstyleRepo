using System.Web;
using System.Web.Mvc;

namespace HardstyleFestivals
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Dit global filter zorgt ervoor dat bij een error vanaf iedere pagina naar een errorpage geleid wordt
            filters.Add(new HandleErrorAttribute());
        
            //Dit global filter zorgt ervoor dat geen enkele pagina anoniem te bezoeken is.
            //Dus als een bezoeker naar een paginna gaat wordt hij verwezen naar de login pagina.
            //Pagina's/controllers die anoniem te bezoeken moge zijn, moet je [AlowAnonymous] voor zetten
            //(Dit zou je ook per controller of per action kunnen regelen door "[Authorize]" ervoor te zeten)
            filters.Add(new AuthorizeAttribute());
            
        }


    }
}
