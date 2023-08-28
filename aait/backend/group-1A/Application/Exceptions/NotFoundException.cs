using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //public ExceptionResponseModel payload { get; set; }
        public NotFoundException(string message) : base(message) { }
       
    }
}
