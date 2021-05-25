namespace University.Models
{
  public class StudentCourse
  {
    public int StudentCourseID { get; set;}
    public int CourseID { get; set;}
    public int StudentID { get; set;}
    public virtual Course Course { get; set;}
    public virtual Student Student { get; set;}

  }
}

