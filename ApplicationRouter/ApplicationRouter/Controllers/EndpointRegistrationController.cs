using ApplicationRouter.Data;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ApplicationRouter.Repositories;

namespace ApplicationRouter.Controllers
{
    public class EndpointRegistrationController : ApiController
    {
        private readonly EndpointRegistrationRepository _repository;

        public EndpointRegistrationController(EndpointRegistrationRepository repository)
        {
            _repository = repository;
        }

        // GET api/values 
        public IEnumerable<EndpointRegistration> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/values/5 
        public EndpointRegistration Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/values 
        public void Post(EndpointRegistration newRegistration)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
