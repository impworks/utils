using System.Collections.Generic;
using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for ExprHelper.Or method.
    /// </summary>
    [TestFixture]
    public class ExprHelper_Or
    {
        private static IEnumerable<(SampleObject, bool)> OrTestCases()
        {
            yield return (new SampleObject { Value = 1, Str = "foo" }, true);
            yield return (new SampleObject { Value = 0, Str = "foo" }, true);
            yield return (new SampleObject { Value = 1, Str = "foo", Field = "foo" }, true);
            yield return (new SampleObject { Value = 0, Str = "x" }, false);
            yield return (new SampleObject { Value = 0, Str = "x", Field = "x" }, false);
        }

        [Test]
        [TestCaseSource(typeof(ExprHelper_Or), nameof(OrTestCases))]
        public void Expression_compiles((SampleObject obj, bool result) arg)
        {
            var pred = ExprHelper.Or<SampleObject>(
                x => x.Value == 1,
                x => x.Str == "foo",
                x => x.Field != null && x.Field.Length > 2
            ).Compile();

            Assert.That(pred(arg.obj), Is.EqualTo(arg.result));
        }

        [Test]
        public void NestedLambda_compiles()
        {
            var objs = new[]
            {
                new SampleListObject {Key = "1", Values = new[] {"a", "ab", "abc"}},
                new SampleListObject {Key = "2", Values = new[] {"ab", "abc"}},
                new SampleListObject {Key = "3", Values = new[] {"ab", "abc", "abcd"}},
                new SampleListObject {Key = "4", Values = new[] {"ab"}},
            };

            var lengths = new[] {1, 4};

            var pred = ExprHelper.Or<SampleListObject>(
                x => x.Key == "4",
                x => x.Values.Any(y => lengths.Contains(y.Length))
            ).Compile();

            Assert.That(objs.Where(pred).Select(x => x.Key).JoinString(","), Is.EqualTo("1,3,4"));
        }
    }
}
