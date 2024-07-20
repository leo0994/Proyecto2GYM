using DTOs;
using DAO;
using System;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using System.Threading.Tasks;

namespace BL.Managers
{
     public class AuthSendCodeUser
    {
        public static async Task<VerificationResource> send(UserDTO user) {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "aaa";
            string authToken = "bbb";

            TwilioClient.Init(accountSid, authToken);

            return await VerificationResource.CreateAsync(
                to: "+506" + user.Number,
                channel: "sms",
                pathServiceSid: "ccc"
                );
        }

        public static async Task<VerificationCheckResource> verify(UserDTO user, string userCode){
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
             string accountSid = "aaa";
            string authToken = "bbb";


            TwilioClient.Init(accountSid, authToken);

             return await VerificationCheckResource.CreateAsync(
                to: "+506" + user.Number,
                code: userCode,
                pathServiceSid: "ccc");
        }
    }
}
