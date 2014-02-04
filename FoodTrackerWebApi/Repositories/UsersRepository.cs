using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrackerWebApi.Repositories
{
    public class UsersRepository
    {
        private readonly Data.FoodTrackerContext _context;

        public UsersRepository(Data.FoodTrackerContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.User> GetAll()
        {
            return _context.Users.Select(f => new Models.User { Name = f.Name });
        }

        public Models.User Get(string name)
        {
            var result = _context.Users.Single(f => f.Name == name);
            return new Models.User { Name = result.Name };
        }

        public void Add(Models.User addMe)
        {
            if(string.IsNullOrWhiteSpace(addMe.Name))
                throw new ArgumentException("User.Name is null or blank.");

            if (_context.Users.Any(f => f.Name == addMe.Name))
                throw new ArgumentException(string.Format("User [{0}] already exists in the system.", addMe.Name));

            _context.Users.Add(new Data.User { Name = addMe.Name });
            _context.SaveChanges();
        }
    }
}
