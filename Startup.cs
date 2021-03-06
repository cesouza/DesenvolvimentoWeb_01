﻿using Fiap01.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

       
        var connection =
            @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

        services.AddDbContext<PerguntasContext>(o => o.UseSqlServer(connection));
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {

        if(env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseStaticFiles();

     
        app.UseMvc(routes => {
            routes.MapRoute(
                  name: "autor",
                  template: "autor/{nome}",
                  defaults: new { controller = "Autor", action = "Index" });

            routes.MapRoute(
                 name: "autoresDoAno",
                 template: "{ano:int}/autor",
                 defaults: new { controller = "Autor", action = "ListaDosAutoresDoAno" });

            routes.MapRoute(
                name: "topicosDaCategoria",
                template: "{categoria}/{topico}",
                defaults: new { controller = "Topico", action = "Index" });

            routes.MapRoute(
               name: "default",
               template: "{controller=home}/{action=Index}/{id?}");
              
        });
    }
}
