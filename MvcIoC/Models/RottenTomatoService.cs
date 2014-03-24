using System;

namespace MvcIoC.Models
{
    public class RottenTomatoService : IExternalMovieService
    {
     
        public string GetBoxOfficeHit()
        {
            return "300 Rise of an empire!";
        }

      
    }
}