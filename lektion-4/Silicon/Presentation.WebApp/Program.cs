var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// H�r kommer jag b�rja g�ra saker






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
