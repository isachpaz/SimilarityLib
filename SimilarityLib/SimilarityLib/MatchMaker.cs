using System;

namespace SimilarityLib
{
    public class MatchMaker
    {
        /// <summary>
        /// Implementation based on http://people.cs.pitt.edu/~kirk/cs1501/Pruhs/Spring2006/assignments/editdistance/Levenshtein%20Distance.htm
        /// </summary>
        /// <param name="source">string-1</param>
        /// <param name="target">string-2</param>
        /// <returns></returns>
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if (source == null || target == null){return 0;}
            if (source.Length == 0 || target.Length == 0){return 0;}
            if (source == target) {return source.Length;}

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculates the similarity index of two strings: source, and target.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>double value from 0.0 to 1.0.</returns>
        public static double CalculateSimilarityTwoStrings(string source, string target)
        {
            if (source == null || target == null){return 0.0;}
            if (source.Length == 0 || target.Length == 0) {return 0.0;}
            if (source == target) {return 1.0;}

            var levenshteinDistance = ComputeLevenshteinDistance(source, target);
            return 1.0 - (double) levenshteinDistance / (double) Math.Max(source.Length, target.Length);
        }
    }
}