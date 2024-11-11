using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Network;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o Serilog para enviar logs no formato JSON via TCP
Log.Logger = new LoggerConfiguration()
	.Enrich.FromLogContext()
	.MinimumLevel.Debug()
	.WriteTo.TCPSink("tcp://127.0.0.1", 50000, new JsonFormatter()) // Usa o Tcp sink da biblioteca Serilog.Sinks.Network
	.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
