using IdentitySample.Entities;
using IdentitySample.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// var connectionString = builder.Configuration.GetConnectionString("SampleIdentityContextConnection");builder.Services.AddDbContext<SampleIdentityContext>(options =>
//     options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<SampleIdentityContext>();


//added DBContext
builder.Services.AddDbContext<sampleDbContext>(options => 
    options.UseMySql("server=localhost;database=sampleDb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb")));

// builder.Services.AddDbContext<SampleIdentityContext>(options => 
// options.UseMySql("server=localhost;database=sampleDb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb")));

builder.Services.AddIdentity<AppUser, AppRole>(option => {
        option.SignIn.RequireConfirmedAccount = false;
        option.SignIn.RequireConfirmedEmail = false;
        option.SignIn.RequireConfirmedPhoneNumber = false;
        option.User.RequireUniqueEmail = true;
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = false;
        option.Password.RequiredUniqueChars = 0;
        option.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<SampleIdentityContext>();

    builder.Services.ConfigureApplicationCookie(option => {
        option.LoginPath = "/Account/Login";
        option.AccessDeniedPath = "/Account/Login";
    });

builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
