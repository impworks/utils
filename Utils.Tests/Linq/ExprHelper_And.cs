using System.Collections.Generic;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for ExprHelper.And method.
    /// </summary>
    [TestFixture]
    public class ExprHelper_And
    {
        private static IEnumerable<(SampleObject, bool)>AndTestCases()
        {
            yield return (new SampleObject { Value = 1, Str = "foo" }, true);
            yield return (new SampleObject { Value = 1, Str = "foo2" }, false);
            yield return (new SampleObject { Value = 2, Str = "foo" }, false);
            yield return (new SampleObject { Value = 1, Str = "foo", Field = "foo" }, true);
            yield return (new SampleObject { Value = 1, Str = "foo", Field = "x" }, false);
        }

        [Test]
        [TestCaseSource(typeof(ExprHelper_And), nameof(AndTestCases))]
        public void Expression_compiles((SampleObject obj, bool result) arg)
        {
            var pred = ExprHelper.And<SampleObject>(
                x => x.Value == 1,
                x => x.Str == "foo",
                x => x.Field == null || x.Field.Length > 2
            ).Compile();

            Assert.That(pred(arg.obj), Is.EqualTo(arg.result));
        }
    }
}
