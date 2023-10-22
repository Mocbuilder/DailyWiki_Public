namespace DailyWiki_Local_ProofOfConcept
{
    public interface IrticleLogEntry
    {
        public List<rticleLogEntry> ArticleLog { get; }

        public void AddArticleLogEntry(rticleLogEntry entry);
    }
}