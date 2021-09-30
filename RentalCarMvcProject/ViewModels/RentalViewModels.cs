using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCarMvcProject.ViewModels
{
    public class RentalViewModels
    {
        public List<Cars> Cars { get; set; }
        public List<Customers> Customers { get; set; }
        public Rentals Rentals  { get; set; }
    }
}