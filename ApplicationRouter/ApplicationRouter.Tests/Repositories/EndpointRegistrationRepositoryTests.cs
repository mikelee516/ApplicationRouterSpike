using ApplicationRouter.Data;
using ApplicationRouter.Repositories;
using ApplicationRouter.Models;
using FakeItEasy;
using NUnit.Framework;

namespace ApplicationRouter.Tests.Repositories
{
    [TestFixture]
    public class EndpointRegistrationRepositoryTests
    {
        private IAppRouterContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = A.Fake<IAppRouterContext>();
        }

        [Test]
        public void ShouldRegisterANewEndpoint()
        {
            var repository = new EndpointRegistrationRepository(_context);

            var registerMe = new Endpoint { Name = "SomeName", URL="htp://localhost", Version = "v1.0.0.1"};
            repository.Add(registerMe);

            A.CallTo(_context.EndpointRegistrations)
                .Where(call => call.Method.Name == "Add" 
                    && call.Arguments.Count == 1);
            A.CallTo(() => _context.SaveChanges()).MustHaveHappened();
        }
    }
}
