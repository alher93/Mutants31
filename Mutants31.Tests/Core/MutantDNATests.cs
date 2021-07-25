using Mutants31.Core;
using NUnit.Framework;

namespace Mutants31.Tests.Core
{
    [TestFixture]
    public class MutantDNATests
    {
        [Test]
        [TestCase(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" }, true)]
        [TestCase(new string[] { "AtgCGA", "CAGTGC", "TTatGT", "agAAGG", "CccCTA", "TCACTG" }, true)]
        [TestCase(new string[] { "ATGCAA", "CTGTCA", "TTATGT", "AGAACT", "CCTTGC", "TCACTG" }, false)]
        [TestCase(new string[] { "ACTA", "GACA", "TGAA", "AAAA" }, true)]
        [TestCase(new string[] { "ACTA", "GACA", "ATCG", "ACAA" }, false)]
        [TestCase(new string[] { "ATGAAAA", "CTGTCAG", "TTATGTG", "AGAGCTG", "CCTTGCG", "TCACTGT", "CCCCTTG" }, true)]
        [TestCase(new string[] { "ATGACAA", "CTGTCAC", "TTATGTG", "AGACCTG", "CCTTGCT", "TCACTGT", "CCACTTG" }, false)]
        public void IsMutant_WhenCalled_ReturnsCorrectBool(string[] dna, bool expectedResult)
        {
            //Arrange
            MutantDNA mutantDNA = new MutantDNA();

            //Act
            var result = mutantDNA.IsMutantDNA(dna);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
