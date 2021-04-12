using System;

namespace Eight.Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new BlogPost("Nullable Ref Types Rock!");
            post.Comments.Add(new Comment("Yes they do!", new Author("John", "john@nullrefs.com")));
            post.Comments.Add(new Comment("I love them!", new Author("Leah", "leah@nullrefs.com")));
            post.Comments.Add(null);

            PrintPostInfo(null);

        }

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
            return Color.Unknown;
        }
    }
}
