using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodeAdvent2020.Code.CodeSignal;

namespace CodeAdvent2020.Tests
{
    public class CodeSignalTests
    {

        [Theory]
        [InlineData(true, "aacb", "aabc")]
        [InlineData(false, "aa", "bc")]
        [InlineData(true, "aaxxaaz", "aazzaay")]
        [InlineData(true, "aabc", "aacb")]
        [InlineData(false, "aaxyaa", "aazzaa")]
        public void substitutionCipher(bool expected , string s1 , string s2)
        {
            Assert.Equal(expected, Logic.isSubstitutionCipher(s1, s2));
        }



        [Theory]
        [InlineData(true , "aa" , "AAB")]
        [InlineData(true , "mehOu", "mehau")]
        [InlineData(true , "aaad", "aaAdd")]
        [InlineData(false, "123za", "123Z")]
        public void UnstablePairTests(bool expexted , string f1 , string f2)
        {
            Assert.Equal(expexted, Logic.isUnstablePair(f1, f2));
        }



        [Theory]
        [InlineData(5,2,9)]
        [InlineData(1,2,1)]
        public void candlesTest(int candlesCount , int newMake , int expected)
        {
            Assert.Equal(expected, Code.CodeSignal.Logic.candles(candlesCount, newMake));
        }

        [Theory]
        [InlineData(6, "crossword","square","formation","something")]
        [InlineData(0, "anaesthetist","thatch","ethnics","sabulous")]
        [InlineData(4, "eternal","texas","chainsaw","massacre")]
        public void crossWordFormation(int expected , string w1 , string w2, string w3, string w4 )
        {
            string[] words = new string[] { w1, w2, w3, w4 };
            Assert.Equal(expected, Logic.crosswordFormation(words));
        }
    }
}
