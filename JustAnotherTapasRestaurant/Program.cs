using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JustAnotherTapasRestaurant.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<JustAnotherTapasRestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JustAnotherTapasRestaurantContext") ?? throw new InvalidOperationException("Connection string 'JustAnotherTapasRestaurantContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<JustAnotherTapasRestaurantContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(

	options =>
	{
		options.Stores.MaxLengthForKeys = 128;
	})
	// Operates on database and gives default ui, token providers and roles
	.AddEntityFrameworkStores<JustAnotherTapasRestaurantContext>()
	.AddRoles<IdentityRole>()
	.AddDefaultUI()
	.AddDefaultTokenProviders();


// Includes error information for migration errors
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Adds admin page admin authorization
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("RequireAdmins", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
	options.Conventions.AuthorizeFolder("/Admin", "RequireAdmins");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// Includes error informtion for migration errors
else
{
	app.UseDeveloperExceptionPage();
	app.UseMigrationsEndPoint();
}

// Ensures that the database is created if a database doesnt exist
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<JustAnotherTapasRestaurantContext>();
	context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope()) 
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<JustAnotherTapasRestaurantContext>();
	context.Database.Migrate();
	var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
	var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
	IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}

app.Run();
