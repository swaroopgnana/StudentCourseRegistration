
using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // Temporary in-memory storage for students
        private static List<Student> students = new List<Student>();

        // Automatically generated student ID
        private static int nextId = 1;

        // GET: Student/Index
        // Display all registered students
        public IActionResult Index()
        {
            return View(students);
        }

        // GET: Student/Create
        // Display student registration form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // Receive and validate student information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = nextId++;

                students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Details/1
        // Display individual student details
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
