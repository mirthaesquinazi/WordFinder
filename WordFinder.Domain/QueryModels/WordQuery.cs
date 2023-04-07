
namespace WordFinder.Domian.QueryModels
{
    public class WordQuery
    {
        public WordQuery(IEnumerable<string> matrix, IEnumerable<string> stream)
        {
            Matrix = matrix;
            Stream = stream;
        }

        public IEnumerable<string> Matrix { get; set; }   

        public IEnumerable<string> Stream { get; set; }
    }
}
