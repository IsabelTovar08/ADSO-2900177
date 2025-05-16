using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Specifics;
using Entity.Context;
using Entity.Models;
using Infrastructure.Notifications.Interfases;
using Microsoft.Extensions.Logging;

namespace Data.Classes
{
    public class Auth : UserData
    {
        private readonly IMessageSender _emailSender;

        public Auth(ApplicationDbContext context, ILogger<User> logger, IMessageSender emailSender) : base(context, logger)
        {
            _emailSender = emailSender;
        }



    }
}
