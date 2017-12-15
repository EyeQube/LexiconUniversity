namespace LexiconUniversity.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconUniversity.DataAccess.LexiconUniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LexiconUniversity.DataAccess.LexiconUniversityContext";
        }

        protected override void Seed(LexiconUniversity.DataAccess.LexiconUniversityContext context)
        {
            context.Courses.AddOrUpdate(

                c => c.CourseId,
                new Course { CourseId = "PP123", Credits = 0, Name = "PHP for Poets" },
                new Course { CourseId = "DN123", Credits = 0, Name = "DotNet for Accountants" },
                new Course { CourseId = "JE123", Credits = 0, Name = "Java for Coffedrinkers" }
                );



            Student[] students = new[] {
                new Student { FirstName = "Adam", LastName = "Andersson" },
                new Student { FirstName = "Berit", LastName = "Bossom" },
                new Student { FirstName = "Cesar", LastName = "Carlsson" },
                new Student { FirstName = "David", LastName = "Dre" }
                };


            context.Students.AddOrUpdate(s => new { s.FirstName, s.LastName} ,students);
            context.SaveChanges();

            context.Enrollments.AddOrUpdate(    
                e => new { e.CourseId, e.StudentId },
                new Enrollment { CourseId = "PP123", StudentId = students[0].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[1].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[2].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[3].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[2].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[0].Id }
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
