# Impworks.Utils

![AppVeyor](https://img.shields.io/appveyor/ci/impworks/Utils.svg) ![AppVeyor Tests](https://img.shields.io/appveyor/tests/impworks/Utils.svg) [![NuGet](https://img.shields.io/nuget/v/Impworks.Utils.svg)](https://www.nuget.org/packages/Impworks.Utils/) ![NuGet Downloads](https://img.shields.io/nuget/dt/Impworks.Utils.svg)

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
  
      Parsing to various types (primitives supported by default):
      ```csharp
      "123".Parse<int>() // 123
      "hello".TryParse<int?>() // null
      "12345".TryParse<MyType>(MyParseFunc) // MyType
      "1,2,test,3".TryParseList<int>() // 1, 2, 3
      "1;2;test;3".TryParseList<int>(separator: ";") // 1, 2, 3
      "1".TryParse<MyEnum?>(); // MyEnum or null
      ```
      Coalesce:
      ```csharp
      StringHelper.Coalesce(null, "", "test") // test
      ```
      Ends/starts with substring:
      ```csharp
      "hello world".StartsWithPart("hello test", 5) // true
      "a test".EndsWithPart("b TEST", 4, ignoreCase: true) // true
      ```
      Transliteration from Russian:
      ```csharp
      StringHelper.Transliterate("Привет мир", "_") // "Privet_mir"
      ```
      `string.Join` as extension:
      ```csharp
      new [] { 1, 2, 3 }.JoinString(", ") // "1, 2, 3"
      ```

  * Enumerable

      `Distinct` by projection:
      ```csharp
      new [] { 1, 2, 3 }.DistinctBy(x => x % 2) // 1, 2
      ```
      Conditional ordering:
      ```csharp
      new [] { 4, 6, 1 }.OrderBy(x => x, isDescending) // true => 6, 4, 1, false => 1, 4, 6
      new [] { obj1, obj2 }.OrderBy("FieldA.FieldB", isDescending) // orders by field or path
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

  * Expressions

      Expression combinations (useful for LINQ):
      ```csharp
      ExprHelper.And<Foo>(x => x.A == 1, x => x.B == 2) // x => x.A == 1 && x.B == 2
      ExprHelper.Or<Foo>(x => x.A == 1, x => x.B == 2) // x => x.A == 1 || x.B == 2
      ```
      Partial application (for `Func` and `Action` up to 8 arguments):
      ```csharp
      ExprHelper.Apply((int x, int y) => x + y, 10) // Expr for (int x) => x + 10
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
      Case-insensitive IsDefined:
      ```csharp
      EnumHelper.IsDefined<Language>("csharp") // true
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
      RandomHelper.PickWeighted(new [] { "a", "test", "blablabla" }, x => x.Length) // "blablabla"
      ```

  * Dictionary

      Value retrieval:
      ```csharp
      var dict = new Dictionary<string, int> { ["hello"] = 1, ["world"] = 2 };
      dict.TryGetValue("hello") // 1
      dict.TryGetValue("test") // 0
      dict.TryGetValue("foo", null, "hello") // 1
      dict.TryGetNullableValue("test") // null
      ```

  * Urls

      URL parts combination:
      ```csharp
      UrlHelper.Combine("http://a.com/foo", "bar/", "/test") // http://a.com/foo/bar/test
      ```
      Query generation from an object (accepts anonymous objects, `Dictionary` and `JObject`):
      ```csharp
      UrlHelper.GetQuery(new { A = 1, B = "hello" }) // "A=1&B=hello"
      UrlHelper.GetQuery(new { A = new [] { 1, 2, 3 } }) // "A=1&A=2&A=3"
      ```

  * Tasks (.NET Standard 2.0 only)

      Parallel awaiting (strong typing, up to 7 values):
      ```csharp
      var (i, str) = await TaskHelper.GetAll(
          GetIntAsync(),
          GetStringAsync()
      );
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
      Less verbose serialization with a cleaner resulting XML:
      ```csharp
      var obj = new MyObject { Foo = "hello", Bar = (int?) null };
      XmlHelper.Serialize(obj) // <MyObject><Foo>Hello</Foo><Bar /></MyObject>
      XmlHelper.Serialize(obj, clean: false); // lots of junk: xml declaration, namespaces, nil's
      XmlHelper.Deserialize<MyObject>("...") // gets it back
       ```