using Microsoft.EntityFrameworkCore;
using MyGames.Data.Database;
using MyGames.Data.Database.Models;
using MyGames.Services.BacklogService;
using MyGames.Services.RawgService;

var builder = WebApplication.CreateBuilder(args);


// DB

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IRawgService, RawgService>();
builder.Services.AddScoped<IBacklogService, BacklogService>();

var app = builder.Build();

// test user
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if(!db.Users.Any())
    {
        db.Users.Add(new User
        {
            UserName = "test",
            Email = "test@gmail.com",
            Password = "test",
            DateRegistered = DateTime.UtcNow
        });
        db.SaveChanges();
    }
}





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
