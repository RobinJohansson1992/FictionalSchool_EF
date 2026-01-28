using FictionalSchool_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalSchool_EF
{
    internal class FSContent : DbContext
    {
        public FSContent()
        {
        }

        public FSContent(DbContextOptions<FictionalSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        public static void PrintAllStudents()
        {
            using (var context = new FictionalSchoolContext())
            {
                UI.PrintStudentsUI();
                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 4)
                {
                    UI.ErrorMessage();
                }
                if (userInput == 1)
                {
                    var allStudents = context.Students
                .OrderBy(x => x.FirstName)
                .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                }
                if (userInput == 2)
                {
                    var allStudents = context.Students
                .OrderByDescending(x => x.FirstName)
                .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                }
                if (userInput == 3)
                {
                    var allStudents = context.Students
                .OrderBy(x => x.LastName)
                .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                }
                if (userInput == 4)
                {
                    var allStudents = context.Students
                .OrderByDescending(x => x.LastName)
                .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                }

            }
        }

    }
}
