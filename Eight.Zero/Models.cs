using System.Collections.Generic;

namespace Eight.Zero
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Teacher HomeRoomTeacher { get; set; }
        public int GradeLevel { get; set; }

        public Student(string firstName, string lastName,
            Teacher homeRoomTeacher, int gradeLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            HomeRoomTeacher = homeRoomTeacher;
            GradeLevel = gradeLevel;
        }

        public void Deconstruct(out string firstName,
            out string lastName,
            out Teacher homeRoomTeacher,
            out int gradeLevel)
        {
            firstName = FirstName;
            lastName = LastName;
            homeRoomTeacher = HomeRoomTeacher;
            gradeLevel = GradeLevel;
        }

    }

    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Teacher(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public void Deconstruct(out string firstName,
            out string lastName,
            out string subject)
        {
            firstName = FirstName;
            lastName = LastName;
            subject = Subject;
        }

    }

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
}
