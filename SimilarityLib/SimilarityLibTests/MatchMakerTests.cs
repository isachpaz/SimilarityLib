using System;
using NUnit.Framework;
using SimilarityLib;

namespace SimilarityLibTests
{
    [TestFixture]
    public class MatchMakerTests
    {
        [Test]
        public void Similarity_Two_Equal_Strings_Test()
        {
            var similarityIndex = MatchMaker.CalculateSimilarityTwoStrings("medical innovation", "medical innovation");
            Assert.AreEqual(1, similarityIndex);
        }


        [Test]
        public void Similarity_Two_Semi_Equal_Strings_Test()
        {
            var similarityIndex = MatchMaker.CalculateSimilarityTwoStrings("medical innovation", "medical");
            Assert.AreEqual(0.3889, Math.Round(similarityIndex, 4));
        }

        [Test]
        public void Similarity_Two_Strings_with_Typing_Error_Test()
        {
            var similarityIndex = MatchMaker.CalculateSimilarityTwoStrings("medical", "medicla");
            Assert.AreEqual(0.7143, Math.Round(similarityIndex, 4));
        }

        [Test]
        public void Similarity_Two_Strings_Test()
        {
            var similarityIndex = MatchMaker.CalculateSimilarityTwoStrings("medical innovation", "and technology");
            Assert.AreEqual(0.1667, Math.Round(similarityIndex, 4));
        }
    }
}
