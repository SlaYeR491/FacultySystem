using FacultySystem.Interfaces;
using FacultySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacultySystem.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class AdminsController(IGeneralServices generalServices) : ControllerBase
	{
		[HttpPost]
		public IActionResult DepartmentsDistribution(DepartmnetDistributionModel model)
		{
			return Ok(generalServices.DepartmentsDistribution(model.Requests, model.ShouldExistDepratments, model.MaxLimits));
		}
	}
}
