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
    }
}