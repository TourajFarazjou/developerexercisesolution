using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseWebApplication.Services
{
    public interface ILocationService
    {
        double? ComputeDistance(string origin, string destination);
    }
}
