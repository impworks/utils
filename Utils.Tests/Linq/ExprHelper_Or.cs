using System.Collections.Generic;
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
        private static IEnumerable<(SampleObject, bool)> AndTestCases()
        {
            yield return (new SampleObject { Value = 1, Str = "foo" }, true);
            yield return (new SampleObject { Value = 0, Str = "foo" }, true);
            yield return (new SampleObject { Value = 1, Str = "foo", Field = "foo" }, true);
            yield return (new SampleObject { Value = 0, Str = "x" }, false);
            yield return (new SampleObject { Value = 0, Str = "x", Field = "x" }, false);
        }

        [Test]
        [TestCaseSource(typeof(ExprHelper_Or), nameof(AndTestCases))]
        public void Expression_compiles((SampleObject obj, bool result) arg)
        {
            var pred = ExprHelper.Or<SampleObject>(
                x => x.Value == 1,
                x => x.Str == "foo",
                x => x.Field != null && x.Field.Length > 2
            ).Compile();

            Assert.AreEqual(arg.result, pred(arg.obj));
        }
    }
}
