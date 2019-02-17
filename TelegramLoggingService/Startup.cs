using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
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
		private Container container = new Container();

		private AutoMapper.Configuration.MapperConfigurationExpression _cfg =
			new AutoMapper.Configuration.MapperConfigurationExpression();

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpClient<ITelegramBot, TelegramBot>(configureClient =>
			{
				configureClient.BaseAddress = new Uri(Configuration["TelegramBotSettings:ApiUri"]);
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});

			IntegrateSimpleInjector(services);
		}

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(container));
			services.AddSingleton<IViewComponentActivator>(
				new SimpleInjectorViewComponentActivator(container));

			services.EnableSimpleInjectorCrossWiring(container);
			services.UseSimpleInjectorAspNetRequestScoping(container);
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

			IoC.MapperBootstrapper.Bootstrap(_cfg);
			Mapper.Initialize(_cfg);
			InitializeContainer(app);

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

		private void InitializeContainer(IApplicationBuilder app)
		{
			// Add application presentation components:
			container.RegisterMvcControllers(app);
			container.RegisterMvcViewComponents(app);

			// Add custom services:
			Bootstrapper.Bootstrap(container);

			// Allow Simple Injector to resolve services from ASP.NET Core.
			container.AutoCrossWireAspNetComponents(app);
		}
	}
}
