using System.Collections.Generic;
using DailyWiki_Local_ProofOfConcept;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace DailyWiki_Local_ProofOfConcept
{
    public class rticleLogEntry
    {
        public string Title;
        public string Link;
        public List<rticleLogEntry> ArticleLog { get; } = new List<rticleLogEntry>();

        public void AddArticleLogEntry(rticleLogEntry entry)
        {
            ArticleLog.Add(entry);
        }
    }
}
