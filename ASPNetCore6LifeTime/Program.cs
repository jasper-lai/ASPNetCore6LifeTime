using ASPNetCore6LifeTime.Interfaces;
using ASPNetCore6LifeTime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ���U (register) 3 �Ӥ�������@, �� using �������R�W�Ŷ�
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
