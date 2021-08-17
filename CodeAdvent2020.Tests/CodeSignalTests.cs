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

        [Fact]
        public void SwitchLightsTest1()
        {
            var input = new int[] { 1, 1, 1, 1, 1 };
            var expected = new int[] { 0, 1, 0, 1, 0 };
            Assert.Equal(expected, Logic.switchLights(input));
        }
        [Fact]
        public void SwitchLightsTest2()
        {
            var input = new int[] { 0, 0 };
            var expected = new int[] { 0, 0 };
            Assert.Equal(expected, Logic.switchLights(input));
        }
        [Fact]
        public void SwitchLightsTest3()
        {
            var input = new int[] { 1, 0, 0, 1, 0, 1, 0, 1 };
            var expected = new int[] { 1, 1, 1, 0, 0, 1, 1, 0 };
            Assert.Equal(expected, Logic.switchLights(input));
        }
        [Fact]
        public void SwitchLightsTest4()
        {
            var input = new int[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1 };
            var expected = new int[] { 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0 };
            Assert.Equal(expected, Logic.switchLights(input));
        }

        [Fact]
        public void minNumOfCoinsTest1()
        {
            var coins = new int[] { 1, 2, 10 };
            var price = 28;
            Assert.Equal(6, Logic.minimalNumberOfCoins(coins, price));
        }

        [Fact]
        public void minNumOfCoinsTest2()
        {
            var coins = new int[] { 1, 5,10,100 };
            var price = 239;
            Assert.Equal(10, Logic.minimalNumberOfCoins(coins, price));
        }


        [Fact]
        public void numOfClansTest()
        {
            Assert.Equal(4, Logic.numberOfClans(new int[] { 2, 3 }, 6));
        }

        [Theory]
        [InlineData(9,17)]
        [InlineData(9,88)]
        public void mostFrequentSum(int expected , int input)
        {
            Assert.Equal(expected, Logic.mostFrequentDigitSum(input));
        }


        [Theory]
        [InlineData(true , "sdffgfhg")]
        [InlineData(false , "sdfgfhg")]
        public void containsDuplicateLetter(bool expected , string input)
        {
            Assert.Equal(expected , CodeAdvent.Code._2015.Day5.HasAtLeastOneDuplicate(input));
        }

        [Theory]
        [InlineData(11, new int[] { 20000, 239, 10001, 999999, 10000, 20566, 29999 })]
        [InlineData(28, new int[] { 10000, 20000, 30000, 40000, 50000, 60000, 10000, 120000, 150000, 200000, 300000, 1000000, 10000000, 100000000, 10000000 })]
        [InlineData(2, new int[] { 10000 })]
        [InlineData(3, new int[] { 10000 , 1})]
        [InlineData(20, new int[] { 1000000000, 999990000, 999980000, 999970000, 999960000, 999950000, 999940000, 999930000, 999920000, 999910000 })]
        [InlineData(24, new int[] { 102382103, 21039898, 39823, 433, 30928398, 40283209, 23234, 342534, 98473483, 498398424, 9384984, 9839239 })]
        public void numbersGroupingTest(int expected, int[] input)
        {
            Assert.Equal(expected, Logic.numbersGrouping(input));
        }

        [Theory]
        [InlineData(81, "ab")]
        [InlineData(-1, "zzz")]
        [InlineData(900, "aba")]
        [InlineData(810000, "abcbbb")]
        [InlineData(961, "abc")]
        public void constructSquare(int expected , string input)
        {
            Assert.Equal(expected, Logic.constructSquare(input));
        }


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
