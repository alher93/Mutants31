using Mutants31.Model;
using Mutants31.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutants31.Tests
{
    public static class TestData
    {
        public static Mutant _isMutant
        {
            get
            {
                return new Mutant
                {
                    dna = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" }
                };
            }
        }

        public static Mutant _isNotMutant
        {
            get
            {
                return new Mutant
                {
                    dna = new string[] { "ATGCAA", "CTGTCA", "TTATGT", "AGAACT", "CCTTGC", "TCACTG" }
                };
            }
        }

        public static List<Mutant> _mutants
        {
            get
            {
                return new List<Mutant>()
                {
                    new Mutant() { IsMutant = true },
                    new Mutant() { IsMutant = true },
                    new Mutant() { IsMutant = true },
                    new Mutant() { IsMutant = false },
                    new Mutant() { IsMutant = false },
                    new Mutant() { IsMutant = false },
                    new Mutant() { IsMutant = false },
                    new Mutant() { IsMutant = false },
                    new Mutant() { IsMutant = false }
                };
            }
        }

        public static MutantStats _statsResult
        {
            get
            {
                return new MutantStats
                {
                    count_human_dna = 6,
                    count_mutant_dna = 3,
                    ratio = (decimal)0.5
                };
            }
        }

        public static MutantStats _statsResultIsZero
        {
            get
            {
                return new MutantStats
                {
                    count_human_dna = 0,
                    count_mutant_dna = 0,
                    ratio = 0
                };
            }
        }
    }
}
