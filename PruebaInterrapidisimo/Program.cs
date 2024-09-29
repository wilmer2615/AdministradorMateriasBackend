using Logic;
using Logic.RegisteredCourseLogic;
using Logic.StudentLogic;
using Logic.TeacherCourseLogic;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repository.RegisteredCourseRepository;
using Repository.Repository.StudenRepository;
using Repository.Repository.TeacherCourseRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion Cors Origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Se realiza la configuracion de la inyección de dependencias.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IRegisteredCourseRepository, RegisteredCourseRepository>();
builder.Services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();


builder.Services.AddScoped<IStudentLogic, StudentLogic>(); 
builder.Services.AddScoped<IRegisteredCorseLogic, RegisteredCourseLogic>();
builder.Services.AddScoped<ITeacherCourseLogic, TeacherCourseLogic>();


//Configuracion conexion a base de datos
builder.Services.AddDbContext<AplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Registra el Middleware de manejo global de errores
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowWebApp");

app.MapControllers();

app.Run();
