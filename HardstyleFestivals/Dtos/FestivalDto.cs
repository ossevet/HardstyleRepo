using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardstyleFestivals.Dtos
{
    //Dto's zijn objecten die in plaats van het eigenlijke domain model object gebruikt worden. 
    //Het is beter dat de API geen "Festival" objecten als parameter mee krijgt, dan is de api erg gevoelig voor veranderingen van het domain model
    //En op deze manier kan je bepaalde velden uit het object laten (velden die niet aangepast mogen worden)

    //gevolg hiervan is dat je vaak het Festival object moet kopieren naar het FestivalDto object. Hier hebben we
    //de tool "automapper" voor (zie class MappingProfile in app_start).
    public class FestivalDto
    {

        
        public int Id { get; set; }
       
        [Required]
        public DateTime Datum { get; set; }

        [Required]
        [StringLength(255)]      
        public string Naam { get; set; }
        public string NaamDesc { get; set; }
        public string Website { get; set; }
        public string TicketsURL { get; set; }
        public decimal? PrijsEarly { get; set; }
        public decimal? PrijsLate { get; set; }
        //public ServiceProvider ServiceProvider { get; set; }  in dto's ook geen verwijzingen naar domain models, dus ghier moeten we ook een dto van maken
        public ServiceProviderDto ServiceProvider { get; set; }
        public decimal? KostService { get; set; }
        public decimal? KostBetaling { get; set; }
        public string YoutubeCode { get; set; }
        public string Beschrijving { get; set; }
        public string Muziek { get; set; }
        public DateTime? StartVVK { get; set; }
        public DateTime? Uitverkocht { get; set; }






    }
}
