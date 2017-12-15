using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => (FirstName + " " + LastName).Trim();    

        //navigational properties
        public virtual ICollection<Enrollment> Enrollments { get; set;}

    }
}