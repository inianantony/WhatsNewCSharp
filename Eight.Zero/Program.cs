using System;

namespace Eight.Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new Models.BlogPost("Nullable Ref Types Rock!");
            post.Comments.Add(new Models.Comment("Yes they do!", new Models.Author("John", "john@nullrefs.com")));
            post.Comments.Add(new Models.Comment("I love them!", new Models.Author("Leah", "leah@nullrefs.com")));
            post.Comments.Add(null);

            PrintPostInfo(null);

        }

        static void PrintPostInfo(Models.BlogPost post)
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
}
