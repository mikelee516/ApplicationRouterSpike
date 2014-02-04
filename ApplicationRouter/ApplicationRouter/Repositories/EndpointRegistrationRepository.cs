using System;
using ApplicationRouter.Data;
using ApplicationRouter.Models;

namespace ApplicationRouter.Repositories
{
    public class EndpointRegistrationRepository
    {
        private readonly IAppRouterContext _context;

        public EndpointRegistrationRepository(IAppRouterContext context)
        {
            _context = context;
        }

        public void Add(Endpoint registerMe)
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
    }
}
