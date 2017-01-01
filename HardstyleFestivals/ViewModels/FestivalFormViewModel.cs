using HardstyleFestivals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardstyleFestivals.ViewModels
{
    public class FestivalFormViewModel
    {
        public IEnumerable<ServiceProvider> ServiceProviders { get; set; }
        public Festival Festival { get; set; }

    }
}
