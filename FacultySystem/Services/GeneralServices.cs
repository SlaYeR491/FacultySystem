using FacultySystem.Enums;
using FacultySystem.Interfaces;
using FacultySystem.Models;

namespace FacultySystem.Services
{
	public class GeneralServices : IGeneralServices
	{
		public IEnumerable<StudentInfoModel> DepartmentsDistribution(
			IEnumerable<DepartmentRequestModel> requests,
			IEnumerable<DepartmentsEnums> shouldExistDepratments,
			IEnumerable<MaxLimitDepartmentModel> maxLimits)
		{
			//Check Validations
			foreach (var request in requests)
			{
				if (!CheckValidation(request, shouldExistDepratments))
				{
					Console.WriteLine($"The Request For StudentId {request.StudentId} Is Not Valid");
					throw new InvalidDataException();
				}
			}

			if (!CheckMaxLimitsValidation(maxLimits, shouldExistDepratments))
			{
				Console.WriteLine($"The Max Departments Limit Is Not Valid");
				throw new InvalidDataException();
			}

			//Order Requests Based On GPA
			requests = GetRequestsWithStudentGPA(requests).OrderByDescending(r => r.StudentGPA);

			//Make It Easier (:
			Dictionary<DepartmentsEnums, int> departmentsLimit = new();
			foreach (var limit in maxLimits)
			{
				departmentsLimit.Add(limit.Department, limit.Limit);
			}

			//Distribute Students
			List<StudentInfoModel> studentsInfo = new();
			foreach (var request in requests)
			{
				var dep = request.DepartmentsOrder.Dequeue();
				if (departmentsLimit[dep] > 0)
				{
					studentsInfo.Add(new StudentInfoModel
					{
						Department = dep,
						StudentId = request.StudentId,
						StudentGPA = request.StudentGPA,
						StudentFullName = "Default Sardina"
					});
					departmentsLimit[dep]--;
				}
			}
		
			return studentsInfo;
		}

		private bool CheckValidation(DepartmentRequestModel request, IEnumerable<DepartmentsEnums> shouldExistDepratments)
		{
			var departments = request.DepartmentsOrder.Distinct();
			if (departments.Count() != shouldExistDepratments.Count())
				return false;

			return CheckForExistingDepartments(departments, shouldExistDepratments);
		}

		private bool CheckForExistingDepartments(IEnumerable<DepartmentsEnums> departmentsOrder, IEnumerable<DepartmentsEnums> shouldExistDepratments)
		{
			//Make A Copy
			var shouldExistDepratmentsCopy = shouldExistDepratments.Select(d => d).ToList();

			//Iterate
			foreach (var department in departmentsOrder)
			{
				if (!shouldExistDepratmentsCopy.Remove(department))
					return false;
			}

			return shouldExistDepratmentsCopy.Count == 0;
		}

		private IEnumerable<DepartmentRequestModel> GetRequestsWithStudentGPA(IEnumerable<DepartmentRequestModel> requests)
		{
			//Retrieve From Data Base
			return requests;
		}

		private bool CheckMaxLimitsValidation(IEnumerable<MaxLimitDepartmentModel> maxLimits, IEnumerable<DepartmentsEnums> shouldExistDepratments)
		{
			//Make A Copy
			var shouldExistDepratmentsCopy = shouldExistDepratments.Select(d => d).ToList();

			//Iterate
			foreach (var limit in maxLimits)
			{
				if (!shouldExistDepratmentsCopy.Remove(limit.Department))
					return false;
			}

			return shouldExistDepratmentsCopy.Count == 0;
		}
	}
}
