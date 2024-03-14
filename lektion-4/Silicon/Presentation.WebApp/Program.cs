var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Här kommer jag börja göra saker






var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=SignUp}/{id?}");

app.Run();
