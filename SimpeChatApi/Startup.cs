using Microsoft.EntityFrameworkCore;
using SimpeChatApi.Controllers;
using SimpleChatApi.Data.Data;
using SimpleChatApi.Data.Repositories;
using SimpleChatApi.Data.Repositories.Interfaces;
using SimpleChatApi.Logic.Services;
using SimpleChatApi.Logic.Services.Interfaces;

namespace SimpeChatApi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChatApiContext>();

            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ICrud, MessageService>();

            services.AddControllers();
            services.AddSignalR();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatApp v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }

    }
}
