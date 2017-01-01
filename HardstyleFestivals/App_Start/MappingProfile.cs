using AutoMapper;
using HardstyleFestivals.Dtos;
using HardstyleFestivals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardstyleFestivals.App_Start
{
    //Deze class hoort bij de Automapper, en wordt in global.asax aangeroepen
    class MappingProfile : Profile
    {
        
        public MappingProfile()
        {

            //deze methods kijken naar de namen van de properties en koppelen zo de juiste properties aan elkaar bij het kopieren
            Mapper.CreateMap<Festival, FestivalDto>();
            Mapper.CreateMap<FestivalDto, Festival>();

            Mapper.CreateMap<ServiceProvider, ServiceProviderDto>();



        }
    }
}
