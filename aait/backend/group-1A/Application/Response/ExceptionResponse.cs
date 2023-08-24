using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ExceptionResponseModel
    {
        public bool Success { get; set; } = false;

        public string Message { get; set; } = "";
    }
}