using System;
using System.Collections.Generic;

namespace Eight.Zero
{
    class Program
    {
        public class BlogPost
        {
            public string? Title { get; set; }
            public List<Comment> Comments { get; } = new List<Comment>();

            public BlogPost(string? title)
            {
                Title = title;
            }
        }

        public class Comment
        {
            public string Body { get; set; }
            public Author PostedBy { get; set; }

            public Comment(string body, Author postedBy)
            {
                Body = body;
                PostedBy = postedBy;
            }

        }

        public class Author
        {
            public string Name { get; set; }
            public string Email { get; set; }

            public Author(string name, string email)
            {
                Name = name;
                Email = email;
            }
        }

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
            Console.WriteLine($"{post.Title} ({post.Title.Length})");

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
