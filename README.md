# Impworks.Utils

![AppVeyor](https://img.shields.io/appveyor/ci/impworks/Utils.svg) ![AppVeyor Tests](https://img.shields.io/appveyor/tests/impworks/Utils.svg) [![NuGet](https://img.shields.io/nuget/v/Impworks.Utils.svg)](https://www.nuget.org/packages/Impworks.Utils/)

A collection of useful helper methods.

## Installation

To install, use the following Package Manager command:

```
PM> Install-Package Impworks.Utils
```

## Usage

Add the `using` directive with the required namespace to the top of the file where you intend to use a helper method.

If you work with Resharper, it will suggest adding the namespace automatically.

## The methods

The package provides the following methods, split into logical parts.

  * Strings
  
      Parsing to primitive types:
      ```csharp
      "123".Parse<int>() // 123
      "hello".TryParse<int?>() // null
      "1,2,test,3".TryParseList<int>() // 1, 2, 3
      ```
      Coalesce:
      ```csharp
      StringHelper.Coalesce(null, "", "test") // test
      ```
      Ends/starts with substring:
      ```
      "hello world".StartsWithPart("hello test", 5) // true
      "a test".EndsWithPart("b TEST", 4, ignoreCase: true) // true
      ```
      Transliteration from Russian:
      ```csharp
      StringHelper.Transliterate("Привет мир", "_") // "Privet_mir"
      ```
     
  * Enumerable
  
      `Distinct` by projection:
      ```csharp
      new [] { 1, 2, 3 }.DistinctBy(x => x % 2) // 1, 2
      ```
      Conditional ordering:
      ```csharp
      new [] { 4, 6, 1 }.OrderBy(x => x, isDescending) // true => 6, 4, 1, false => 1, 4, 6
      ```
      Partitioning:
      ```csharp
      new [] { 1, 2, 3, 4, 5, 6 }.PartitionBySize(2) // [1, 2], [3, 4], [5, 6]
      new [] { 1, 2, 3, 4, 5, 6 }.PartitionByCount(2) => [1, 2, 3], [4, 5, 6]
      ```
      Recursive selection and application:
      ```csharp
      new [] { treeRoot }.SelectRecursively(x => x.Children) // selects all children in a flat list
      new [] { treeRoot }.ApplyRecursively(x => x.Children, x => x.Value = 1) // sets Value = 1 on all children
      ```

  * Enums
  
      Captions from `Description` attribute:
      ```csharp
      enum Language
      {
          [Description("C#")] CSharp,
          [Description("C++")] CPlusPlus
      }
      EnumHelper.GetEnumDescriptions<Language>() // { Language.CSharp = "C#", Language.CPlusPlus = "C++" }
      ```
      
  * Random
  
    Random values:
    ```csharp
    RandomHelper.Int(1, 100) // 42
    RandomHelper.Float() // 0.1337
    RandomHelper.Sign() // -1 or 1
    ```
    Random picks:
    ```csharp
    RandomHelper.Pick(1, 2, 3, 4, 5) // 4
    RandomHelper.PickWeighted(new [] { "a", "test", "blablabla" }, x => x.Length ) // "blablabla"
    ```
    
  * XML
  
      Attributes:
      ```csharp
      var xml = XElement.Parse(@"<test a=""1337"" b=""true"" />");
      xml.Attr("a") // "1337"
      xml.ParseAttr<int>("a") // 1337
      xml.ParseAttr<bool>("b") // true
      xml.TryParseAttr<bool?>("a") // null
      ```
