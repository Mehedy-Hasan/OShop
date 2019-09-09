using System;
using System.Collections.Generic;
using System.Text;
using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories.Contracts;

namespace BLL
{
    public class CategoryManager:Manager<Category>,ICategoryManager
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}
