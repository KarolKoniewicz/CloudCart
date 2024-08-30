using Hangfire;
using Ebiscon.CloudCart.Domain.Constants;
using Ebiscon.CloudCart.Domain.Extensions;
using STI.Workers;
using Ebiscon.CloudCart.Workers.Workers.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHangfire((sp, conf) =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()
                             .GetConnectionString(WorkerConstants.HangfireConnectionString);

    conf.UseSqlServerStorage(connectionString);
});

builder.Services.AddWorkerService();
builder.Services.AddHangfireServer();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Services.ScheduleRecurringJob<ProductSyncWorker, ProductSyncWorkerConfiguration>();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    _ = endpoints.MapGet("/", async context =>
    {
        context.Response.Redirect("/dashboard");
    });

    _ = endpoints.MapHangfireDashboard("/dashboard",
        new DashboardOptions
        {
            DashboardTitle = "Job Dashboard",
            DarkModeEnabled = true,
            DefaultRecordsPerPage = 50,
        });

});

app.Run();
