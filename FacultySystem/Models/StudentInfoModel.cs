using FacultySystem.Enums;

namespace FacultySystem.Models
{
	public class StudentInfoModel
	{
		public object StudentId { get; set; }
		public string StudentFullName { get; set; }
		public DepartmentsEnums Department { get; set; }
		public double StudentGPA { get; set; }
	}
}
