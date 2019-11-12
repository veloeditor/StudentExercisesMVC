using StudentExercisesMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesAPI.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Slack Name")]
        public string SlackHandle { get; set; }
        [Required]
        public int CohortId { get; set; }
        [Required]
        [Display(Name = "Cohort")]
        public Cohort Cohort { get; set; }
        [Required]
        [Display(Name = "Specialty")]
        public string Speciality { get; set; }



        //assignment method for instructors to assign excerises to students
        public void SetAssignment(Exercise exercise, Student student)
        {
            student.Exercises.Add(exercise);
        }
    }
}
