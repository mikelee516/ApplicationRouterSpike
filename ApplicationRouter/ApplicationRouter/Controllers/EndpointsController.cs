using ApplicationRouter.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using ApplicationRouter.Repositories;
using ApplicationRouter.Models;

namespace ApplicationRouter.Controllers
{
    public class EndpointsController : ApiController
    {
        private readonly EndpointRegistrationsRepository _repository;

        public EndpointsController(EndpointRegistrationsRepository repository)
        {
            _repository = repository;
        }

        // GET api/endpoints 
        public IEnumerable<Endpoint> Get()
        {
            return _repository.GetAll(DateTime.Now.AddMinutes(-5));
        }

        // GET api/endpoints/SomeEndpointName 
        public IEnumerable<Endpoint> Get(string id)
        {
            return _repository.Get(id, DateTime.Now.AddMinutes(-5));
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
