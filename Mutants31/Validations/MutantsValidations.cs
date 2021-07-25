using System;
using System.Linq;

namespace Mutants31.Validations
{
    public static class MutantsValidations
    {
        public const string _validCharacters = "ATCG";

        public static bool IsDNAOrderNxNValidation(string[] dna)
        {
            return !dna.Any(s => s.Length != dna.Length);
        }

        public static bool DNAHasOnlyValidCharacters(string[] dna)
        {
            foreach (string secuence in dna)
            {
                if (secuence.Any(c => !_validCharacters.Contains(c, StringComparison.InvariantCultureIgnoreCase)))
                    return false;
            }

            return true;
        }

        public static bool IsGreaterThanFour(string[] dna)
        {
            return dna.Length >= 4 && !dna.Any(s => s.Length < 4);
        }
    }
}
