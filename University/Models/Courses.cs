using System.Collections.Generic;

namespace University.Models 
{
    public class Course 
    {
        public Course()
        {
            this.JoinEntities = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<StudentCourse> JoinEntities { get;}
    }
}