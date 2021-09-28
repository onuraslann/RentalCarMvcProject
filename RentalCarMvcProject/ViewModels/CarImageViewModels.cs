using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCarMvcProject.ViewModels
{
    public class CarImageViewModels
    {
        public List<Cars> Car  { get; set; }
        public CarImages CarImages { get; set; }
    }
}