using Mutants31.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mutants31.Model
{
    [ExcludeFromCodeCoverage]
    public class Mutant : IValidatableObject
    {
        public Guid Id { get; set; }
        [Required]
        [NotMapped]
        public string[] dna { get; set; }
        public bool IsMutant { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;
        public string dnaSecuence { get; set; }

        public void SetDnaSecuence()
        {
            dnaSecuence = string.Join(",", dna);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!MutantsValidations.DNAHasOnlyValidCharacters(dna))
                yield return GetValidation("The DNA table should only have these letters: (A,T,C,G)");
            if (!MutantsValidations.IsDNAOrderNxNValidation(dna))
                yield return GetValidation("The DNA table doesn't have NxN order");
            if (!MutantsValidations.IsGreaterThanFour(dna))
                yield return GetValidation("All the rows and columns of the DNA table must be greater than four");
        }

        private ValidationResult GetValidation(string errorMessage)
        {
            return new ValidationResult(errorMessage, new string[] { nameof(dna) });
        }
    }
}
