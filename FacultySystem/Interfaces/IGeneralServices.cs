using FacultySystem.Enums;
using FacultySystem.Models;

namespace FacultySystem.Interfaces
{
	public interface IGeneralServices
	{
		/// <summary>
		/// Distributing Students To Departments Based On GPA And Department Order
		/// </summary>
		/// <param name="requests"></param>
		/// <param name="shouldExistDepratments"></param>
		/// <param name="maxLimits"></param>
		/// <returns></returns>
		IEnumerable<StudentInfoModel> DepartmentsDistribution(
			IEnumerable<DepartmentRequestModel> requests,
			IEnumerable<DepartmentsEnums> shouldExistDepratments,
			IEnumerable<MaxLimitDepartmentModel> maxLimits);
	}
}
