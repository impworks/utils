using System;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.FirstN.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_FirstN
    {
        [Test]
        public void FirstN_throws_for_smaller_arrays()
        {
            Assert.Throws<Exception>(() => new[] {1}.First2(), "Sequence contains too few elements");
            Assert.Throws<Exception>(() => new[] {1}.First3(), "Sequence contains too few elements");
            Assert.Throws<Exception>(() => new[] {1}.First4(), "Sequence contains too few elements");
            Assert.Throws<Exception>(() => new[] {1}.First5(), "Sequence contains too few elements");
            Assert.Throws<Exception>(() => new[] {1}.First6(), "Sequence contains too few elements");
            Assert.Throws<Exception>(() => new[] {1}.First7(), "Sequence contains too few elements");
        }
        
        [Test]
        [TestCase(new [] { 1, 2 })]
        [TestCase(new [] { 1, 2, 3 })]
        public void First2_returns_two_values(int[] array)
        {
            var (a, b) = array.First2();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3 })]
        [TestCase(new [] { 1, 2, 3, 4 })]
        public void First3_returns_three_values(int[] array)
        {
            var (a, b, c) = array.First3();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4 })]
        [TestCase(new [] { 1, 2, 3, 4, 5 })]
        public void First4_returns_four_values(int[] array)
        {
            var (a, b, c, d) = array.First4();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6 })]
        public void First5_returns_five_values(int[] array)
        {
            var (a, b, c, d, e) = array.First5();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7 })]
        public void First6_returns_six_values(int[] array)
        {
            var (a, b, c, d, e, f) = array.First6();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
            Assert.That(f, Is.EqualTo(6));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void First7_returns_seven_values(int[] array)
        {
            var (a, b, c, d, e, f, g) = array.First7();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
            Assert.That(f, Is.EqualTo(6));
            Assert.That(g, Is.EqualTo(7));
        }
    }
}