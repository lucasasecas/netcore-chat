using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetcoreChat.Domain.Entities;
using NetcoreChat.Hubs;
using NetcoreChat.Infrastructure.Data;
using NetcoreChat.Infrastructure.Data.Repositories;
using NetcoreChat.Services;

namespace NetcoreChat
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
            services.AddCors(builder =>
                builder.AddPolicy("AllowsAll", config => 
                    config.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:8080")));

            AddRepositories(services);
            services.AddTransient<UserService>();
            services.AddTransient<IChannelService, ChannelService>();

            services.AddSignalR();
            services.AddMvc();

            services.AddTransient<IRoomService, RoomService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseMvc();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ChatDbContext>();
            services.AddTransient<IRepository<Channel>, ChannelRepository>();
        }
    }
}
