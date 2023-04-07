using WordFinder.Domian.QueryModels;

namespace WordFinder.UnitTests.Builders
{

    public class WordQueryBuilder
    {
        protected WordQueryBuilder() { }

        public static WordQuery BuildInstance()
        {
            var matrix = new string[]
            {
                TestsHelper.GenerateRandomString(1),
                TestsHelper.GenerateRandomString(1),
                TestsHelper.GenerateRandomString(1)
            };

            var stream = new string[]
            {
                TestsHelper.GenerateRandomString(1),
                TestsHelper.GenerateRandomString(1)
            };

            var defaultInstance = new WordQuery(matrix, stream);

            return defaultInstance;
        }
    }
}
