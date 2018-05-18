using System;
using System.Collections.Generic;
using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StringExtensions.Parse.
    /// </summary>
    [TestFixture]
    public class StringExtensions_Parse
    {
        private static IEnumerable<object> ParseTestCases()
        {
            yield return Tuple.Create("123", (int)123);
            yield return Tuple.Create("123", (uint)123);
            yield return Tuple.Create("123", (long)123);
            yield return Tuple.Create("123", (ulong)123);
            yield return Tuple.Create("123", (byte)123);
            yield return Tuple.Create("123", (sbyte)123);
            yield return Tuple.Create("123", (decimal)123);
            yield return Tuple.Create("1.2", (double)1.2);
            yield return Tuple.Create("1.2", (float)1.2);
            yield return Tuple.Create("1.23", (decimal)1.23);

            yield return Tuple.Create("x", 'x');

            yield return Tuple.Create("2018-05-18", new DateTime(2018, 05, 18));
            yield return Tuple.Create("2018-05-18 12:34:56", new DateTime(2018, 05, 18, 12, 34, 56));
            yield return Tuple.Create("2018-05-18", new DateTimeOffset(new DateTime(2018, 05, 18)));

            yield return Tuple.Create("123", (int?)123);
            yield return Tuple.Create("123", (uint?)123);
            yield return Tuple.Create("123", (long?)123);
            yield return Tuple.Create("123", (ulong?)123);
            yield return Tuple.Create("123", (byte?)123);
            yield return Tuple.Create("123", (sbyte?)123);
            yield return Tuple.Create("123", (decimal?)123);
            yield return Tuple.Create("1.2", (double?)1.2);
            yield return Tuple.Create("1.2", (float?)1.2);
            yield return Tuple.Create("1.23", (decimal?)1.23);

            yield return Tuple.Create("x", (char?)'x');

            yield return Tuple.Create("2018-05-18", (DateTime?) new DateTime(2018, 05, 18));
            yield return Tuple.Create("2018-05-18 12:34:56", (DateTime?) new DateTime(2018, 05, 18, 12, 34, 56));
            yield return Tuple.Create("2018-05-18", (DateTimeOffset?) new DateTimeOffset(new DateTime(2018, 05, 18)));
        }

        [Test]
        [TestCaseSource(typeof(StringExtensions_Parse), nameof(ParseTestCases))]
        public void Parse_parses_values(dynamic tuple)
        {
            Check(tuple.Item1, tuple.Item2);
        }

        [Test]
        public void Parse_accepts_parse_function()
        {
            Assert.AreEqual(123, "1-2-3".Parse(x => int.Parse(x.Replace("-", ""))));
        }

        [Test]
        public void Parse_throws_error_on_incorrect_value()
        {
            Assert.Throws<FormatException>(() => "1-2-3".Parse<int>());
        }
        
        [Test]
        public void TryParse_accepts_parse_function()
        {
            Assert.AreEqual(123, "1-2-3".TryParse(x => int.Parse(x.Replace("-", ""))));
        }

        [Test]
        public void TryParese_returns_default_on_incorrect_value()
        {
            Assert.AreEqual(0, "1-2-3".TryParse<int>());
            Assert.AreEqual(null, "1-2-3".TryParse<int?>());
        }

        void Check<T>(string src, T result)
        {
            Assert.AreEqual(result, src.Parse<T>());
        }
    }
}
