using OData.DataAccess.Data;
using OData.DataAccess.Repository.Interfaces;
using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OData.DataAccess.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ArticleCategory>> GetAll()
        {
            return _dbContext.ArticleCategories.ToListAsync();
        }

        public Task<ArticleCategory> Get(int id)
        {
            return _dbContext.ArticleCategories.Where(a => a.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(ArticleCategory category)
        {
            await _dbContext.ArticleCategories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category.Id;
        }
    }
}
