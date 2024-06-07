using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Repositories;
using WebApplication3.Services;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();

        //services.AddControllers()
            //.AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        DbInitializer.Initialize(context);

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}