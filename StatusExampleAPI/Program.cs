using Microsoft.OpenApi.Models;
using System.Reflection;

internal class Program
{
	private static void Main( string[] args )
	{
		var builder = WebApplication.CreateBuilder( args );

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen( options =>
		{
			options.SwaggerDoc( "v1", new OpenApiInfo
			{
				Version = "v1",
				Title = "Status Example API",
				Description = "An ASP.NET Core Web API for testing HTTP status codes",
				TermsOfService = new Uri( "https://example.com/terms" ),
				Contact = new OpenApiContact
				{
					Name = "Example Contact",
					Url = new Uri( "https://example.com/contact" )
				},
				License = new OpenApiLicense
				{
					Name = "Example License",
					Url = new Uri( "https://example.com/license" )
				}
			} );

			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			options.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, xmlFilename ) );
		} );

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if ( app.Environment.IsDevelopment() )
		{
			app.UseSwagger();
			app.UseSwaggerUI( options =>
			{
				options.SwaggerEndpoint( "/swagger/v1/swagger.json", "v1" );
				options.RoutePrefix = "docs";
			} );
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}