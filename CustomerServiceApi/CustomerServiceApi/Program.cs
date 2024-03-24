using CustomerServiceApi.Repository.Implementation;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Service.Implementation;
using CustomerServiceApi.Service.Interface;
using CustomerServiceApi.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HabitTracker.Service.ServiceInterface;
using HabitTracker.Service.ServiceImplementation;
using HabitTracker.Repository.RepositoryImplementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IWhoAreUService, WhoAreUService>();
builder.Services.AddScoped<IWhoAreURepository, WhoAreURepository>();


string secretKey = builder.Configuration.GetSection("JwtSettings:SecretKey").Value;
builder.Services.AddSingleton(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            // ValidIssuer = "petar", 
            // ValidAudience = "habit", 
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddCors(o => o.AddPolicy("AllowAll", b =>
{
    b.AllowAnyHeader();
    b.AllowAnyMethod();
    b.SetIsOriginAllowed(isOriginAllowed: _ => true);
    b.AllowCredentials();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextData>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
    options.EnableSensitiveDataLogging();
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DbContextData>();

    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll")
    .UseHttpsRedirection()
    .UseRouting();

app.Services.CreateScope().ServiceProvider.GetRequiredService<DbContextData>().Database.EnsureCreated();


app.UseHttpsRedirection();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
