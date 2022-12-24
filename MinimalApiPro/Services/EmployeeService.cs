using Microsoft.EntityFrameworkCore;
using MinimalApiPro.Context;
using MinimalApiPro.Data;
using MinimalApiPro.Services.Interfaces;

namespace MinimalApiPro.Services
{
	public class EmployeeService : IEmployee
	{
		private readonly databaseContext _context;

		public EmployeeService(databaseContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
		{
			var data = await _context.employeeInfos.ToListAsync();

			return data;
		}
		public async Task<EmployeeInfo> SaveEmployeeInfo(EmployeeInfo model)
		{
			var data = new EmployeeInfo
			{
				Id = model.Id,
				Name = model.Name,
				Phone = model.Phone,
				Email = model.Email
			};

			if (model.Id != 0)
			{
				_context.employeeInfos.Update(model);
			}
			else
			{
				_context.employeeInfos.Add(model);
			}

			await _context.SaveChangesAsync();

			return data;
		}

		public async Task<EmployeeInfo> UpdateEmployeeInfo(EmployeeInfo model)
		{
			var data = new EmployeeInfo
			{
				Id = model.Id,
				Name = model.Name,
				Phone = model.Phone,
				Email = model.Email
			};

			if (model.Id != 0)
			{
				_context.employeeInfos.Update(model);
			}
			else
			{
				_context.employeeInfos.Add(model);
			}

			await _context.SaveChangesAsync();

			return data;
		}

		public async Task<EmployeeInfo> GetEmployeeById(int id)
		{
			var data = await _context.employeeInfos.FindAsync(id);

			return data;
		}
		public async Task<EmployeeInfo> DeleteEmployeeById(int id)
		{
			var data = await _context.employeeInfos.FindAsync(id);

			if (data != null)
			{
				_context.employeeInfos.Remove(data);
				await _context.SaveChangesAsync();
			}

			return data;
		}

		
	}
}
