using System.Collections.Generic;
using System.ComponentModel;
using ExerciseWebApplication.Models;
using PagedList;

namespace ExerciseWebApplication.ViewModels
{
    public class HomeViewModel
    {
        [DisplayName("Country")]
        public string Country { get; set; }

        public IEnumerable<string> AvailableCountries { get; set; }

        public IPagedList<Airport> Airports { get; set; }
    }
}

