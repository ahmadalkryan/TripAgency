using Application.IReositosy;
using Application.IUnitOfWork;
using DataAccessLayer.Context;
using Domain.Entities.IdentityEntities;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.Seeds;
using Presentation;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services           
            .AddPresentation()
            .AddInfrastructure(Configuration);       
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeeder dataSeeder)
    {
        dataSeeder.SeedDataAsync();

        if (env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseHttpsRedirection();

        // Authentication/Authorization Middleware
        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });
    }
}

