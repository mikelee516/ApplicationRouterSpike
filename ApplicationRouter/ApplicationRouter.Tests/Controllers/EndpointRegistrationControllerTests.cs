using ApplicationRouter.Controllers;
using ApplicationRouter.Models;
using ApplicationRouter.Repositories;
using NUnit.Framework;
using Rhino.Mocks;

namespace ApplicationRouter.Tests.Controllers
{
    [TestFixture]
    public class EndpointRegistrationControllerTests
    {
        private EndpointRegistrationRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = MockRepository.GenerateMock<EndpointRegistrationRepository>();
        }

        [Test]
        public void ShouldAddRegistration()
        {
            var registerMe = new Endpoint { Name = "SomeName", URL = "SomeURL", Version = "1.0.0"};
            var controller = new EndpointController(_repository);
            controller.Post(registerMe);

            _repository.AssertWasCalled(r => r.Add(registerMe));
        }
    }
}
