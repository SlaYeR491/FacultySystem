using FacultySystem.Enums;

namespace FacultySystem.Entities
{
	public class Student
	{
		public object StudentId { get; set; }
		public string StudentFullName { get; set; }
		public DepartmentsEnums Department { get; set; }
        public double StudentGPA { get; set; }
    }
}
