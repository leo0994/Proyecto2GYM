using DTOs;
using DAO;
using System;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using System.Threading.Tasks;

namespace BL.TwilioManager
{
     public class AuthSendCodeUser
    {
        public static async Task<VerificationResource> send(UserDTO user) {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "x";
            string authToken = "x";

            TwilioClient.Init(accountSid, authToken);

            return await VerificationResource.CreateAsync(
                to: user.Number,
                channel: "sms",
                pathServiceSid: "x"
                );
        }

        public static async Task<VerificationCheckResource> verify(UserDTO user, string userCode){
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "x";
            string authToken = "x";

            TwilioClient.Init(accountSid, authToken);

             return await VerificationCheckResource.CreateAsync(
                to: user.Number,
                code: userCode,
                pathServiceSid: "x");
        }
    }
}
