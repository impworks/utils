﻿using System.Xml.Serialization;

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

        [XmlElement(IsNullable = true)]
        public string Str { get; set; }

        public string Field;

        public override string ToString()
        {
            return $"SampleObj {{ Value = {Value}, Str = {Str}, Field = {Field} }}";
        }
    }
}
