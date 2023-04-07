using WordFinder.Domian.QueryModels;
using WordFinder.Domian.Validators;
using WordFinder.UnitTests.Builders;
using WordFinder.UnitTests.Common;

namespace WordFinder.UnitTests.Validators
{
    public class WordQueryValidatorTests : ValidatorTestsBase
    {
        private readonly WordQuery _wordQuery;
        private readonly WordQueryValidator _validator;

        public WordQueryValidatorTests()
        {
            _wordQuery = WordQueryBuilder.BuildInstance();
            _validator = new WordQueryValidator();
        }

        [Fact]
        public async Task Validate_ValidEntity_ReturnsNoErrors()
        {
            //Arrange
            //All the properties have been set with valid values in the Builder.

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        #region Validate Matrix

        [Fact]
        public async Task Validate_MatrixWithValidFormat_ReturnsOk()
        {
            //Arrange
            _wordQuery.Matrix = SharedValues.Matrix_ValidExample;

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        [Fact]
        public async Task Validate_Matrix_Empty_ReturnsNoError()
        {
            //Arrange
            _wordQuery.Matrix = Enumerable.Empty<string>();

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        [Fact]
        public async Task Validate_Stream_Empty_ReturnsNoError()
        {
            //Arrange
            _wordQuery.Stream = Enumerable.Empty<string>();

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Ok(fluentValidationResult);
        }

        [Fact]
        public async Task Validate_Matrix_WithMoreThan64CharHorizontally_ReturnsError()
        {
            //Arrange
            _wordQuery.Matrix = new string[]
            {
                TestsHelper.GenerateRandomString(65)
            };

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Error(fluentValidationResult, nameof(_wordQuery.Matrix));
        }

        [Fact]
        public async Task Validate_Matrix_WithMoreThan64CharVertically_ReturnsError()
        {
            //Arrange
            _wordQuery.Matrix = new string[]
            {
                "o",// 1 
                "o",// 2
                "o",// 3
                "o",// 4
                "o",// 5
                "o",// 6
                "o",// 7
                "o",// 8
                "o",// 9
                "o",// 10
                "o",// 11 
                "o",// 12
                "o",// 13
                "o",// 14
                "o",// 15
                "o",// 16
                "o",// 17
                "o",// 18
                "o",// 19
                "o",// 20
                "o",// 21 
                "o",// 22
                "o",// 23
                "o",// 24
                "o",// 25
                "o",// 26
                "o",// 27
                "o",// 28
                "o",// 29
                "o",// 30
                "o",// 31 
                "o",// 32
                "o",// 33
                "o",// 34
                "o",// 35
                "o",// 36
                "o",// 37
                "o",// 38
                "o",// 39
                "o",// 40
                "o",// 41 
                "o",// 42
                "o",// 43
                "o",// 44
                "o",// 45
                "o",// 46
                "o",// 47
                "o",// 48
                "o",// 49
                "o",// 50
                "o",// 51 
                "o",// 52
                "o",// 53
                "o",// 54
                "o",// 55
                "o",// 56
                "o",// 57
                "o",// 58
                "o",// 59
                "o",// 60
                "o",// 61 
                "o",// 62
                "o",// 63
                "o",// 64
                "o"// 65
            };

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Error(fluentValidationResult, nameof(_wordQuery.Matrix));
        }

        [Fact]
        public async Task Validate_Matrix_WithFirstStringWithInvalidLengths_ReturnsError()
        {
            //Arrange
            _wordQuery.Matrix = new string[]
             {
                TestsHelper.GenerateRandomString(1),
                TestsHelper.GenerateRandomString(2),
                TestsHelper.GenerateRandomString(2)
             };

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Error(fluentValidationResult, nameof(_wordQuery.Matrix));
        }

        [Fact]
        public async Task Validate_Matrix_WithLastStringWithInvalidLengths_ReturnsError()
        {
            //Arrange
            _wordQuery.Matrix = new string[]
            {
                TestsHelper.GenerateRandomString(2),
                TestsHelper.GenerateRandomString(2),
                TestsHelper.GenerateRandomString(1)
            };

            //Act
            var fluentValidationResult = await _validator.ValidateAsync(_wordQuery);

            //Assert
            Validate_Error(fluentValidationResult, nameof(_wordQuery.Matrix));
        }

        #endregion
    }
}

