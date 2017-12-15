using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class Enrollment
    {

        public int Id { get; set; } 

        public string CourseId { get; set; }

        public int StudentId { get; set; }

        public Grade? Grade { get; set; }

        // navigational properties
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum Grade
    {
        A, B, C, F
    }
}