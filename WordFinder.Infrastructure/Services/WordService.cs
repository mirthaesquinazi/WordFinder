using WordFinder.Domian.Services;

namespace WordFinder.Infrastructure.Services
{
    public class WordService : IWordService
    {
        public async Task<IEnumerable<string>> Find(IEnumerable<string> matrix,IEnumerable<string> stream)
        {
            //Remove repetead words in steam to avoid seach it twice and because :
            //If any word in the stream is found more than once within the stream, the search results should count it only once

            IEnumerable<string> cleanStream = stream.Distinct();
                      
            var foundWordCounts = new Dictionary<string, int>();

            var columns = new List<string>();

            // Search for words horizontally
            foreach (string row in matrix)
            {
                SearchForWords(row,cleanStream, foundWordCounts);
            }

            // Search for words vertically
            for (int i = 0; i < matrix.ElementAt(0).Length; i++)
            {
                string column = string.Empty;

                for (int j = 0; j < matrix.Count(); j++)
                {
                    column += matrix.ElementAt(j).Substring(i,1);
                }

                SearchForWords(column,cleanStream,foundWordCounts);
            }

            // Sort the words by frequency and take 10 to
            // Return the top 10 most repeated words from the word stream found in the matrix.
            var topWords = foundWordCounts.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);

            return topWords;

        }

        //We could make this method private but I include it in the interface to be able to test it separetly.
        public void SearchForWords(string rowOrColumn, IEnumerable<string> stream,  Dictionary<string, int> foundWordCounts)
        {
            foreach (string word in stream)
            {
                if (word.Length > rowOrColumn.Length)
                {
                    continue;
                }

                if (rowOrColumn.Contains(word))
                {
                    if (!foundWordCounts.ContainsKey(word))
                    {
                        foundWordCounts.Add(word, 1);
                        // If one word already find, it the other words are not in that row or column.
                        // Because all have the same legth, so 1 word cant contain other word.
                        break;
                    }
                    else
                    {
                        foundWordCounts[word]++;
                    }

                }
            }
        }

    }
}
