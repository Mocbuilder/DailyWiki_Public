using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using DailyWiki_Local_ProofOfConcept;

namespace DailyWiki_Local_ProofOfConcept.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        private readonly IrticleLogEntry _articleLogService;

        public IrticleLogEntry ArticleLogService => _articleLogService;

        public PrivacyModel(IrticleLogEntry articleLogService, ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _articleLogService = articleLogService;
        }
    }

}
