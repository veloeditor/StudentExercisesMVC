using Microsoft.AspNetCore.Mvc.Rendering;
using StudentExercisesMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises.Models.ViewModels
{
    public class StudentCreateViewModel
    {
        public List<Cohort> Cohorts { get; set; } = new List<Cohort>();
        public Student Student { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public List<SelectListItem> CohortOptions
        {
            get
            {
                if (Cohorts == null) return null;

                return Cohorts.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

          
            }
        }
        public List<SelectListItem> ExerciseOptions
        {
            get
            {
                
                return Exercises.Select(e => new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }).ToList();
            }
        }
    }
}
