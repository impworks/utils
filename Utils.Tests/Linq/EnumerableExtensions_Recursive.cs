using System.Collections.Generic;
using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.*Recursive methods.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_Recursive
    {
        private SampleTreeNode[] GetTree()
        {
            return new[]
            {
                new SampleTreeNode(
                    1,
                    new SampleTreeNode(
                        2,
                        new SampleTreeNode(3),
                        new SampleTreeNode(4)
                    ),
                    new SampleTreeNode(
                        5,
                        new SampleTreeNode(
                            6,
                            new SampleTreeNode(7)
                        ),
                        new SampleTreeNode(8)
                    )
                ), 
            };
        }

        [Test]
        public void SelectRecursive_selects_all_tree_nodes_in_depth_firt_order()
        {
            var tree = GetTree();
            var result = tree.SelectRecursively(x => x.Children).Select(x => x.Value);

            Assert.That(result, Is.EqualTo(new [] { 1, 2, 3, 4, 5, 6, 7, 8 }));
        }
        
        [Test]
        public void ApplyRecursive_visits_all_tree_nodes_in_depth_firt_order()
        {
            var tree = GetTree();
            var result = new List<int>();
            tree.ApplyRecursively(x => x.Children, x => result.Add(x.Value));

            Assert.That(result, Is.EqualTo(new [] { 1, 2, 3, 4, 5, 6, 7, 8 }));
        }
    }
}
