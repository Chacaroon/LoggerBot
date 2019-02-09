using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TelegramBotApi;
using TelegramLoggingService.AutoMapper;

namespace TelegramLoggingService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		private global::AutoMapper.Configuration.MapperConfigurationExpression _cfg =
			new global::AutoMapper.Configuration.MapperConfigurationExpression();

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddServices();

			services.AddCommands();

			services.AddHttpClient<ITelegramBot, TelegramBot>(configureClient =>
			{
				configureClient.BaseAddress = new Uri(String.Format("https://api.telegram.org/bot{0}/", Configuration["TelegramBotSettings:BotToken"]));
			});

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

			Bootstrapper.Bootstrap(_cfg);
			Mapper.Initialize(_cfg);

			telegramBot.SetWebhook(
				Configuration["TelegramBotSettings:WebhookUri"],
				Configuration.GetSection("TelegramBotSettings").GetSection("AllowedUpdates").Get<string[]>());

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseMvc();
		}
	}
}
