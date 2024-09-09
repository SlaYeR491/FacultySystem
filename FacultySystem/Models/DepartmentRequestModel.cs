using FacultySystem.Enums;

namespace FacultySystem.Models
{
	public class DepartmentRequestModel
	{
		public required object StudentId { get; set; }
		public required double StudentGPA { get; set; }
		public required Queue<DepartmentsEnums> DepartmentsOrder { get; set; }
	}
}
