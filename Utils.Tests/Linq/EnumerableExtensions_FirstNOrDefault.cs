using System;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.FirstN.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_FirstNOrDefault
    {
        [Test]
        [TestCase(new [] { 1, 2 })]
        [TestCase(new [] { 1, 2, 3 })]
        public void First2OrDefault_returns_two_values(int[] array)
        {
            var (a, b) = array.First2OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
        }
        
        [Test]
        public void First2OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b) = new [] { 1 }.First2OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3 })]
        [TestCase(new [] { 1, 2, 3, 4 })]
        public void First3OrDefault_returns_three_values(int[] array)
        {
            var (a, b, c) = array.First3OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
        }
        
        [Test]
        public void First3OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b, c) = new [] { 1 }.First3OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
            Assert.That(c, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4 })]
        [TestCase(new [] { 1, 2, 3, 4, 5 })]
        public void First4OrDefault_returns_four_values(int[] array)
        {
            var (a, b, c, d) = array.First4OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
        }
        
        [Test]
        public void First4OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b, c, d) = new [] { 1 }.First4OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
            Assert.That(c, Is.EqualTo(0));
            Assert.That(d, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6 })]
        public void First5OrDefault_returns_five_values(int[] array)
        {
            var (a, b, c, d, e) = array.First5OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
        }
        
        [Test]
        public void First5OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b, c, d, e) = new [] { 1 }.First5OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
            Assert.That(c, Is.EqualTo(0));
            Assert.That(d, Is.EqualTo(0));
            Assert.That(e, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7 })]
        public void First6OrDefault_returns_six_values(int[] array)
        {
            var (a, b, c, d, e, f) = array.First6OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
            Assert.That(f, Is.EqualTo(6));
        }
        
        [Test]
        public void First6OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b, c, d, e, f) = new [] { 1 }.First6OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
            Assert.That(c, Is.EqualTo(0));
            Assert.That(d, Is.EqualTo(0));
            Assert.That(e, Is.EqualTo(0));
            Assert.That(f, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new [] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void First7OrDefault_returns_seven_values(int[] array)
        {
            var (a, b, c, d, e, f, g) = array.First7OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(3));
            Assert.That(d, Is.EqualTo(4));
            Assert.That(e, Is.EqualTo(5));
            Assert.That(f, Is.EqualTo(6));
            Assert.That(g, Is.EqualTo(7));
        }
        
        [Test]
        public void First7OrDefault_returns_default_for_smaller_arrays()
        {
            var (a, b, c, d, e, f, g) = new [] { 1 }.First7OrDefault();
            Assert.That(a, Is.EqualTo(1));
            Assert.That(b, Is.EqualTo(0));
            Assert.That(c, Is.EqualTo(0));
            Assert.That(d, Is.EqualTo(0));
            Assert.That(e, Is.EqualTo(0));
            Assert.That(f, Is.EqualTo(0));
            Assert.That(g, Is.EqualTo(0));
        }
    }
}