﻿using OData.ArticleManager;
using OData.DataAccess.Repository.Interfaces;
using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OData.ArticleManager
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _articleRepository.GetAll();
        }
    }
}
