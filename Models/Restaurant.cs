using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Allows us to use the annotations within our properties.
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Models
{
    // This type of object is known as an Entity
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double AverageFoodScore
        {
            get
            {
                if(Ratings.Count == 0)
                {
                    return 0;
                }

                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.FoodScore;
                    total += rating.AtmosphereScore;
                    total += rating.CleanlinessScore;
                }
                return total / Ratings.Count;
            }
        }

    }
}