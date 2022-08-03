using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // sets the route of our URL to match our class name (minus "Controller). Ex: Instead of RatingController, it will be just Rating
    public class RatingController : Controller
    {
        private RestaurantDbContext _context;
        public RatingController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromForm] RatingEdit model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Ratings.Add(new Rating() {
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                AtmosphereScore = model.AtomsphereScore,
                RestaurantId = model.RestaurantId,
            });

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}