using DailyWiki_Local_ProofOfConcept;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DailyWiki_Local_ProofOfConcept;

namespace DailyWiki_Local_ProofOfConcept.Pages
{
    public class IndexModel : PageModel
    {
        WikiScraper scraper = new WikiScraper();
        public string PageTitle { get; set; }
        public string CleanedText { get; set; }
        public string ArticleLink { get; set; }

        private readonly IrticleLogEntry _articleLogService;

        public IndexModel(IrticleLogEntry articleLogService)
        {
            _articleLogService = articleLogService;
        }

        //testcomment
        public void OnGet()
        {
            WikiScraper scraper = new WikiScraper();
            scraper.Scrape(); // Call the Scrape method on the instance

            PageTitle = scraper.PageTitle;
            CleanedText = scraper.CleanedText;
            ArticleLink = scraper.ArticleLink;

            var articleLogEntry = new rticleLogEntry
            {
                Title = scraper.PageTitle,
                Link = scraper.ArticleLink
            };

            // Add the current article to the shared article log
            _articleLogService.AddArticleLogEntry(articleLogEntry);
        }
    }
}