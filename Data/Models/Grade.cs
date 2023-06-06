﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime awardDate { get; set; }    

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }    


    }
}
