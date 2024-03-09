
using SistemaCobranza.BusinessInterface;
using SistemaCobranza.BusinessLayer;
using SistemaCobranza.DataInterface;
using SistemaCobranza.DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();          // SE AGREGAN LOS CONTROLADORES, LOS CUALES PERMITIR�N LAS LLAMADAS AL WEB API
builder.Services.AddEndpointsApiExplorer(); //ES CONVENIENTE AL MOMENTO DE QUE SE VISUALICE LA DOCUMENTACI�N, PARA USAR HERRAMIENTAS COMO SWAGGER
builder.Services.AddSwaggerGen();

// INYECCI�N DE DEPENDENCIAS
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IUserRepository,UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) //SI ESTAMOS EN DESARROLLO TE PERMITE VISUALIZAR SWAGGER
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseAuthorization(); //TE ESTAS ASEGURANDO QUE CADA SOLICITUD A LA API PASAR� POR UN PROCESO DE AUTORIZACI�N PARA VALIDAR QUE EL USUARIO TENGA PERMISOS

app.MapControllers(); // PARA DEFINIR LAS RUTAS DE LOS CONTROLADORES

app.Run();