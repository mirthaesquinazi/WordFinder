namespace WordFinder.Domian.Services
{
    public interface IWordService
    {
        Task<IEnumerable<string>> Find(IEnumerable<string> matrix, IEnumerable<string> stream);

        void SearchForWords(string rowOrColumn, IEnumerable<string> stream, Dictionary<string, int> foundWordCounts);
    }
}
