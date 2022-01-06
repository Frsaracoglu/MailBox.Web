using Hangfire;
using log4net;
using MailBox.Web.Models;
using MailBox.Web.Providers;
using MailBoxBackgroundJob.Schedules;
using MailBoxEntity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace MailBox.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddHangfire(x => x.UseSqlServerStorage("Server =.; Database = HangfireMailBox; Trusted_Connection = True; MultipleActiveResultSets = true"));
            services.AddHangfireServer();
            services.AddOptions();
            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromMinutes(30));
            services.Configure<SmtpConfigDto>(Configuration.GetSection("SmtpConfig"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });

            services.Configure<LogTypeDto>(Configuration.GetSection("log4net"));
           
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped(factory => LogManager.GetLogger(GetType()));
            services.AddMvc();

            #region LoggingSection

            ////appsettings.json dosyas�nda bulunan Logging ayarlar� olarak hangi seviyede loglama yap�laca��n� bildiriyor ve sonradan ekledi�imiz
            ////FilePrefix, LogDirectory, FileSizeLimit alanlar�n� da manuel olarak ayar dosyas�ndan �ekerek gerekli atamalar� yap�yoruz
            ////B�ylece bu ayarlar� de�i�tirmek i�in projeyi yeniden deploy etmemiz gerekmeyecek. Runtime da bu de�i�iklikleri yapabilece�iz.
            //services.AddLogging(builder => builder.AddFile(options => {
            //    options.FileName = Configuration["Logging:Options:FilePrefix"]; // Log dosyas�n�n isminin nas�l ba�layaca��n� belirtiyoruz
            //    options.LogDirectory = Configuration["Logging:Options:LogDirectory"]; // Log dosyalar� hangi klas�re yaz�lacak
            //    options.FileSizeLimit = int.Parse(Configuration["Logging:Options:FileSizeLimit"]); // Maksimum log dosya boyutu ne kadar olacak, byte �zerinden hesaplan�r. (appsettings.json dosyas�nda bu de�er 20971520 olarak belirledik. Bu de�er 20 megabyte �n byte halidir.)
            //}));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //loggerFactory.AddLog4Net();

            app.UseSession();
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });

            // Tan�mlanan zaman diliminde s�rekli �al��t��� i�in tetiklenmesine gerek yok, burada tan�mlayabiliriz. 
            User user = new();
            var birthday = user.Birthday;
            RecurringJobs.SendMailBirthdayJobs(birthday);

            MailMessageDto mailMessageDto = new();
            RecurringJobs.SendDailyRecurringJobs(mailMessageDto);
            RecurringJobs.SendWeeklyRecurringJobs(mailMessageDto);
            RecurringJobs.SendMonthlyRecurringJobs(mailMessageDto);
        }
    }
}
