using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // For the "Controller" inherited class

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

    }
}