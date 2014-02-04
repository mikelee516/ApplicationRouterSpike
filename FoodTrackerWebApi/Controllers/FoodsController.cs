using FoodTrackerWebApi.Models;
using FoodTrackerWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FoodTrackerWebApi.Controllers
{
    public class FoodsController : ApiController
    {
        private readonly FoodsRepository _repository;

        public FoodsController(FoodsRepository repository)
        {
            _repository = repository;
        }

        // GET api/endpointsfoods 
        public IEnumerable<Food> Get()
        {
            return _repository.GetAll();
        }

        // GET api/foods/SomeFoodName
        public Food Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/foods 
        public void Post(Food newFood)
        {
            _repository.Add(newFood);
        }

        // PUT api/endpoints/5 
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/valuesendpoints/5 
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
