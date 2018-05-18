using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for random-based methods in EnumerableExtensions.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_Random
    {
        [Test]
        public void Shuffle_shuffles_array()
        {
            var src = Enumerable.Range(1, 100).ToList();

            Tools.TestRandomized(() =>
            {
                var result = src.Shuffle().ToList();
                return result.SequenceEqual(src) == false
                       && result.OrderBy(x => x).SequenceEqual(src) == true;
            });
        }

        [Test]
        public void PickRandom_picks_elements()
        {
            var src = Enumerable.Range(1, 100).ToList();

            Tools.TestRandomized(() =>
            {
                var a = src.PickRandom();
                var b = src.PickRandom();
                return src.Contains(a)
                       && src.Contains(b)
                       && a != b;
            });
        }
    }
}
