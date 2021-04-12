using System;
using System.Collections.Generic;

namespace Eight.Zero
{
    public class Course
    {
        public string CourseName { get; set; }
        public string Language { get; set; }
        public Author Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public int PublishedYear { get; set; }
        public bool IsActive { get; set; }
        public string[] Tags { get; set; }
    }

    public class Circle
    {
        public int Radius { get; }
        public Circle(int radius) => Radius = radius;
    }

    public class Rectangle
    {
        public int Length { get; }
        public int Width { get; }
        public Rectangle(int length, int width) =>
            (Length, Width) = (length, width);
    }

    public class Triangle
    {
        public int Side1 { get; }
        public int Side2 { get; }
        public int Side3 { get; }

        public Triangle(int side1, int side2, int side3) =>
            (Side1, Side2, Side3) = (side1, side2, side3);
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public Employee ReportsTo { get; set; }
    }

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
#pragma warning disable 8618
        public Author()
#pragma warning restore 8618
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
