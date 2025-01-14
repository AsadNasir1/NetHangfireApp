using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetHangfireDB;
using System;
using Hangfire;
using Hangfire.Storage.SQLite;
using System.Configuration;
using NetHangfireApp.Hub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NetHangfireDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSQLiteStorage(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddHangfireServer();

builder.Services.AddSignalR();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));

// Add DatabaseSeeder as a transient service
builder.Services.AddTransient<DatabaseSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<NetHangfireDBContext>();
        dbContext.Database.Migrate(); // Automatically apply migrations
        var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
        seeder.SeedTestData();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();
app.MapHub<UsersHub>("/newUser");
app.UseHangfireDashboard();

app.Run();