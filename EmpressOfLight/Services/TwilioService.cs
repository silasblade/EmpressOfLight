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

/*
class Example
{
    static void Main(string[] args)
    {
        var accountSid = "ACf2763a766b647b733aec3a5607eb9e37";
        var authToken = "[AuthToken]";
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(
          new PhoneNumber("+18777804236"));
        messageOptions.From = new PhoneNumber("+19547168508");
        messageOptions.Body = "hi";


        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Body);
    }
}
*/