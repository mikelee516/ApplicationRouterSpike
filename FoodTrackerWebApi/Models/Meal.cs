using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrackerWebApi.Models
{
    public class Meal
    {
        public User User { get; set; }
        public Food Food { get; set; }
        public DateTime Time { get; set; }
    }
}
