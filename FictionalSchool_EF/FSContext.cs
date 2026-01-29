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
    internal class FSContext : DbContext
    {
        public FSContext()
        {
        }

        public FSContext(DbContextOptions<FictionalSchoolContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        public static void PrintStaff(FictionalSchoolContext context)
        {
            Console.Clear();
            var allStaff = context.Staff
                .Join(
                context.Roles,
                s => s.RoleId,
                r => r.RoleId,
                (s, r) => new
                {
                    Roles = r,
                    Staff = s
                }

                )
                .OrderBy(s => s.Staff.StaffId).ToList();
            foreach(var a in allStaff)
            {
                Console.WriteLine($"{a.Staff.StaffId}. {a.Staff.Name}: {a.Roles.RoleName}");
            }
            Console.ReadKey();
        }
        public static void PrintClasses(FictionalSchoolContext context)
        {
            Console.Clear();
            UI.PrintClassesUI();
            var allClasses = context.Classes
                .OrderBy(c => c.ClassId)
                .ToList();
            foreach (var c in allClasses)
            {
                Console.WriteLine($"{c.ClassId}. {c.ClassName}");
            }
            //UI.CheckInput(1, allClasses.Count);
            Console.WriteLine($"\n0. Tillbaka <-");
            PrintStudentsByClass(context, allClasses);
        }
        public static void PrintStudentsByClass(FictionalSchoolContext context, List<Class> allClasses)
        {
            bool running = true;
            while (running)
            {

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    UI.ErrorMessage();
                }
                switch (userInput)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        var classOne = context.Students
                            .Where(c => c.ClassId == 1)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classOne)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 2:
                        var classTwo = context.Students
                            .Where(c => c.ClassId == 2)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classTwo)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 3:
                        var classThree = context.Students
                            .Where(c => c.ClassId == 3)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classThree)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 4:
                        var classFour = context.Students
                            .Where(c => c.ClassId == 4)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classFour)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 5:
                        var classFive = context.Students
                            .Where(c => c.ClassId == 5)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classFive)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 6:
                        var classSix = context.Students
                            .Where(c => c.ClassId == 6)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classSix)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 7:
                        var classSeven = context.Students
                            .Where(c => c.ClassId == 7)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classSeven)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    case 8:
                        var classEight = context.Students
                            .Where(c => c.ClassId == 8)
                            .ToList();
                        Console.Clear();
                        foreach (var c in classEight)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName}");
                        }
                        Console.WriteLine("\nTryck enter för att gå tillbaka.");
                        Console.ReadKey();
                        running = false;
                        break;
                    default:
                        UI.ErrorMessage();
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void PrintAllStudents(FictionalSchoolContext context)
        {
            Console.Clear();
            UI.PrintStudentsUI();
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                UI.ErrorMessage();
            }
            switch (userInput)
            {
                case 0:
                    UI.MainMenu();
                    break;
                case 1:
                    var allStudents = context.Students
           .OrderBy(x => x.FirstName)
           .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    allStudents = context.Students
        .OrderByDescending(x => x.FirstName)
        .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    allStudents = context.Students
           .OrderBy(x => x.LastName)
           .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    allStudents = context.Students
          .OrderByDescending(x => x.LastName)
          .ToList();
                    Console.Clear();
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                    Console.ReadKey();
                    break;
                default:
                    UI.ErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
