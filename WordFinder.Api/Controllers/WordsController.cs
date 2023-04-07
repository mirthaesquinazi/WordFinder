using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WordFinder.Domian.QueryModels;
using WordFinder.Domian.Services;
using WordFinder.Domian.Validators;

namespace WordFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {

        private readonly IWordService _wordService;

        public WordsController(IWordService wordServices)
        {
            _wordService = wordServices;
        }

        [HttpPost]// Despite this should be a get htpp request, we need send a body because the strins can be long, this is why it is declare as post
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetTop10MostRepeatedWords(WordQuery wordQuery)
        {
            var validator = new WordQueryValidator();
            ValidationResult fluentResult = await validator.ValidateAsync(wordQuery);

            if (!fluentResult.IsValid)
            {
                return BadRequest(fluentResult.Errors);
            }

            var topMostRepeatedWords = await _wordService.Find(wordQuery.Matrix, wordQuery.Stream);

            return Ok(topMostRepeatedWords);
        }
    }
}