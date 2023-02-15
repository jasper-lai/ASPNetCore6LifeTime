using ASPNetCore6LifeTime.Interfaces;
using ASPNetCore6LifeTime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 註冊 (register) 3 個介面的實作, 並 using 相關的命名空間
builder.Services.AddTransient<ITransientService, SampleService>();
builder.Services.AddScoped<IScopedService, SampleService>();
builder.Services.AddSingleton<ISingletonService, SampleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
