using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Interfaces;
using RestSharp;

namespace Console.Services
{
    public class WebService : IWebService
    {
        private readonly IAppSettings _appSettings;

        private readonly ILogger _logger;

        private readonly IRestClient _restClient;

        private readonly IRestRequest _restRequest;

        private readonly IUri _uriService;

        public WebService(IRestClient restClient, IRestRequest restRequest, IAppSettings appSettings, IUri uriService, ILogger logger)
        {
            restClient = _restClient;
            restRequest = _restRequest;
            appSettings = _appSettings;
            uriService = _uriService;
            logger = _logger;
        }

        public Class1 Data()
        {
            Class1 data = null;

            _restClient.BaseUrl = _uriService.GetUri("api");

            _restRequest.Resource = "todaysdata";
            _restRequest.Method = Method.GET;

            var response = _restClient.Execute<Class1>(_restRequest);

            if (response != null)
            {
                if (response.Data != null)
                {
                    data = response.Data;
                }
                else
                {
                    var errorMessage = "Error " + " Error message: " + response.ErrorMessage + " Status Code: " + response.StatusCode + " Description: " + response.StatusDescription;

                    if (response.ErrorMessage != null && response.ErrorException != null)
                    {
                        _logger.Error(errorMessage, null, response.ErrorException);
                    }
                    else
                    {
                        _logger.Error(errorMessage, null, new Exception(response.Content));
                    }
                }
            }
            else
            {
                _logger.Error("No response", null, new Exception("No response"));
            }

            return data;
        }
    }
}
