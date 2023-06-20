using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDAL, EFStaffDAL>();
builder.Services.AddScoped<IStaffService, StaffManager>();
 
builder.Services.AddScoped<IRoomDAL, EFRoomDAL>();
builder.Services.AddScoped<IRoomService, RoomManager>();
 
builder.Services.AddScoped<IServiceDAL, EFServiceDAL>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
 
builder.Services.AddScoped<ISubscribeDAL, EFSubscribeDAL>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
 
builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HoTelAPICors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelAPICors");
app.UseAuthorization();

app.MapControllers();

app.Run();