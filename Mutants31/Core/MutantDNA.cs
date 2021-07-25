using System;
using System.Collections.Generic;
using System.Linq;

namespace Mutants31.Core
{
    public class MutantDNA
    {
        private const int _minSecuence = 4;

        public bool IsMutantDNA(string[] dna)
        {
            string[] verticalDNA = VerticalDNA(dna);
            string[] oblicuosDNA = OblicuosDNA(dna, verticalDNA);

            int horizontalSecuences = AmountOfSecuences(dna);
            int verticalSecuences = AmountOfSecuences(verticalDNA);
            int oblicuosSecuences = AmountOfSecuences(oblicuosDNA);

            return (horizontalSecuences + verticalSecuences + oblicuosSecuences) > 1;
        }

        private string[] VerticalDNA(string[] dna)
        {
            string[] verticalDNA = new string[dna.Length];

            for (int i = 0; i <= dna.Length - 1; i++)
            {
                string verticalSecuence = "";

                foreach (string secuence in dna)
                    verticalSecuence += secuence[i];

                verticalDNA[i] = verticalSecuence;
            }

            return verticalDNA;
        }

        private string[] OblicuosDNA(string[] dna, string[] verticalDNA)
        {
            List<string> superiorTriangle = GetTriangle(0, new List<string>(dna));
            List<string> inferiorTriangle = GetTriangle(1, new List<string>(verticalDNA));

            superiorTriangle.AddRange(inferiorTriangle);

            return superiorTriangle.ToArray();
        }

        private List<string> GetTriangle(int start, List<string> listDNA)
        {
            int iterations = listDNA.Count - _minSecuence;
            List<string> triangle = new List<string>();

            for (int i = start; i <= iterations; i++)
            {
                string oblicuosSecuence = "";
                int k = i;

                if (i != 0)
                    listDNA.RemoveAt(listDNA.Count - 1);

                for (int j = 0; j < listDNA.Count; j++)
                {
                    oblicuosSecuence += listDNA[j][k];
                    k++;
                }

                triangle.Add(oblicuosSecuence);
            }

            return triangle;
        }

        private int AmountOfSecuences(string[] dna)
        {
            int amountOfSecuences = 0;

            foreach (string secuence in dna)
            {
                int iterations = secuence.Length - _minSecuence;

                for (int i = 0; i <= iterations; i++)
                    amountOfSecuences += Convert.ToInt32((IsSecuence(secuence.Substring(i, _minSecuence))));
            }

            return amountOfSecuences;
        }

        private bool IsSecuence(string secuence)
        {
            string first = secuence[0].ToString();
            return !secuence.Any(c => !c.ToString().Equals(first, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
