namespace University.Models
{
  public class StudentCourse
  {
    public int StudentCourseID { get; set;}
    public int CourseID { get; set;}
    public int StudentID { get; set;}
    public virtual Course course { get; set;}
    public virtual Student student { get; set;}

  }
}

