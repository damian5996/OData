using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OData.ArticleManager;
using OData.Models.Entities;

namespace OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _articleService.GetAllArticles();
        }
    }
}
