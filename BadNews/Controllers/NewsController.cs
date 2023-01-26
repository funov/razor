using System;
using BadNews.ModelBuilders.News;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsModelBuilder newsModelBuilder;

        public NewsController(INewsModelBuilder newsModelBuilder)
        {
            this.newsModelBuilder = newsModelBuilder;
        }

        public IActionResult Index(int pageIndex = 0)
        {
            var indexModel = newsModelBuilder.BuildIndexModel(pageIndex, true, null);
            return View(indexModel);
        }

        public IActionResult FullArticle(Guid id)
        {
            var indexModel = newsModelBuilder.BuildFullArticleModel(id);

            if (indexModel == null)
                return NotFound();
            
            return View(indexModel);
        }
    }
}