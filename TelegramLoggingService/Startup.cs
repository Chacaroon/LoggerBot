using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BLL.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
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
			IntegrateSimpleInjector(services);

			Bootstrapper.Bootstrap(container);

			AddDbContext(services);

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

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
			container.Options.AllowOverridingRegistrations = true;

			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(container));
			services.AddSingleton<IViewComponentActivator>(
				new SimpleInjectorViewComponentActivator(container));

			services.AddHttpContextAccessor();
			services.AddHttpClient<ITelegramBot, TelegramBot>(configureClient =>
			{
				configureClient.BaseAddress = new Uri(Configuration["TelegramBotSettings:ApiUri"]);
			});

			services.EnableSimpleInjectorCrossWiring(container);
			services.UseSimpleInjectorAspNetRequestScoping(container);
		}

		private void AddDbContext(IServiceCollection services)
		{
			var AddDbContext = typeof(EntityFrameworkServiceCollectionExtensions)
				.GetMethod("AddDbContext", 1, 
				new Type[] 
				{
					typeof(IServiceCollection),
					typeof(Action<DbContextOptionsBuilder>),
					typeof(ServiceLifetime),
					typeof(ServiceLifetime)
				});

			var applicationContextType = Assembly
				.Load("DAL")
				.GetTypes()
				.Where(t => t.IsSubclassOf(typeof(DbContext)))
				.Single();

			AddDbContext
				.MakeGenericMethod(applicationContextType)
				.Invoke(services, new object[]
				{
					services,
					(Action<DbContextOptionsBuilder>)(options =>
						options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))),
					ServiceLifetime.Scoped,
					ServiceLifetime.Scoped
				});
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			// Add application presentation components:
			container.RegisterMvcControllers(app);
			container.RegisterMvcViewComponents(app);

			// Allow Simple Injector to resolve services from ASP.NET Core.
			container.AutoCrossWireAspNetComponents(app);
		}
	}
}
