using FilaZeroApi.Data;
using FilaZeroApi.models;
using FilaZeroApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FilaZeroDBContext>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("v1/listarAgencias", (FilaZeroDBContext dbcontext) =>
{
    var agen = dbcontext.Agencias.ToList();
    return Results.Ok(agen);
}).Produces<Agencia>();



app.MapPost("v1/criarAgencia", (
    FilaZeroDBContext dbcontext,
    CreateAgenciaViewModel model) =>
{
    var agencia = model.MapTo();
    if (model.IsValid)
    {
        dbcontext.Agencias.Add(agencia);
        dbcontext.SaveChanges();

        return Results.Created($"/v1/todos/{agencia.Id}", agencia);
    }
    else
    {
        return Results.BadRequest(model.Notifications);

    }

}).Produces<CreateAgenciaViewModel>();

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
