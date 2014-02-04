using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrackerWebApi.Repositories
{
    public class MealsRepository
    {
        private readonly Data.FoodTrackerContext _context;

        public MealsRepository(Data.FoodTrackerContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Meal> GetAll()
        {
            return _context.Meals
                .Select(m =>
                    new Models.Meal
                    {
                        Food = new Models.Food { Name = m.Food },
                        User = new Models.User { Name = m.User },
                        Time = m.Time
                    });
        }

        public IEnumerable<Models.Meal> Get(string userName)
        {
            return _context.Meals
                .Where(m => m.User == userName)
                .Select(m =>
                    new Models.Meal
                    {
                        Food = new Models.Food { Name = m.Food },
                        User = new Models.User { Name = m.User },
                        Time = m.Time
                    });
        }

        public void Add(Models.Meal addMe)
        {
            if(string.IsNullOrWhiteSpace(addMe.User.Name))
                throw new ArgumentException("Meal.User.Name is null or blank.");

            if (string.IsNullOrWhiteSpace(addMe.Food.Name))
                throw new ArgumentException("Meal.Food.Name is null or blank.");

            _context.Meals.Add(new Data.Meal { User = addMe.User.Name, Food = addMe.Food.Name, Time = addMe.Time });
            _context.SaveChanges();
        }
    }
}
