using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCarMvcProject.ViewModels
{
    public class CarViewModels
    {
        public List<Brands> Brands { get; set; }
        public List<Colors> Colors { get; set; }
        public Cars Cars  { get; set; }
    }
}