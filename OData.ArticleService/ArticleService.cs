using OData.ArticleManager;
using OData.ArticleManager.ViewModels;
using OData.DataAccess.Repository.Interfaces;
using OData.Models;
using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OData.ArticleManager
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<AllArticlesViewModel> GetAllArticles()
        {
            var result = new AllArticlesViewModel();
            var articles = await _articleRepository.GetAll();
            result.Articles = articles
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title,
                    Category = new ArticleCategory() { Id = x.Category.Id, Name = x.Category.Name }
                }).ToList();
            return result;
        }

        public async Task<ArticleViewModel> GetArticle(int id)
        {
            var article = await _articleRepository.Get(id);
            var result = new ArticleViewModel()
            {
                Id = article.Id,
                Content = article.Content,
                Title = article.Title,
                Category = article.Category
            };

            return result;
        }
    }
}
