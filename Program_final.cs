using System;
using System.Data.Entity;

namespace StudentDatabase
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDB") { }
        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob
            };

            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }

            Console.WriteLine("Student added successfully.");
            Console.ReadKey();
        }
    }
}
