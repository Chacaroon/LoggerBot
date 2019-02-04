using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedKernel.DAL.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using TelegramBotApi;
using TelegramLoggingService.IoC;

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
			services.AddDbContext<ApplicationContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddRepositories();

			services.AddServices(Configuration);

			services.AddCommands();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ITelegramBot telegramBot)
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

			telegramBot.SetWebhook(
				Configuration["TelegramBotSettings:WebhookUri"],
				Configuration.GetSection("TelegramBotSettings").GetSection("AllowedUpdates").Get<string[]>());

			app.UseSwagger();

			app.UseMvc();
		}
	}
}
