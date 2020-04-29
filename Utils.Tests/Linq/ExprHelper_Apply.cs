﻿using System;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for ExprHelper.Apply method.
    /// </summary>
    [TestFixture]
    public class ExprHelper_Apply
    {
        [Test]
        public void Func1()
        {
            var expr = ExprHelper.Apply(x => x, 1).Compile();
            Assert.AreEqual(1, expr());
        }

        [Test]
        public void Func2()
        {
            var expr = ExprHelper.Apply((int x, int y) => x + y, 1).Compile();
            Assert.AreEqual(3, expr(2));
        }

        [Test]
        public void Func3()
        {
            var expr = ExprHelper.Apply((int x, int y, int z) => x + y + z, 1).Compile();
            Assert.AreEqual(6, expr(2, 3));
        }

        [Test]
        public void Func3_null()
        {
            var expr = ExprHelper.Apply((string x, string y, string z) => x + y + z, null).Compile();
            Assert.AreEqual("foobar", expr("foo", "bar"));
        }

        [Test]
        public void Action1()
        {
            var result = 0;
            Action<int> set = x => result = x;
            ExprHelper.Apply(x => set(x), 1).Compile()();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Action2()
        {
            var result = 0;
            Action<int> set = x => result = x;
            ExprHelper.Apply((int x, int y) => set(x + y), 1).Compile()(2);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Action3()
        {
            var result = 0;
            Action<int> set = x => result = x;
            ExprHelper.Apply((int x, int y, int z) => set(x + y + z), 1).Compile()(2, 3);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Action3_null()
        {
            var result = "";
            Action<string> set = x => result = x;
            ExprHelper.Apply((string x, string y, string z) => set(x + y + z), null).Compile()("foo", "bar");
            Assert.AreEqual("foobar", result);
        }
    }
}
