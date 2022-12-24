using MinimalApiPro.Data;

namespace MinimalApiPro.Services.Interfaces
{
	public interface IEmployee
	{
		Task<IEnumerable<EmployeeInfo>> GetAllEmployees();
		Task<EmployeeInfo> SaveEmployeeInfo(EmployeeInfo model);
		Task<EmployeeInfo> UpdateEmployeeInfo(EmployeeInfo model);
		Task<EmployeeInfo> GetEmployeeById(int id);
		Task<EmployeeInfo> DeleteEmployeeById(int id);
	}
}
