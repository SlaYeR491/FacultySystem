using FacultySystem.Enums;

namespace FacultySystem.Models
{
	public class DepartmnetDistributionModel
	{
		public required IEnumerable<DepartmentRequestModel> Requests { get; set; }
		public required IEnumerable<DepartmentsEnums> ShouldExistDepratments { get; set; }
		public required IEnumerable<MaxLimitDepartmentModel> MaxLimits { set; get; }
	}
}
