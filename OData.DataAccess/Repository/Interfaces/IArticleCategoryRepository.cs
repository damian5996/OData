﻿using OData.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OData.DataAccess.Repository.Interfaces
{
    public interface IArticleCategoryRepository
    {
        Task<List<ArticleCategory>> GetAll();
        Task<ArticleCategory> Get(int id);
        Task<int> CreateAsync(ArticleCategory category);
    }
}
