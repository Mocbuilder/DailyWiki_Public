using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using DailyWiki_Local_ProofOfConcept;

namespace DailyWiki_Local_ProofOfConcept.Pages
{
    public class PrivacyModel : PageModel
    {
        public List<rticleLogEntry> ArticleLog { get; set; }

        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var scraper = new WikiScraper();
            scraper.Scrape();

            var articleLogEntry = new rticleLogEntry
            {
                Title = scraper.PageTitle,
                Link = scraper.ArticleLink
            };

            ArticleLog.Add(articleLogEntry);
        }
    }

}
