using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;

namespace University.Controllers
{
  public class CourseController : Controller
  {
    private readonly UniversityContext _db;

    public CourseController(UniversityContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Courses.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course, int StudentId)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      if (StudentId != 0)
      {
        _db.StudentCourse.Add(new StudentCourse() { StudentId = StudentId, CourseId = course.CourseId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
          .Include(course => course.JoinEntities)
          .ThenInclude(join => join.Student)
          .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }
    public ActionResult Edit(int id)
    {
      var thisCourse= _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

  }
}