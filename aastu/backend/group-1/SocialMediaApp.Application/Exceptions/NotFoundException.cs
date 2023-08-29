using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message, object key):base($"{message} ({key}) was not found")
    {
        
    }
}
