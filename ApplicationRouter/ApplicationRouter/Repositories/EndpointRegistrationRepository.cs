using ApplicationRouter.Data;

namespace ApplicationRouter.Repositories
{
    public class EndpointRegistrationRepository
    {
        private IAppRouterContext _context;

        public EndpointRegistrationRepository(Data.IAppRouterContext _context)
        {
            // TODO: Complete member initialization
            this._context = _context;
        }

        public void Add(Models.Endpoint registerMe)
        {
            throw new System.NotImplementedException();
        }
    }
}
