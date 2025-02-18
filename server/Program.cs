using Npgsql;
using server;

var builder = WebApplication.CreateBuilder(args);

Database database = new();

var db = database.Connection();

builder.Services.AddSingleton<NpgsqlDataSource>(db);

var app = builder.Build();
app.MapGet("/api/companies", CompanyRoutes.GetCompanies);
app.MapGet("/api/companies/{email}", CompanyRoutes.GetCompany);
app.MapPost("/api/companies", CompanyRoutes.AddCompany);
app.MapPut("/api/companies/{previousEmail}", CompanyRoutes.EditCompany);
app.MapPut("/api/companies/block/{email}/{active}", CompanyRoutes.BlockCompany);
app.MapGet("/api/users/{role}", UserRoutes.GetUsers);
app.MapGet("/api/users/company/{role}/{company}", UserRoutes.GetUsersFromCompany);
app.MapGet("/api/users/{role}/{email}", UserRoutes.GetUser);
app.MapPut("/api/users/block/{email}/{active}", UserRoutes.BlockUser);
app.MapPost("/api/users/{role}", UserRoutes.AddUser);
app.MapGet("/api/products/{company}", ProductRoutes.GetProducts);
app.MapPost("/api/products", ProductRoutes.AddProduct);
app.MapPut("/api/users/{role}/{previousEmail}", UserRoutes.EditUser);
//app.MapPost("/api/create-user", UserRoutes.AddUser);


//var serverActions  = new ServerActions(app);

app.Run();
