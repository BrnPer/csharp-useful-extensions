using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpExtensions.Tests
{
    public class DictionaryExtensions
    {

        [Fact]
        public void DictionaryExtensionAddWithOptionsAddDiferentKeys()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddWithOptions("123", "123", DictionaryOptions.DontOverwrite);
            dict.AddWithOptions("456", "456", DictionaryOptions.DontOverwrite);

            Assert.True(2 == dict.Count);
        }

        [Fact]
        public void DictionaryExtensionAddWithOptionsDontOverwrite()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var dictKey = "123";
            dict.AddWithOptions(dictKey, "123", DictionaryOptions.DontOverwrite);
            dict.AddWithOptions(dictKey, "456", DictionaryOptions.DontOverwrite);

            Assert.True(1 == dict.Count);
            Assert.Equal("123", dict[dictKey]);
        }

        [Fact]
        public void DictionaryExtensionAddWithOptionsOverwrite()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var dictKey = "123";
            dict.AddWithOptions(dictKey, "123", DictionaryOptions.Overwrite);
            dict.AddWithOptions(dictKey, "456", DictionaryOptions.Overwrite);

            Assert.True(1 == dict.Count);
            Assert.Equal("456", dict[dictKey]);
        }

        [Fact]
        public void DictionaryExtensionAddWithOptionsAppendToValues()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var dictKey = "123";
            dict.AddWithOptions(dictKey, "123", DictionaryOptions.AppendToValue);
            dict.AddWithOptions(dictKey, "456", DictionaryOptions.AppendToValue);
            dict.AddWithOptions(dictKey, "789", DictionaryOptions.AppendToValue);

            Assert.True(1 == dict.Count);
            Assert.Equal("123456789", dict[dictKey]);
        }
    }
}
