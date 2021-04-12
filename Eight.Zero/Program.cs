using System;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Eight.Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Utf8JsonReader Example");
            Console.WriteLine("----------------------");
            var jsonFile = File.ReadAllBytes("sample.json");
            var jsonSpan = jsonFile.AsSpan();
            var jsonReader = new Utf8JsonReader(jsonSpan);
            while (jsonReader.Read())
            {
                Console.WriteLine(GetTokenDesc(jsonReader));
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Utf8JsonReader Example");
            Console.WriteLine("----------------------");
            using var stream = File.OpenRead("sample.json");
            using var doc = JsonDocument.Parse(stream);
            var root = doc.RootElement;
            var firstName = root.GetProperty("author").GetProperty("firstName").GetString();
            Console.WriteLine($"Author first name: {firstName}");
            Console.WriteLine(Environment.NewLine);
            EnumerateElement(root);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Array Indices and Ranges Example");
            Console.WriteLine("--------------------------------");
            var numbers = Enumerable.Range(1, 10).ToArray();
            var copy = numbers[0..^0]; // Copy all the numbers
            var copy1 = numbers[..]; // Copy all the numbers
            var allButFirst = numbers[1..];
            var lastItemRange = numbers[^1..];
            var lastItem = numbers[^1];
            var lastThree = numbers[^3..];

            Index middle = 4;
            Index threeFromEnd = ^3;
            Range customRange = middle..threeFromEnd;
            var custom = numbers[customRange];

            Console.WriteLine($"numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"copy: {string.Join(", ", copy)}");
            Console.WriteLine($"allButFirst: {string.Join(", ", allButFirst)}");
            Console.WriteLine($"lastItemRange: {string.Join(", ", lastItemRange)}");
            Console.WriteLine($"lastItem: {lastItem}");
            Console.WriteLine($"lastThree: {string.Join(", ", lastThree)}");
            Console.WriteLine($"customRange: {customRange}");
            Console.WriteLine($"custom: {string.Join(", ", custom)}");
            Console.Read();


            var post = new BlogPost("Nullable Ref Types Rock!");
            post.Comments.Add(new Comment("Yes they do!", new Author("John", "john@nullrefs.com")));
            post.Comments.Add(new Comment("I love them!", new Author("Leah", "leah@nullrefs.com")));
            post.Comments.Add(null);

            PrintPostInfo(null);
        }

        private static void EnumerateElement(JsonElement root)
        {
            foreach (var prop in root.EnumerateObject())
            {
                if (prop.Value.ValueKind == JsonValueKind.Object)
                {
                    Console.WriteLine($"{prop.Name}:");
                    Console.WriteLine($"--BEGIN OBJECT--");
                    EnumerateElement(prop.Value);
                    Console.WriteLine($"--END OBJECT--");
                }
                else
                {
                    Console.WriteLine($"{prop.Name}: {prop.Value.GetRawText()}");
                }
            }
        }

        private static string GetTokenDesc(Utf8JsonReader json) =>
            json.TokenType switch
            {
                JsonTokenType.StartObject => "START OBJECT",
                JsonTokenType.EndObject => "END OBJECT",
                JsonTokenType.StartArray => "START ARRAY",
                JsonTokenType.EndArray => "END ARRAY",
                JsonTokenType.PropertyName => $"PROPERTY: {json.GetString()}",
                JsonTokenType.Comment => $"COMMENT: {json.GetString()}",
                JsonTokenType.String => $"STRING: {json.GetString()}",
                JsonTokenType.Number => $"NUMBER: {json.GetInt32()}",
                JsonTokenType.True => $"BOOL: {json.GetBoolean()}",
                JsonTokenType.False => $"BOOL: {json.GetBoolean()}",
                JsonTokenType.Null => $"NULL",
                _ => $"**UNHANDLED TOKEN: {json.TokenType}"
            };

        static void PrintPostInfo(BlogPost post)
        {
            Console.WriteLine($"{post.Title} ({post.Title!.Length})");

            foreach (var comment in post.Comments)
            {
                var commentPreview = comment.Body.Length > 10 ?
                    $"{comment.Body.Substring(0, 10)}..." :
                    comment.Body;

                Console.WriteLine($"{comment.PostedBy.Name} ({comment.PostedBy.Email}): " + $"{commentPreview}");
            }
        }
    }

    public static class PositionalPatternSample
    {
        public static bool IsInSeventhGradeMath(Student s)
        {
            // Works because of deconstructor
            return s is (_, _, (_, _, "Math"), 7);
        }
    }

    public static class PropertyPatternSample
    {
        public static bool IsUsBasedWithUkManager(object o)
        {
            return o is Employee e && e is { Region: "US", ReportsTo: { Region: "UK" } };
        }

    }

    public static class SwitchExpressionSample
    {
        public static string DisplayShapeInfo(object shape) =>
            shape switch
            {
                Rectangle r => r switch
                {
                    _ when r.Length == r.Width => "Square!",
                    _ => $"Rectangle ${r.Length}",
                },
                Circle { Radius: 1 } => "Small Circle",
                Circle c => $"Circle ${c.Radius}",
                Triangle t => $"Triangle ${t.Side1}, ${t.Side2}, ${t.Side3}",
                _ => "Unknown Shape"
            };
    }

    public static class TuplePatternSample
    {
        public static Color GetColor(Color c1, Color c2)
        {
            return (c1, c2) switch
            {
                (Color.Red, Color.Blue) => Color.Purple,
                (Color.Blue, Color.Red) => Color.Purple,

                (Color.Yellow, Color.Red) => Color.Orange,
                (Color.Red, Color.Yellow) => Color.Orange,

                (Color.Red, Color.Green) => Color.Brown,
                (Color.Green, Color.Red) => Color.Brown,

                (_, _) when c1 == c2 => c1,

                _ => Color.Unknown
            };
        }
    }
}
