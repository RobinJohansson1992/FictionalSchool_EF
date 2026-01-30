using FictionalSchool_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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


        // Method that lets the user remove staff from staff-table:
        public static void RemoveStaff(FictionalSchoolContext context)
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
                .OrderBy(s => s.Staff.StaffId)
                .ToList();
            foreach (var a in allStaff)
            {
                Console.WriteLine($"{a.Staff.StaffId}. {a.Staff.Name}: {a.Roles.RoleName}");
            }
            Console.Write("\nAnge anställd-ID på den anställda du vill ta bort: ");
            int staffId;
            while (!int.TryParse(Console.ReadLine(), out staffId) || !allStaff.Any(s => s.Staff.StaffId == staffId))
            {
                UI.ErrorMessage();
            }

            var staffToRemove = context.Staff.First(s => s.StaffId == staffId);

            context.Staff.Remove(staffToRemove);
            context.SaveChanges();

            Console.WriteLine($"{staffToRemove.Name} togs bort från anställd-listan.");
            Console.ReadKey();
        }
        // Method that lets the user add staff to the staff-table:
        public static void AddStaff(FictionalSchoolContext context)
        {
            Console.Clear();
            var roles = context.Roles
               .OrderBy(r => r.RoleId)
               .ToList();
            Console.WriteLine("Tillgängliga roller:");
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.RoleId}. {role.RoleName}");
            }
            Console.WriteLine();
            Console.Write("Ange roll-ID för ny anställd: ");
            int roleId;
            while (!int.TryParse(Console.ReadLine(), out roleId) || roleId > roles.Count || roleId < 1)
            {
                UI.ErrorMessage();
            }
            Console.Write("Ange namn för ny anställd: ");
            string name = Console.ReadLine();

            //Create new staff-member:
            var newStaff = new Staff
            {
                Name = name,
                RoleId = roleId,
            };
            context.Staff.Add(newStaff); //Add member to the table
            context.SaveChanges(); //save to DB
            Console.WriteLine($"{newStaff.Name} lades till i anställd-listan.");
            Console.ReadKey();
        }
        // Method that prints all staff members in chosen order by user:
        public static void PrintStaff(FictionalSchoolContext context)
        {
            Console.Clear();
            // Join Staff and Role to get needed data:
            var allStaff = context.Staff
                .Join(
                context.Roles,
                s => s.RoleId,
                r => r.RoleId,
                (s, r) => new
                {
                    Roles = r,
                    Staff = s
                })
                .OrderBy(s => s.Staff.StaffId).ToList();
            foreach (var a in allStaff)
            {
                Console.WriteLine($"{a.Staff.StaffId}. {a.Staff.Name}: {a.Roles.RoleName}");
            }
            Console.ReadKey();
        }
        // Method that prints all classes:
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

            Console.WriteLine($"\n0. Tillbaka <-");
            PrintStudentsByClass(context, allClasses);
        }
        // Method that prints all students by class:
        public static void PrintStudentsByClass(FictionalSchoolContext context, List<Class> allClasses)
        {
            bool running = true;

            while (running)
            {
                int userInput;
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    UI.ErrorMessage();
                    Console.ReadKey();
                    continue;
                }
                if (userInput == 0)
                {
                    running = false;
                    continue;
                }
                if (userInput < 1 || userInput > allClasses.Count)
                {
                    UI.ErrorMessage();
                    Console.ReadKey();
                    continue;
                }
                Console.Clear();
                var students = context.Students
                    .Where(s => s.ClassId == userInput) // only print the students in chosen class
                    .ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName}");
                }

                Console.WriteLine("\nTryck enter för att gå tillbaka.");
                Console.ReadLine();
                running = false;
            }
        }
        // Method that prints all students in the school:
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
