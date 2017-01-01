using AutoMapper;
using HardstyleFestivals.Dtos;
using HardstyleFestivals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;//nodig voor de "include" (eager loading)

namespace HardstyleFestivals.Controllers.API
{

    //Dit is een API controller in plaats van een MVC controller. (in .net core zullen dezet twee verschillende projecten samengevoegd zijn).
    //een API controller retourneert data in plaats van Html views. Dus ".../api/Getfestivals" in de URL geeft geen mooie view met bijvoorbeeld een tabel 
    //met alle festivals, maar een lijst in XML van alle festivals. Deze API is dus geschikt om uit te lezen door andere machines 
    //(Een API is een website voor machines zoals kristof het altijd zegt)
    public class FestivalsController : ApiController
    {

        private ApplicationDbContext _context;

        public FestivalsController ()
	    {
            _context = new ApplicationDbContext();
	    }

        //let op de conventie: /api/festivals gaat naar functie "GetFestivals"

        //zonder dto's:
        ////GET /api/festivals
        //public IEnumerable<Festival> GetFestivals()
        //{
        //    //In een API retourneren we dus geen view met HTML en alles erop en eraan, maar we retourneren alleen een lijstje met data. 
        //    //het genereren van de HTML wordt op de client gedaan (door bijvoorbeeld de "Datatables" library)
        //    return _context.Festivals.ToList();
        //}

        //Met Dto's
        //GET /api/festivals
        public IEnumerable<FestivalDto> GetFestivals()
        {
            return _context.Festivals.
                Include(f => f.ServiceProvider) //(eager loading! Zo wordt het het serviceprovider object meegenomen bij het festival!)
                .ToList()
                .Select(Mapper.Map<Festival, FestivalDto>); //(delegate in de select)
        }


        //Zonder Dto's
        ////GET /api/festivals
        //public Festival GetFestival(int Id)
        //{
        //    var festival = _context.Festivals.SingleOrDefault(f=>f.Id==Id);

        //    if (festival == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return festival;
        //}

        //Met Dto's
        //GET /api/festivals
        //public FestivalDto GetFestival(int Id)
        //{
        //    var festival = _context.Festivals.SingleOrDefault(f => f.Id == Id);

        //    if (festival == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    //map festival to festivalDto (=copy all properties with the same name)
        //    var festivalDto = Mapper.Map<Festival, FestivalDto>(festival);
        //    return festivalDto;

        //}
        //met IHttpActionResult als returnwaarde ipv een Dto.
        //Dit kan je gebruiken als je aan alle REST regels wilt voldoen.
        //GET /api/festivals
        public IHttpActionResult GetFestival(int Id)
        {
            var festival = _context.Festivals.SingleOrDefault(f => f.Id == Id);

            if (festival == null)
                return NotFound();

            //map festival to festivalDto (=copy all properties with the same name)
            var festivalDto = Mapper.Map<Festival, FestivalDto>(festival);
            return Ok(festivalDto);

        }




        //POST /api/Festvals       
        [HttpPost] //voeg deze data annotation toe om ervoor te zorgen dat de method alleen draait bij een post request.
        public Festival CreateFestival(Festival festival)
        {
            //eerst even checken of he formulier goed is ingevuld
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Festivals.Add(festival);
            _context.SaveChanges();

            return festival;
        }


        //PUT /api/festivals/1
        //Updaten van een festival, geef het id van het betreffende festival mee en een ingevuld festival object
        [HttpPut]
        public void UpdateFestival(int Id, Festival festival) 
        {
            //eerst even checken of he formulier goed is ingevuld
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var festivalInDb = _context.Festivals.SingleOrDefault(f => f.Id == Id);
            if (festivalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //(dit kan sneller met de "automapper" tool)
            festivalInDb.Datum = festival.Datum;
            festivalInDb.Naam = festival.Naam;
            festivalInDb.NaamDesc = festival.NaamDesc;
            festivalInDb.Website = festival.Website;
            festivalInDb.TicketsURL = festival.TicketsURL;
            festivalInDb.PrijsEarly = festival.PrijsEarly;
            festivalInDb.PrijsLate = festival.PrijsLate;
            festivalInDb.KostService = festival.KostService;
            festivalInDb.KostBetaling = festival.KostBetaling;
            festivalInDb.YoutubeCode = festival.YoutubeCode;
            festivalInDb.Beschrijving = festival.Beschrijving;
            festivalInDb.Muziek = festival.Muziek;
            festivalInDb.StartVVK = festival.StartVVK;
            festivalInDb.Uitverkocht = festival.Uitverkocht;

            _context.SaveChanges();

        }


        //DELETE /api/festivals/1
        [HttpDelete]
        public string DeleteFestival(int Id)
        {
            var festivalInDb = _context.Festivals.SingleOrDefault(f => f.Id == Id);
            if (festivalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Festivals.Remove(festivalInDb);
            _context.SaveChanges();

            return "succes";

        } 



    }
}
