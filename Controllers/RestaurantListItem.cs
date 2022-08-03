using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantListItem
    {
        // This class is used to help us provide details of our restaurants with only the Average score.
        // Being used in the "GetAllRestaurants" method within the Restaurant controller
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float AverageScore { get; set; }
    }
}