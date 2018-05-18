using System.Collections.Generic;

namespace Utils.Tests.Linq
{
    public class SampleTreeNode
    {
        public SampleTreeNode(int value, params SampleTreeNode[] children)
        {
            Value = value;
            Children = children;
        }

        public int Value { get; }

        public IReadOnlyList<SampleTreeNode> Children { get; }
    }
}
