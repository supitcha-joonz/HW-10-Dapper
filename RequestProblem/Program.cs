using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RequestProblem.Repositories;
using RequestProblem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register dependency injection Problems
//builder.Services.AddTransient<IProblemsRepository, ProblemsRepository>();
//builder.Services.AddTransient<IProblemsService, ProblemsService>();

//register autofac

//Now register our services with Autofac container// Call UseServiceProviderFactory on the Host sub property
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Call ConfigureContainer on the Host sub property
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>{    
    var serviceAssembly = typeof(ProblemsService).Assembly;    
    builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.Name.EndsWith("Service"))    
    .AsImplementedInterfaces()    
    .SingleInstance();   

    var repositoryAssembly = typeof(ProblemsRepository).Assembly;    
    builder.RegisterAssemblyTypes(repositoryAssembly).Where(t => t.Name.EndsWith("Repository"))    
    .AsImplementedInterfaces()    
    .SingleInstance();});



builder.Services.AddTransient<IApplicationsRepository, ApplicationsRepository>();
builder.Services.AddTransient<IApplicationsService, ApplicationsService>();

builder.Services.AddDbContext<ProblemMgmtContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
