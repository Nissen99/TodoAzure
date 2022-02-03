using Blazored.Modal;
using TodoBlazor.Model;
using TodoNetworkClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddBlazoredModal();

builder.Services.AddScoped<ILoginNetwork, LoginRESTClient>();
builder.Services.AddScoped<ITodoNetwork, TodoRESTClient>();
builder.Services.AddScoped<IUserNetwork, UserRESTClient>();

builder.Services.AddScoped<ITodoModel, TodoModel>();
builder.Services.AddScoped<IUserModel, UserModel>();
builder.Services.AddScoped<ILoginModel, LoginModel>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();