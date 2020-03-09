using System;
using System.Collections.Generic;
using System.Text;

namespace OData.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ArticleCategory Category { get; set; }
    }
}
