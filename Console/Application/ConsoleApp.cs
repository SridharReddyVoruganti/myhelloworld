using Console.Services;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console.Application
{
    public class ConsoleApp
    {
        public interface IConsoleApp
        {
            void Run(string[] arguments);
        }

        private readonly IWebService _webService;
        private readonly ILogger _logger;

        public ConsoleApp(IWebService webService, ILogger logger)
        {
            webService = _webService;
            logger = _logger;
        }

        public void Run(string[] arguments)
        {
            var data = _webService.Data();
            _logger.Info(data != null ? data.Data : "null", null);
        }
    }
}
