using OnlineCaterer.Persistence;
using OnlineCaterer.Application;

namespace OnlineCaterer.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddOptions();
			builder.Services.AddSingleton(builder.Configuration);
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			builder.Services.AddHttpContextAccessor();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(
					name: "MyCors",
					policy =>
					{
						policy.WithOrigins(
							//"https://localhost:7296"
							//"http://localhost:3000/"
							"*"
						).AllowAnyHeader()
						.AllowAnyMethod();
					});
			});

			//builder.Services.AddDistributedMemoryCache();
			//builder.Services.AddSession();

			// Add services to the container.

			builder.Services.RegisterApplicationServices();
			builder.Services.RegisterPersistenceServices(builder.Configuration);


			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				using (var serviceScope = app.Services?.GetService<IServiceScopeFactory>()?.CreateScope())
				{
					var context = serviceScope?.ServiceProvider.GetRequiredService<OnlineCatererDbContext>();
					context?.Database.EnsureCreated();
				}

				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("MyCors");
			//app.UseSession();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}