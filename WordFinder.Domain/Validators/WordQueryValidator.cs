using FluentValidation;
using System.ComponentModel;
using WordFinder.Domian.QueryModels;

namespace WordFinder.Domian.Validators
{
    public class WordQueryValidator : AbstractValidator<WordQuery>
    {
        public WordQueryValidator()
        {
            //The matrix size does not exceed 64x64

            // OverridePropertyName("Matrix") is necesary because we use special funtions, then property name is Override by default to ""

            RuleFor(x => x.Matrix.Any(y => y.Length > 64)).NotEqual(true).OverridePropertyName("Matrix")
                        .WithMessage("The Matrix size does not have to exceed 64 characters horizontally");


            RuleFor(x => x.Matrix.Count()).LessThan(64).OverridePropertyName("Matrix")
                        .WithMessage("The Matrix size does not have to exceed 64 characters vertically");


            RuleFor(d => d.Matrix).Must(ValidateStringLengths)
                      .WithMessage("All strings in the Matrix must contain the same number of characters");
        }


        private static bool ValidateStringLengths(IEnumerable<string> matrix)
        {
            bool sameLength = true;
            if (matrix.Any())
            {
                int i = 0;

                while (sameLength && matrix.Count() > i + 1)
                {
                    if (matrix.ElementAt(i).Length != matrix.ElementAt(i + 1).Length)
                    {
                        sameLength = false;
                    }
                    i++;
                }

                //Check last one
                if (i + 1 > matrix.Count() && matrix.ElementAt(i).Length != matrix.ElementAt(i - 1).Length)
                {
                    sameLength = false;
                }

            }
            return sameLength;

        }

    }
}
