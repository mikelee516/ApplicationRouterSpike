using ApplicationRouter.Data;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ApplicationRouter.Repositories;
using ApplicationRouter.Models;

namespace ApplicationRouter.Controllers
{
    public class EndpointController : ApiController
    {
        private readonly EndpointRegistrationRepository _repository;

        public EndpointController(EndpointRegistrationRepository repository)
        {
            _repository = repository;
        }

        // GET api/endpoints 
        public IEnumerable<Endpoint> Get()
        {
            return _repository.GetAll(DateTime.Now.AddHours(-1));
        }

        // GET api/endpoints/SomeEndpointName 
        public Endpoint Get(string id)
        {
            return _repository.Get(id, DateTime.Now.AddHours(-1));
        }

        // POST api/endpoints 
        public void Post(Endpoint newRegistration)
        {
            _repository.Add(newRegistration);
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
