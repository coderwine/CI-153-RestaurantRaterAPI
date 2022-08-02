using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // For the "Controller" inherited class
using RestaurantRaterAPI.Models; // So we can access the models
using Microsoft.EntityFrameworkCore; // Provides us access to the ToListAsync() method in our GET

namespace RestaurantRaterAPI.Controllers
{
    [ApiController] // Distinguishes our controller as an API controller instead of a MVC controller.
    [Route("[controller]")] // makes our endpoints availableat the address of (https://localhost/restaurant)
    public class RestaurantController : Controller
    {
        // Where we create our API endpoints (CRUD)
        // install: dotnet add package Microsoft.AspNetCore.MVC

        private RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)    
        {
            _context = context;
            // constructor used to inject our db context. EF will inject an instance of the db context when it uses the constructor to set up the endpoints for the app.
        }

        [HttpPost] // Tells EF that this method is inted to handled a POST endpoint.
        public async Task<IActionResult> PostRestaurant([FromForm] RestaurantEdit model)
        {
            //[FromForm] let EF know this is coming from form data (HTML form tag)

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurants.Add(new Restaurant()
            {
                Name = model.Name,
                Location = model.Location,
            });

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurant()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id); // returns null if no id is matched

            if(restaurant == null)
            {
                return NotFound(); // provides us with a 404 code
            }

            return Ok(restaurant);
        }
    }
}