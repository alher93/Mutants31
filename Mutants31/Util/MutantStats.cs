using System;

namespace Mutants31.Util
{
    public class MutantStats
    {
        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public decimal ratio { get; set; }

        public decimal GetRatio()
        {
            if (count_human_dna == 0 && count_mutant_dna >= 0)
                return count_mutant_dna;

            return Math.Round((Convert.ToDecimal(count_mutant_dna) / Convert.ToDecimal(count_human_dna)), 2);
        }
    }
}
