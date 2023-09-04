using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        public Task SendEmail(Email email);
    }
}
