using System.ComponentModel;

namespace ExerciseWebApplication.Models
{
    public class Airport
    {
        [DisplayName("Code")]
        public string iata { get; set; }

        [DisplayName("Country")]
        public string iso { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Continent")]
        public string continent { get; set; }

        [DisplayName("Type")]
        public string type { get; set; }

        public string lat { get; set; }
        public string lon { get; set; }
    }
}

