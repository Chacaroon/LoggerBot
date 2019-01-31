using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TelegramLoggingService.IoC;
using TelegramLoggingService.WebhookConfig;

namespace TelegramLoggingService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRepositories();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddHttpClient("TelegramClient", configureClient =>
			{
				configureClient.BaseAddress = new Uri("https://api.telegram.org/bot{settings.BotToken}/");
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			WebhookConfigurator.Configure(new WebhookSettings(
				Configuration["TelegramBotSettings:BotToken"].ToString(),
				Configuration["TelegramBotSettings:WebhookUri"].ToString()));

			app.UseMvc();
		}
	}
}
