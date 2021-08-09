using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpExtensions.Tests
{
    public class StringExtensions
    {

        [Theory]
        [MemberData(nameof(ReplaceAllTestCases))]
        public void ReplaceAll(string initialString, List<char> oldChars, char newChar, string expectedValue)
        {
            Assert.Equal(expectedValue, initialString.ReplaceAll(oldChars, newChar));
        }


        public static IEnumerable<object[]> ReplaceAllTestCases()
        {
            List<string> initialStrings = new List<string>();
            Dictionary<int, List<char>> oldCharsDictionary = new Dictionary<int, List<char>>();
            List<char> newChars = new List<char>();
            List<string> finalStrings = new List<string>();

            initialStrings.Add("Hello how are you?");
            oldCharsDictionary.Add(0, new List<char>() { ' ', '?', 'y' });
            newChars.Add('|');
            finalStrings.Add("Hello|how|are||ou|");


            initialStrings.Add("Hello you are you?");
            oldCharsDictionary.Add(1, new List<char>() { 'H', 'e', '?' });
            newChars.Add('1');
            finalStrings.Add("11llo you ar1 you1");

            initialStrings.Add("Hello you are you?");
            oldCharsDictionary.Add(2, new List<char>() { });
            newChars.Add('1');
            finalStrings.Add("Hello you are you?");

            initialStrings.Add("!?;.");
            oldCharsDictionary.Add(3, new List<char>() {'!',';' });
            newChars.Add(' ');
            finalStrings.Add(" ? .");

            var allData = new List<object[]> {
                new object[] { initialStrings[0], oldCharsDictionary[0], newChars[0],finalStrings[0] },
                new object[] { initialStrings[1], oldCharsDictionary[1], newChars[1],finalStrings[1] },
                new object[] { initialStrings[2], oldCharsDictionary[2], newChars[2],finalStrings[2] },
                new object[] { initialStrings[3], oldCharsDictionary[3], newChars[3],finalStrings[3] },
            };

            return allData;
        }


    }
}
