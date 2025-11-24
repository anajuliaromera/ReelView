using Microsoft.EntityFrameworkCore;
using ReelView.Infrastructure.Data;
using ReelView.Infrastructure.Repositories;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;
using ReelView.Api.Service;
using ReelView.Infrastructure.Clients; // NOVO: Para usar o TMDBClient
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ========== BANCO DE DADOS ==========
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ========== CONFIGURAÇÃO DO CLIENTE HTTP EXTERNO (TMDB) ==========
// 1. Injeção da Interface IMediaExternalService (o Contrato)
// 2. Implementação com a classe TMDBClient
// 3. Configuração da URL Base lida do appsettings.json
builder.Services.AddHttpClient<IMediaExternalService, TMDBClient>(client =>
{
    // Define a URL base para todas as chamadas deste cliente
    client.BaseAddress = new Uri(builder.Configuration["TMDB:BaseUrl"]
        ?? throw new ArgumentNullException("TMDB:BaseUrl não configurada em appsettings.json."));
});


// ========== REPOSITÓRIOS (Injeção de Dependência) ==========
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IMidiaRepository, MidiaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IFavoritoRepository, FavoritoRepository>();
builder.Services.AddScoped<IRankingRepository, RankingRepository>();

// ========== SERVIÇOS (Injeção de Dependência) ==========
builder.Services.AddScoped<IMidiaService, MidiaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IFavoritoService, FavoritoService>();
builder.Services.AddScoped<IRankingService, RankingService>();

// ========== CONFIGURAÇÕES GERAIS ==========
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ========== SWAGGER/JWT (Configuração da Autenticação e Documentação) ==========
var jwtKey = builder.Configuration["Jwt:Key"] ?? "chave_secreta_padrao_123456789";
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReelView API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// ========== PIPELINE ==========
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();