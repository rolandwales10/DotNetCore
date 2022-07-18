using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Serilog.AspNetCore;
using mdl = FarmshareAdmin.Models;
using Data = FarmshareAdmin.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Server.MapPath replacement:
    string path = Path.GetDirectoryName(builder.Environment.WebRootPath);
 */

var Environment = builder.Configuration.GetValue<string>("Environment");
var LoggingPath = builder.Configuration.GetValue<string>("LoggingPath");
var logFile = LoggingPath + "/" + Environment + "/log.txt"; 
var logger = new LoggerConfiguration()
   .WriteTo.File(logFile, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddDbContext<mdl.ACF_FarmshareContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ACF_Farmshare")));

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();

builder.Services.AddScoped<Data.icRawSql, Data.RawSqlServices>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.MapGet("/api/cars", () =>
{
    List<Data.Message> msgs = new();
    msgs.Add(new Data.Message { status = "warning", content = "msg" });
    return Results.Ok(msgs);
});

app.Run();
