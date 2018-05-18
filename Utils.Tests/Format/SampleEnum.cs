using System.ComponentModel;

namespace Utils.Tests.Format
{
    /// <summary>
    /// Sample enum.
    /// </summary>
    public enum SampleEnum
    {
        [Description("First value")]
        Hello = 13,

        [Description("Other value")]
        World = 37,
    }
}
