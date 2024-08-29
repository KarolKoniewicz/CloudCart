using Hangfire;
using Ebiscon.CloudCart.Domain.Constants;
using Ebiscon.CloudCart.Domain.Extensions;
using STI.Workers;
using Ebiscon.CloudCart.Workers.Workers.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

builder.Services.AddHangfire((sp, conf) =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()
                             .GetConnectionString(WorkerConstants.HangfireConnectionString);

    conf.UseSqlServerStorage(connectionString);
});

builder.Services.AddWorkerService();
builder.Services.AddHangfireServer();

app.Services.ScheduleRecurringJob<ProductSyncWorker, ProductSyncWorkerConfiguration>();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
