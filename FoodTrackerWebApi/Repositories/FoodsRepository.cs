using Data = FoodTrackerWebApi.Data;
using Models = FoodTrackerWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FoodTrackerWebApi.Repositories
{
    public class FoodsRepository
    {
        private readonly Data.FoodTrackerContext _context;

        public FoodsRepository(Data.FoodTrackerContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Food> GetAll()
        {
            return _context.Foods.Select(f => new Models.Food { Name = f.Name });
        }

        public Models.Food Get(string name)
        {
            var result = _context.Foods.Single(f => f.Name == name);
            return new Models.Food { Name = result.Name };
        }

        public void Add(Models.Food addMe)
        {
            if (string.IsNullOrWhiteSpace(addMe.Name))
                throw new ArgumentException(string.Format("Food.Name is null or blank.", addMe.Name));

            if (_context.Foods.Any(f => f.Name == addMe.Name))
                throw new ArgumentException(string.Format("Food [{0}] already exists in the system.", addMe.Name));

            _context.Foods.Add(new Data.Food { Name = addMe.Name });
            _context.SaveChanges();
        }
    }
}
