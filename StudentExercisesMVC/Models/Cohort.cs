﻿using StudentExercisesMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesAPI.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 5)]
        [Display(Name = "Cohort")]
        public string Name { get; set; }
        [Display(Name = "Student List")]
        public List<Student> Students { get; set; }
        [Display(Name = "Instructor List")]
        public List<Instructor> Instructors { get; set; }


    }
}
