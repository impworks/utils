namespace Utils.Tests.Linq
{
    /// <summary>
    /// Object for testing sorting.
    /// </summary>
    public class SampleObject
    {
        public SampleObject()
        {

        }

        public SampleObject(int value, string str)
        {
            Value = value;
            Str = str;
        }

        public int Value { get; set; }

        public string Str { get; set; }

        public string Field;
    }
}
