var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt =>
{
	opt.IdleTimeout = TimeSpan.FromHours(10);
});


builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = "MyCookie";
	opt.DefaultChallengeScheme = "MyCookie";
}).AddCookie("MyCookie", opt =>
{
	opt.LoginPath = "/Auth/Login";
	opt.AccessDeniedPath = "/Auth/Fobidden";
});

builder.Services.AddAuthorization(opt =>
{
	opt.AddPolicy("Policy1", p =>
	{
		p.RequireClaim("Role", "Admin");
	});
});


var app = builder.Build();



// Start Of PipeLine
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// HTTP => HTTPS 
	app.UseHsts();
}






app.UseHttpsRedirection();

// Site.js
app.UseStaticFiles();

app.UseRouting();


// Access Request cookie (Session Id)
// data from Session Save Session Object 
app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
