using WordFinder.Domian.QueryModels;
using WordFinder.Domian.Services;
using WordFinder.Infrastructure.Services;
using WordFinder.UnitTests.Builders;

namespace WordFinder.UnitTests.Services
{
    public class WordServiceTests 
    {
        private readonly WordQuery query;
        private readonly IWordService _service;

        public WordServiceTests()
        {
            query = WordQueryBuilder.BuildInstance();
            _service = new WordService();
        }

        #region Find

        [Fact]
        public async Task Find_With_ValidExample_ReturnOk()
        {
            //Arrange
            var matrix = SharedValues.Matrix_ValidExample;
            var stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(matrix, stream);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task Find_With_ValidComplexExample_ReturnOk()
        {
            //Arrange
            var matrix = SharedValues.Matrix_ValidComplexExample;
            var stream = SharedValues.Stream_ValidComplexExample;

            //Act
            var result = await _service.Find(matrix, stream);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }

        [Fact]
        public async Task Find_With_EmptyMatrix_ReturnEmptySetOfStrings()
        {
            //Arrange
            query.Stream = Enumerable.Empty<string>();

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Find_With_EmptyStream_ReturnEmptySetOfStrings()
        {
            //Arrange
            query.Stream = Enumerable.Empty<string>();

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Find_With_MatrixWithRepeteadRow_ReturnOk()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_WithRepeteadRow;
            query.Stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task Find_With_StreamWithRepeteadWord_ReturnOnlyOnceInResult()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_ValidExample;
            query.Stream = SharedValues.Stream_WithRepeteadWord;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotEmpty(result);
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task Find_With_MatrixWithRepeteadColumn_ReturnOk()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_WithRepeteadColumn;
            query.Stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task Find_With_MatrixWith1WordHorizontallyFromRigthToLeft_ReturnOk()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_With1WordHorizontallyFromRigthToLeft;
            query.Stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task Find_With_MatrixWith1WordVerticallyFromBottomToTop_ReturnOk()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_With1WordVerticallyFromBottomToTop;
            query.Stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task Find_With_MatrixWith1WordCrossOver_ReturnOk()
        {
            //Arrange
            query.Matrix = SharedValues.Matrix_With1WordCrossOver;
            query.Stream = SharedValues.Stream_ValidExample;

            //Act
            var result = await _service.Find(query.Matrix, query.Stream);

            //Act and Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 1);
        }

        #endregion


        #region SearchForWords

        [Fact]
        public void SearchForWords_With_ValidValues_ReturnOk()
        {
            //Arrange
            var rowOrColumn = query.Stream.First();

            var foundWordCounts = new Dictionary<string, int>();

            //Act
            _service.SearchForWords(rowOrColumn, query.Stream, foundWordCounts);

            //Assert
            Assert.NotEmpty(foundWordCounts);
            Assert.True(foundWordCounts.Count == 1);
        }

        [Fact]
        public void SearchForWords_With_InvalidValues_ReturnNoProblems()
        {
            //Arrange
            var rowOrColumn = "z";
            var foundWordCounts = new Dictionary<string, int>();

            //Act
            _service.SearchForWords(rowOrColumn, query.Stream, foundWordCounts);

            //Act and Assert
            Assert.Empty(foundWordCounts);
        }

        [Fact]
        public void SearchForWords_With_WordMoreLongerThanRow_ReturnOk()
        {
            //Arrange

            var rowOrColumn = TestsHelper.GenerateRandomString(10);
            var stream = new string[] { rowOrColumn + "extra" };

            var foundWordCounts = new Dictionary<string, int>();

            //Act
            _service.SearchForWords(rowOrColumn, stream, foundWordCounts);

            //Assert
            Assert.Empty(foundWordCounts);
            Assert.True(foundWordCounts.Count == 0);
        }

        [Fact]
        public void SearchForWords_With_Word2RepteadWords_ReturnOk()
        {
            //Arrange

            var rowOrColumn = TestsHelper.GenerateRandomString(10);
            var stream = new string[] { rowOrColumn, rowOrColumn };

            var foundWordCounts = new Dictionary<string, int>();

            //Act
            _service.SearchForWords(rowOrColumn, stream, foundWordCounts);

            //Assert
            Assert.NotEmpty(foundWordCounts);
            Assert.True(foundWordCounts.Count == 1);
        }

        [Fact]
        public void SearchForWords_With_FoundWordWithData_ReturnOk()
        {
            //Arrange

            var rowOrColumn = TestsHelper.GenerateRandomString(10);
            var stream = new string[] { rowOrColumn, rowOrColumn };

            var foundWordCounts = new Dictionary<string, int>
            {
                { rowOrColumn, 1 }
            };

            //Act
            _service.SearchForWords(rowOrColumn, stream, foundWordCounts);

            //Assert
            Assert.NotEmpty(foundWordCounts);
            Assert.True(foundWordCounts.GetValueOrDefault(rowOrColumn) == 3);
        }

        #endregion

    }
}