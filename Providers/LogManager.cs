using log4net;
using log4net.Config;
using MailBox.Web.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MailBox.Web.Providers
{
    public interface ILoggerManager
    {
        void LogInformation(string message);
        void LogInfoFormat(string format, object arg0, object arg1, object arg2);
        void LogError(Exception ex);
    }

    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
        private IConfiguration _config;
        public LoggerManager(IConfiguration config)
        {
            _config = config;

            switch (_config["log4net:LogType"])
            {
                case "file":
                    XmlDocument log4netConfig = new XmlDocument();
                    using (var fs = File.OpenRead("log4netfile.config"))
                    {
                        log4netConfig.Load(fs);
                        var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                        XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                    }
                    try
                    {
                        _logger.Info("Log System Initialized");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error: Log System Failed. ", ex);
                    }

                    break;

                case "database":
                    XmlDocument log4netConfig2 = new XmlDocument();
                    using (var fs = File.OpenRead("log4netdb.config"))
                    {
                        log4netConfig2.Load(fs);
                        var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                        XmlConfigurator.Configure(repo, log4netConfig2["log4net"]);
                    }
                    try
                    {
                        _logger.Info("Log System Initialized");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error: Log System Failed. ", ex);
                    }
                    break;
            }
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
            
        }

        public void LogInfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.InfoFormat(format, arg0, arg1, arg2);
        }

        public void LogError(Exception ex)
        {
            _logger.Error(ex);
        }
    }
}
