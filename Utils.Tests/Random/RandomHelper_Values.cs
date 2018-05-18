using System;
using System.Linq;
using Impworks.Utils.Random;
using NUnit.Framework;

namespace Utils.Tests.Random
{
    /// <summary>
    /// Tests for RandomHelper methods.
    /// </summary>
    [TestFixture]
    public class RandomHelper_Values
    {
        [Test]
        public void Float_returns_a_random_value()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Float();
                var b = RandomHelper.Float();
                return Math.Abs(a - b) > 0.001;
            });
        }

        [Test]
        public void Float_returns_a_value_between_0_and_1()
        {
            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Float();
                return value >= 0.0 && value <= 1.0;
            });
        }

        [Test]
        public void Float_returns_a_value_between_given_values()
        {
            var min = 5;
            var max = 100;

            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Float(min, max);
                return value >= min && value <= max;
            });
        }

        [Test]
        public void Double_returns_a_random_value()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Double();
                var b = RandomHelper.Double();
                return Math.Abs(a - b) > 0.001;
            });
        }

        [Test]
        public void Double_returns_a_value_between_0_and_1()
        {
            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Double();
                return value >= 0.0 && value <= 1.0;
            });
        }

        [Test]
        public void Double_returns_a_value_between_given_values()
        {
            var min = 13;
            var max = 37;

            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Double(min, max);
                return value >= min && value <= max;
            });
        }

        [Test]
        public void Int_returns_a_random_value()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Int(1, 1000);
                var b = RandomHelper.Int(1, 1000);
                return a != b;
            });
        }

        [Test]
        public void Int_returns_a_value_between_given_values()
        {
            var min = 10;
            var max = 500;

            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Int(min, max);
                return value >= min && value <= max;
            });
        }
        
        [Test]
        public void Long_returns_a_random_value()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Long(1, 1000);
                var b = RandomHelper.Long(1, 1000);
                return a != b;
            });
        }

        [Test]
        public void Long_returns_a_value_between_given_values()
        {
            var min = 359;
            var max = 9001;

            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Long(min, max);
                return value >= min && value <= max;
            });
        }

        [Test]
        public void Bool_returns_a_random_value()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Bool();
                var b = RandomHelper.Bool();
                return a != b;
            });
        }

        [Test]
        public void Sign_returns_either_one_or_minus_one()
        {
            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Sign();
                return value == 1 || value == -1;
            });
        }

        [Test]
        public void Sign_returns_random_values()
        {
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Sign();
                var b = RandomHelper.Sign();
                return a != b;
            });
        }

        [Test]
        public void Pick_returns_a_value_from_the_original_collection()
        {
            var src = Enumerable.Range(1, 100).ToList();
            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.Pick(src);
                return src.Contains(value);
            });
        }
        
        [Test]
        public void Pick_returns_different_values()
        {
            var src = Enumerable.Range(1, 100).ToList();
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.Pick(src);
                var b = RandomHelper.Pick(src);
                return a != b;
            });
        }

        [Test]
        public void PickWeighted_returns_a_value_from_the_original_collection()
        {
            var src = Enumerable.Range(1, 100).ToList();
            RandomTestHelper.Always(() =>
            {
                var value = RandomHelper.PickWeighted(src, x => x);
                return src.Contains(value);
            });
        }
        
        [Test]
        public void PickWeighted_returns_different_values()
        {
            var src = Enumerable.Range(1, 100).ToList();
            RandomTestHelper.AtLeastOnce(() =>
            {
                var a = RandomHelper.PickWeighted(src, x => x);
                var b = RandomHelper.PickWeighted(src, x => x);
                return a != b;
            });
        }
        
        [Test]
        public void PickWeighted_returns_values_according_to_weight()
        {
            var numbers = new[] {5, 100};
            var picks = Enumerable.Range(1, 100).Select(x => RandomHelper.PickWeighted(numbers, y => y))
                                  .GroupBy(x => x)
                                  .ToDictionary(x => x.Key, x => x.Count());

            Assert.Greater(picks[100], picks[5]);
        }
    }
}
