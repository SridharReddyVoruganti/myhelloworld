using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataServices
{
    public class DataService : IDataService
    {
        public DataService()
        {

        }

        public Class1 GetData()
        {
            var data = "Hello World";

            var response = new Class1 { Data = data };

            return response;
        }
    }
}
