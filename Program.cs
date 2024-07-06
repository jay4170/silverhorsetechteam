using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Identity.Web;
using silverhorse.Business_Logic;
using System.Net.Http.Headers;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using silverhorse.Dtos;

var builder = WebApplication.CreateBuilder(args);

var authenticationBuilder = builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

authenticationBuilder.AddJwtBearer(options =>
{
    // Set up the token validation parameters
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false,
        SignatureValidator = (token, parameters) =>
        {
            if (token == "af24353tdsfw")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "TestUser") };
                var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                return new CustomSecurityToken(principal);
            }
            throw new SecurityTokenException("Invalid token");
        }
    };

    // Configure additional events if needed for further debugging
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader?.StartsWith("Bearer ") == true)
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();
                if (token == "af24353tdsfw")
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, "TestUser") };
                    var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    context.Principal = principal;
                    context.Success(); // Signal successful authentication
                    return Task.CompletedTask;
                }
                            throw new NotImplementedException(); // Throw NotImplementedException instead of SecurityTokenException

            }
            return Task.CompletedTask;
        },
      
    };

});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient with configuration
builder.Services.AddHttpClient<Posts>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient<Users>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient<Albums>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient<CollectionService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddScoped<CollectionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
