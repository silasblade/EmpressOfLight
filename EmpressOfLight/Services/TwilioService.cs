using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EmpressOfLight.Services
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _twilioPhoneNumber;

        public TwilioService(IConfiguration configuration)
        {
            
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _twilioPhoneNumber = configuration["Twilio:PhoneNumber"];
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSms(string toPhoneNumber, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(_twilioPhoneNumber), // Sử dụng số điện thoại Twilio từ cấu hình
                Body = message
            };

            MessageResource.Create(messageOptions);
        }
    }
}

