using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Net;
using DailyWiki_Local_ProofOfConcept;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace DailyWiki_Local_ProofOfConcept
{
    public class WikiScraper
    {
        private rticleLogEntry logEntryInstance = new rticleLogEntry();

        public string PageTitle { get; private set; }
        public string CleanedText { get; private set; }
        public string ArticleLink { get; private set; }

        public void Scrape()
        {
            string apiUrl = "https://en.wikipedia.org/w/api.php";
            string action = "query";
            string format = "json";
            string list = "random";
            int numArticles = 1; // Number of random articles to retrieve

            // Build the API request URL for a random article without the intro
            string requestUrl = $"{apiUrl}?action={action}&format={format}&list={list}&rnnamespace=0&rnlimit={numArticles}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Download the JSON response
                    string json = client.DownloadString(requestUrl);

                    // Parse the JSON response
                    JObject response = JObject.Parse(json);

                    // Extract the title of the random article
                    PageTitle = response["query"]["random"][0]["title"].ToString();

                    // Get the page ID of the random article
                    string pageId = response["query"]["random"][0]["id"].ToString();

                    // Build the link to the random article
                    ArticleLink = $"https://en.wikipedia.org/wiki/{PageTitle.Replace(" ", "_")}";

                    // Fetch the content of the random article using the page ID
                    string contentRequestUrl = $"{apiUrl}?action=query&format={format}&pageids={pageId}&prop=extracts";

                    string contentJson = client.DownloadString(contentRequestUrl);

                    // Parse the content JSON response
                    JObject contentResponse = JObject.Parse(contentJson);

                    // Extract the content of the article
                    var pages = contentResponse["query"]["pages"];
                    var articleText = pages[pageId]["extract"].ToString();

                    // Clean up the article text by removing HTML tags and entities
                    CleanedText = CleanHtml(articleText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            rticleLogEntry logEntry = new rticleLogEntry
            {
                Title = PageTitle,
                Link = ArticleLink
            };
            logEntryInstance.AddArticleLogEntry(logEntry);
        }

        // Function to clean up HTML tags and entities from the text
        private static string CleanHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode.InnerText;
        }
    }
}