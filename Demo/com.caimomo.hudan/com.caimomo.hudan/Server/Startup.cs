using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using com.caimomo.Dapper.Base;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace com.caimomo.hudan.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            var config = new DapperConfig();
            var dbtype = _configuration["DbType"];
            string strDbType;
            if (dbtype.Equals("sqlite", StringComparison.CurrentCultureIgnoreCase))
            {
                // sqlite
                config.DataBaseType = RepositoryBaseType.Sqlite;
                var sqlitedb = _configuration["SqliteFolder"];
                var sql = _configuration.GetConnectionString("SqliteConnection");
                string rootdir = AppContext.BaseDirectory;
                DirectoryInfo diInfo = Directory.GetParent(rootdir);
                string root = Path.Combine(diInfo.Parent.Parent.FullName, sqlitedb);
                sql = sql.Replace("Data Source=", $"Data Source={root}\\");
                config.DbConnection = new SQLiteConnection(sql);
            }
            else
            {
                // sqlserver
                config.DataBaseType = RepositoryBaseType.Sqlserver;
                config.DbConnection = new SQLiteConnection(_configuration["SqlServerConnection"]);
            }
           
            services.AddSingleton(config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }
            
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            // nlog
            app.UseStaticFiles();
            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog(Directory.GetCurrentDirectory() + @"/nlog.config");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
