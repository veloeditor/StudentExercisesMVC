using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;
using StudentExercisesMVC.Models.ViewModels;

namespace StudentExercisesMVC.Controllers
{
    public class ExerciseController : Controller
    {

        private readonly IConfiguration _config;

        public ExerciseController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        //GET All Exercises
        public IActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, CodeLanguage 
                                          FROM Exercises";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Exercise> exercises = new List<Exercise>();
                    Exercise exercise = null;

                    while (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),

                            CodeLanguage = reader.GetString(reader.GetOrdinal("CodeLanguage"))
                   
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return View(exercises);
                }
            }
        }

        //GET Exercise/Details/5

        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, CodeLanguage FROM Exercises 
                                         WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    Exercise exercise = null;

                    if (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            CodeLanguage = reader.GetString(reader.GetOrdinal("CodeLanguage"))
                        };
                    }

                    reader.Close();
                    return View(exercise);

                }
            }
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Exercise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercise newExercise)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Exercises (Name, CodeLanguage) VALUES (@name, @codeLanguage)";
                        cmd.Parameters.Add(new SqlParameter("@name", newExercise.Name));
                        cmd.Parameters.Add(new SqlParameter("@codeLanguage", newExercise.CodeLanguage));


                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Exercise/Edit/5
        public ActionResult Edit(int id)
        {
            Exercise exercise = GetExerciseById(id);

            return View(exercise);
        }

        // POST: Exercise/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exercise updatedExercise)
        {
            try
            {
                
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Exercises
                                               SET Name = @name, CodeLanguage = @codeLanguage
                                               WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@name", updatedExercise.Name));
                        cmd.Parameters.Add(new SqlParameter("@codeLanguage", updatedExercise.CodeLanguage));
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Exercise/Delete/5
        public ActionResult Delete(int id)
        {
            Exercise exercise = GetExerciseById(id);
            return View(exercise);
        }

        // POST: Exercise/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM StudentExercises WHERE Exerciseid = @id;
                                            DELETE FROM Exercises WHERE id = @id";
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Exercise GetExerciseById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, CodeLanguage FROM Exercises 
                                         WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;

                    if (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            CodeLanguage = reader.GetString(reader.GetOrdinal("CodeLanguage"))
                        };
                    }

                    reader.Close();
                    return exercise;
                }
            }
        }
    }
 }
