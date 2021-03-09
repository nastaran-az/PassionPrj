using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CaloryCounterProject.Models;

namespace CaloryCounterProject.Controllers
{
    public class FoodDataController : ApiController
    {
        private ColoryDataContext db = new ColoryDataContext();
        /// <summary>
        /// Finds a particularFood in the database If the food is not found, return 404.
        /// </summary>
        /// <param name="id">The Food id</param>
        /// <returns>Information about the Food</returns>
        // <example>
        // GET: api/FoodData/Food/5
        // </example>
        [HttpGet]
        // GET: api/FoodData/5
        [ResponseType(typeof(FoodDto))]
        public IHttpActionResult FindFood(int id)
        {
            Food food = db.foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }
            FoodDto FoodDto = new FoodDto
            {
                foodName = food.foodName,
                foodType = food.foodType,
                foodWeight = food.foodWeight,
                calory = food.calory,
            };
            return Ok(FoodDto);
        }

        // Get: api/Getfood
        [ResponseType(typeof(IEnumerable<FoodDto>))]
        public IHttpActionResult Getfoods()
        {
            List<Food> Foods = db.foods.ToList();
            List<FoodDto> foodDtos = new List<FoodDto> { };
            foreach (var f in Foods)
            {
                FoodDto Newfood = new FoodDto
                {
                    foodId = f.foodId,
                    calory = f.calory,
                    foodName = f.foodName,
                    foodType = f.foodType,
                    foodWeight = f.foodWeight,

                };
                foodDtos.Add(Newfood);
            }
            return Ok(foodDtos);
        }

        /// <summary>
        /// Adds a food to the database.
        /// </summary>
        /// <param name="Food">A Food object. Sent as POST form data.</param>
        /// <returns>status code 200 if successful. 400 if unsuccessful</returns>
        /// <example>
        /// POST: api/FoodData/AddFood
         /// </example>
         // POST: api/FoodData
        [ResponseType(typeof(Food))]
        public IHttpActionResult AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.foods.Add(food);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food.foodId }, food);
        }

        // DELETE: api/FoodData/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult DeleteFood(int id)
        {
            Food food = db.foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.foods.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(int id)
        {
            return db.foods.Count(e => e.foodId == id) > 0;
        }
    }
}