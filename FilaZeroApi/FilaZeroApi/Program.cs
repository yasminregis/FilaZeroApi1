using FilaZeroApi.Data;
using FilaZeroApi.models;
using FilaZeroApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FilaZeroDBContext>();
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("v1/listarAgencias", (FilaZeroDBContext dbcontext) =>
{
    var agen = dbcontext.Agencias.ToList();
    return Results.Ok(agen);
}).Produces<Agencia>();

app.MapGet("v1/Agencia/{agenciaId}", (FilaZeroDBContext dbcontext, Guid agenciaId) =>
{
    var agen = dbcontext.Agencias.FirstOrDefault(x  => x.Id == agenciaId);
    if(agen == null)
           return Results.NotFound();
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

app.MapPost("v1/criarAgenciaCapacidade", (
    FilaZeroDBContext dbcontext,
    CreateAgenciaCapacidadeViewModel model) =>
{
    var agencia = model.MapTo();
    if (model.IsValid)
    {
        dbcontext.agenciasCapacidade.Add(agencia);
        dbcontext.SaveChanges();

        return Results.Ok(agencia);
    }
    else
    {
        return Results.BadRequest(model.Notifications);

    }

}).Produces<CreateAgenciaViewModel>();


app.MapGet("v1/AgenciaCapacidade/{agenciaCapacidadeId}", (FilaZeroDBContext dbcontext, Guid agenciaCapacidadeId) =>
{
    var agen = dbcontext.agenciasCapacidade.FirstOrDefault(x => x.id == agenciaCapacidadeId);
    if (agen == null)
        return Results.NotFound();
    return Results.Ok(agen);

}).Produces<AgenciaCapacidade>();

app.MapGet("v1/AgenciaCapacidades", (FilaZeroDBContext dbcontext) =>
{
    var agencia = dbcontext.agenciasCapacidade.ToList();
    if (agencia == null)
        return Results.NotFound();
    return Results.Ok(agencia);

}).Produces<AgenciaCapacidade>();

app.MapPut("v1/atualizarAgenciaCapacidade", (
    FilaZeroDBContext dbcontext,
    CreateAgenciaCapacidadeViewModel model) =>
{
    var agencia = model.MapTo();
    var agenciaCapacidadeAtual = dbcontext.agenciasCapacidade.FirstOrDefault(x => x.id == agencia.id);
    var todos = dbcontext.agenciasCapacidade.ToList();
    if (agenciaCapacidadeAtual == null)
    {
        return Results.NotFound();
    }
    try
    {
        agenciaCapacidadeAtual.id = agencia.id;
        agenciaCapacidadeAtual.agenciaId = agencia.agenciaId;
        agenciaCapacidadeAtual.HorarioFechamento = agencia.HorarioFechamento;
        agenciaCapacidadeAtual.HorarioAbertura = agencia.HorarioAbertura;
        agenciaCapacidadeAtual.lotacao = agencia.lotacao;
        agenciaCapacidadeAtual.quantidadeFichas = agencia.quantidadeFichas;

        dbcontext.agenciasCapacidade.Update(agenciaCapacidadeAtual);
        dbcontext.SaveChanges();
    }
    catch (Exception)
    {

        throw;
    }
    return Results.Ok(agenciaCapacidadeAtual);
    

}).Produces<CreateAgenciaCapacidadeViewModel>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.Run();
