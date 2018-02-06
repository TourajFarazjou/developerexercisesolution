using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExerciseWebApplication.ViewModels
{
    public class DistanceViewModel
    {
        [DisplayName("Airport (A)")]
        public string AirportA { get; set; }

        [DisplayName("Airport (B)")]
        public string AirportB { get; set; }

        public IEnumerable<string> AvailableAirports { get; set; }
    }
}