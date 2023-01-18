using ServiceLayer.Estimations;

using DomainLayer.Entities;
using DomainLayer.Interfaces;

namespace CalculateSalaryAPIs.CommonServices
{
	public static class RegisterAppServices
	{
		public static void ConfigureAppServices(this IServiceCollection services)
		{
			services.AddMemoryCache();
			services.AddSingleton<ITaxCache, TaxCache>();
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddScoped<ModelValidationAttribute>();
			services.AddScoped<ICalculateService, CalculateService>();
			services.AddScoped<IFeesManagement, FeesManagement>();
			services.AddAutoMapper(typeof(Program));
		}

		public static void ConfigureMiddleware(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
		}
	}
}
