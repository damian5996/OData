using OData.ArticleManager.ViewModels;
using OData.Models;
using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OData.ArticleManager
{
    public interface IArticleService
    {
        Task<AllArticlesViewModel> GetAllArticles();
        Task<ArticleViewModel> GetArticle(int id);
    }
}
