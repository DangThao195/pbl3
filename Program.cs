using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using PBL3_HK4.Service;

var builder = WebApplication.CreateBuilder(args);

// Thêm DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các service với interface tương ứng
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IBillDetailService, BillDetailService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();


builder.Services.AddHttpContextAccessor();

//// Thêm session (nếu cần)
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/SignIn";
        options.AccessDeniedPath = "/Account/SignIn";
        options.ExpireTimeSpan = TimeSpan.FromHours(24);
    });

// Thêm MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
//// Sử dụng session (nếu đã thêm)
//app.UseSession();

//// Thêm middleware xác thực và phân quyền
//app.UseAuthentication();
//app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();
//// Cấu hình endpoint routing
app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Admin}/{action=Home}/{id?}");

//// Thêm các route khác nếu cần
//app.MapControllerRoute(
//    name: "products",
//    pattern: "products/{catalogId?}",
//    defaults: new { controller = "Product", action = "Index" });

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
