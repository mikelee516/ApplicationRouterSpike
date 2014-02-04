using FoodTrackerWebApi.Models;
using FoodTrackerWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FoodTrackerWebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UsersRepository _repository;

        public UsersController(UsersRepository repository)
        {
            _repository = repository;
        }

        // GET api/users
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        // GET api/users/SomeUserName
        public User Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/users 
        public void Post(User newUser)
        {
            _repository.Add(newUser);
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
