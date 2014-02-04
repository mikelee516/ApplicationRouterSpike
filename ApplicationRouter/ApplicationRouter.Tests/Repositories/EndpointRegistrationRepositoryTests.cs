using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using ApplicationRouter.Data;
using ApplicationRouter.Repositories;
using ApplicationRouter.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace ApplicationRouter.Tests.Repositories
{
    [TestFixture]
    public class EndpointRegistrationRepositoryTests
    {
        private IAppRouterContext _context;
        private IDbSet<EndpointRegistration> _endpointRegistrations;

        [SetUp]
        public void SetUp()
        {
            _endpointRegistrations = MockRepository.GenerateMock<IDbSet<EndpointRegistration>>();
            _context = MockRepository.GenerateMock<IAppRouterContext>();
        }

        [Test]
        public void ShouldRegisterANewEndpoint()
        {
            _context.Stub(c => c.EndpointRegistrations).Return(_endpointRegistrations);
            var repository = new EndpointRegistrationsRepository(_context);

            var registerMe = new Endpoint { Name = "SomeName", URL="htp://localhost", Version = "v1.0.0.1"};
            repository.Add(registerMe);

            _endpointRegistrations.AssertWasCalled(er => 
                er.Add(Arg<EndpointRegistration>.Matches(registration => 
                    registration.EndPoint == registerMe.Name
                    && registration.Url == registerMe.URL
                    && registration.Version == registerMe.Version)));
            _context.AssertWasCalled(c => c.SaveChanges());
        }

        [TestCase("SomeName", "SomeUrl", null)]
        [TestCase("SomeName", null, "SomeVersion")]
        [TestCase(null, "SomeUrl", "SomeVersion")]
        public void ShouldThrowAnExceptionIfTheRegistrationIsIncomplete(string endpointName, string url, string version)
        {
            var registration = new Endpoint {Name = endpointName, URL = url, Version = version};
            var repository = new EndpointRegistrationsRepository(_context);
            Assert.Throws<ArgumentException>(() => repository.Add(registration));
        }

        //[Test]
        //public void ShouldReturnRegistrationsWithinATime()
        //{
        //    _context.Stub(c => c.EndpointRegistrations).Return(new );
        //}
    }
}
