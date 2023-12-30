using Microsoft.AspNetCore.Http;

namespace PulseActiveShop.Web.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication
                .CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Non definisce route specifiche; si occupa solo di abilitare il meccanismo di routing
            // Nelle ultime versioni di ASP.NET, non è necessario invocare esplicitamente il metodo
            // perché viene invocato direttamente da WebApplicationBuilder.
            //app.UseRouting();

            app.UseAuthorization();

            //Specifica effettivamente le route, definendo come gli URL vengono mappati agli endpoint specifici
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // UseEndpoints è un contenitore più ampio per la registrazione di tutti i tipi di endpoint nell'applicazione,
            // inclusi quelli definiti tramite MapControllerRoute. Esempio:
            //app.UseEndpoints(endpoints =>
            //{
            //    // Mappatura delle route per i controller
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");

            //    // Mappatura delle Razor Pages
            //    endpoints.MapRazorPages();

            //    // Puoi anche aggiungere altre configurazioni di routing qui
            //    // Ad esempio, per un'API o SignalR
            //});

            app.Run();
        }
    }
}

