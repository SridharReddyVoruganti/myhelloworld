using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyHelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ValuesController(IDataService dataService)
        {
            dataService = _dataService;
        }

        public Class1 GetData()
        {
            return _dataService.GetData();
        }
    }
}
