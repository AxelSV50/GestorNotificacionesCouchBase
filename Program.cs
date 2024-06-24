using Couchbase.Extensions.DependencyInjection;
using GestorNotificaciones;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<Utils>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var couchbaseConfig = builder.Configuration.GetSection("Couchbase");

// Configurar Couchbase
builder.Services.AddCouchbase(options =>
{
    options.ConnectionString = couchbaseConfig["ConnectionString"];
    options.UserName = couchbaseConfig["Username"];
    options.Password = couchbaseConfig["Password"];
});

builder.Services.AddCouchbaseBucket<INotificationBucketProvider>(couchbaseConfig["Buckets:EstudiantesBucket"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
