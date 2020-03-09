using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OData.ArticleManager
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticles();
    }
}
