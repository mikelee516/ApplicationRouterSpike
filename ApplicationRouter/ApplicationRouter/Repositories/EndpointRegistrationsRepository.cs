using System;
using System.Linq;
using ApplicationRouter.Data;
using ApplicationRouter.Models;
using System.Collections.Generic;

namespace ApplicationRouter.Repositories
{
    public class EndpointRegistrationsRepository
    {
        private readonly IAppRouterContext _context;

        public EndpointRegistrationsRepository(IAppRouterContext context)
        {
            _context = context;
        }

        public virtual void Add(Endpoint registerMe)
        {
            if(string.IsNullOrWhiteSpace(registerMe.Name)
                || string.IsNullOrWhiteSpace(registerMe.URL)
                || string.IsNullOrWhiteSpace(registerMe.Version))
                throw new ArgumentException(string.Format("The endpoint registration is missing data: {0}", registerMe));

            _context.EndpointRegistrations.Add(
                new EndpointRegistration{
                    EndPoint = registerMe.Name, 
                    Url = registerMe.URL,
                    Version = registerMe.Version
                });

            _context.SaveChanges();
        }

        public virtual IEnumerable<Endpoint> GetAll(DateTime cutoffTime)
        {
            return _context.EndpointRegistrations
                .Where(er => er.RegistrationTime > cutoffTime)
                .Select(er => new Endpoint { 
                    Name = er.EndPoint, 
                    URL = er.Url,
                    Version = er.Version
                }).ToArray();
        }

        public virtual Endpoint Get(string endpointName, DateTime cutoffTime)
        {
            var result = _context.EndpointRegistrations
                .Single(er => er.EndPoint == endpointName 
                    && er.RegistrationTime > cutoffTime);

            return new Endpoint
                {
                    Name = result.EndPoint,
                    URL = result.Url,
                    Version = result.Version
                };
        }
    }
}
