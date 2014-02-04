using FoodTrackerWebApi.Models;
using FoodTrackerWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FoodTrackerWebApi.Controllers
{
    public class MealsController : ApiController
    {
        private readonly MealsRepository _repository;

        public MealsController(MealsRepository repository)
        {
            _repository = repository;
        }

        // GET api/meals
        public IEnumerable<Meal> Get()
        {
            return _repository.GetAll();
        }

        // GET api/users/SomeUserName
        public IEnumerable<Meal> Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/users 
        public void Post(Meal newMeal)
        {
            _repository.Add(newMeal);
        }

        // PUT api/users/5 
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/users/5 
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
