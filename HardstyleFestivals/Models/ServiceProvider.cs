using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardstyleFestivals.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public double? DefaultServiceCosts { get; set; }
        public double? DefaultIdealCosts { get; set; }


    }
}