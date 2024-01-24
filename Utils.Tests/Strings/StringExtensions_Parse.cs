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
            yield return ("123", 123);
            yield return ("123", (uint)123);
            yield return ("123", (long)123);
            yield return ("123", (ulong)123);
            yield return ("123", (byte)123);
            yield return ("123", (sbyte)123);
            yield return ("123", (decimal)123);
            yield return ("1.2", 1.2);
            yield return ("1.2", (float)1.2);
            yield return ("1.23", (decimal)1.23);

            yield return ("true", true);
            yield return ("false", false);
            yield return ("TRUE", true);
            yield return ("FALSE", false);
            yield return ("x", 'x');

            yield return ("2018-05-18", new DateTime(2018, 05, 18));
            yield return ("2018-05-18 12:34:56", new DateTime(2018, 05, 18, 12, 34, 56));
            yield return ("2018-05-18", new DateTimeOffset(new DateTime(2018, 05, 18)));

            yield return ("90b3a536-da16-4238-b781-cee864a9ec00", new Guid("90b3a536-da16-4238-b781-cee864a9ec00"));

            yield return ("1", SampleEnum.Foo);
            yield return ("Bar", SampleEnum.Bar);
            yield return ("bar", SampleEnum.Bar);

            yield return ("123", (int?)123);
            yield return ("123", (uint?)123);
            yield return ("123", (long?)123);
            yield return ("123", (ulong?)123);
            yield return ("123", (byte?)123);
            yield return ("123", (sbyte?)123);
            yield return ("123", (decimal?)123);
            yield return ("1.2", (double?)1.2);
            yield return ("1.2", (float?)1.2);
            yield return ("1.23", (decimal?)1.23);

            yield return ("true", (bool?)true);
            yield return ("false", (bool?) false);
            yield return ("TRUE", (bool?) true);
            yield return ("FALSE", (bool?) false);
            yield return ("x", (char?)'x');

            yield return ("2018-05-18", (DateTime?) new DateTime(2018, 05, 18));
            yield return ("2018-05-18 12:34:56", (DateTime?) new DateTime(2018, 05, 18, 12, 34, 56));
            yield return ("2018-05-18", (DateTimeOffset?) new DateTimeOffset(new DateTime(2018, 05, 18)));

            yield return ("90b3a536-da16-4238-b781-cee864a9ec00", (Guid?) new Guid("90b3a536-da16-4238-b781-cee864a9ec00"));

            yield return ("1", (SampleEnum?) SampleEnum.Foo);
            yield return ("Bar", (SampleEnum?) SampleEnum.Bar);
            yield return ("bar", (SampleEnum?) SampleEnum.Bar);

            yield return ("foo", "foo");
            yield return ("http://example.com", new Uri("http://example.com"));
            yield return ("test/foo", new Uri("test/foo", UriKind.RelativeOrAbsolute));

#if NET6_0_OR_GREATER
            yield return ("123", (Half)123);
            yield return ("123", (Half?)123);
            yield return ("2018-05-18", new DateOnly(2018, 05, 18));
            yield return ("2018-05-18", (DateOnly?) new DateOnly(2018, 05, 18));
            yield return ("16:47:23", new TimeOnly(16, 47, 23));
            yield return ("16:47:23", (TimeOnly?) new TimeOnly(16, 47, 23));
#endif
        }

        [Test]
        [TestCaseSource(typeof(StringExtensions_Parse), nameof(ParseTestCases))]
        public void Parse_parses_values(dynamic tuple)
        {
            // required for automatic generic type inference via dynamics
            Check(tuple);
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
        public void Parse_throws_error_on_null()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).Parse<int>());
        }

        [Test]
        public void TryParse_accepts_parse_function()
        {
            Assert.AreEqual(123, "1-2-3".TryParse(x => int.Parse(x.Replace("-", ""))));
        }

        [Test]
        public void TryParse_returns_default_on_incorrect_value()
        {
            Assert.AreEqual(0, "1-2-3".TryParse<int>());
            Assert.AreEqual(null, "1-2-3".TryParse<int?>());
        }

        [Test]
        public void TryParse_accepts_null()
        {
            Assert.AreEqual(0, (null as string).TryParse<int>());
            Assert.AreEqual(null, (null as string).TryParse<int?>());
        }

        [Test]
        public void TryParseList_returns_list()
        {
            Assert.AreEqual(new [] { 1, 2, 3 }, "1,2,3".TryParseList<int>());
        }
        
        [Test]
        public void TryParseList_skips_failed_entries()
        {
            Assert.AreEqual(new[] { 1, 3 }, "1,test,3".TryParseList<int>());
        }

        [Test]
        public void TryParseList_returns_empty_list_if_no_item_succeeded()
        {
            Assert.AreEqual(new int[0], "a,b,c".TryParseList<int>());
        }

        [Test]
        public void TryParseList_uses_separator()
        {
            Assert.AreEqual(new[] { 1, 2, 3 }, "1-2-3".TryParseList<int>(separator: "-"));
        }

        [Test]
        public void TryParseList_uses_parseFunc()
        {
            Assert.AreEqual(new[] { 1, 2, 3 }, "@1,@2,@3".TryParseList<int>(parseFunc: str => int.Parse(str.TrimStart('@'))));
        }

        [Test]
        public void TryParseList_accepts_null()
        {
            Assert.AreEqual(new int[0], (null as string).TryParseList<int>());
        }

        void Check<T>((string str, T obj) value)
        {
            Assert.AreEqual(value.obj, value.str.Parse<T>());
        }
    }
}
