using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        new CustomerDbContext db = new CustomerDbContext();
        public override ICollection<Category> GetAll()
        {
            var categories=  db
                .Categories
                .Include(c=>c.Products)
                .ToList();
            return categories;
        }

        public List<Category> LoadProducts(List<Category> categories)
        {
            foreach (var category in categories)
            {
                db.Entry(category)
                    .Collection(c => c.Products)
                    .Query()
                    .Where(c=>c.IsActive == true)
                    .Load();

               
            }

            return categories;

        }


    }
}
