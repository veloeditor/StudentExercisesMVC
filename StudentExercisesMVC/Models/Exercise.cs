using StudentExercisesMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesAPI.Models
{
    public class Exercise
    {

        // You must define a type for representing an exercise in code. An exercise can be assigned to many students.
        // Name of exercise
        // Language of exercise (JavaScript, Python, CSharp, etc.)





        public int Id { get; set; }
        [Display(Name = "Exercise")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Coding Language")]
        [Required]
        public string CodeLanguage { get; set; }
        [Display(Name = "Student List")]
        public List<Student> Students { get; set; }
    }
}
