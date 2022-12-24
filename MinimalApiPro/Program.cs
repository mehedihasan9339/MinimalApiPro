using Microsoft.EntityFrameworkCore;
using MinimalApiPro.Context;
using MinimalApiPro.Data;
using MinimalApiPro.Services;
using MinimalApiPro.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var ConnectionStringName = "MyConnection";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<databaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionStringName)));

builder.Services.AddScoped<IEmployee, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


//EmployeeInfo API Start
app.MapGet("/employees", async (IEmployee employeeService) =>
	await employeeService.GetAllEmployees()
);
app.MapGet("/employee/{id}", async (int id, IEmployee employeeService) =>
{
	return await employeeService.GetEmployeeById(id);
});

app.MapPost("/employee", async (IEmployee employeeService, EmployeeInfo model) =>
{
	return await employeeService.SaveEmployeeInfo(model);
});
app.MapPut("/employee", async (IEmployee employeeService, EmployeeInfo model) =>
{
	return await employeeService.UpdateEmployeeInfo(model);
});
app.MapDelete("/employee/{id}", async (int id, IEmployee employeeService) =>
{
	return await employeeService.DeleteEmployeeById(id);
});
//EmployeeInfo API End

app.Run();
