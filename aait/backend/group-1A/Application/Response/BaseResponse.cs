using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; } = false;

        public string Message { get; set; } = "";

        public T? Value { get; set; }       
    }
}