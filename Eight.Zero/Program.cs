﻿using System;
using System.Collections.Generic;

namespace Eight.Zero
{
    class Program
    {
        public class BlogPost
        {
            public string Title { get; set; }
            public List<Comment> Comments { get; } = new List<Comment>();

            public BlogPost(string title)
            {
                Title = title;
            }
        }

        public class Comment
        {
            public string Body { get; set; }
            public Author PostedBy { get; set; }

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
            Console.WriteLine("Hello World!");
        }
    }
}
