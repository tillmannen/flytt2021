using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using flytt2021.Areas.Identity;
using flytt2021.Data.Database;
using flytt2021.Data.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using flytt2021.Account;

namespace flytt2021;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("IdentityConnection")));
        services.AddDbContext<FlyttDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddDefaultIdentity<FlyttUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddTransient<MoveService>();
        services.AddTransient<MovingboxService>();
        services.AddTransient<UserService>();

        services.AddScoped<IUserClaimsPrincipalFactory<FlyttUser>, AdditionalUserClaimsPrincipalFactory>();
        services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<FlyttUser>>();

        services.AddTransient<IEmailSender, EmailSender>();
        services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("SendGrid"));
        services.Configure<Data.AzureKeyVaultSettings>(Configuration.GetSection("AzureKeyVault"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FlyttDbContext dbContext)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        dbContext.Database.Migrate();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}