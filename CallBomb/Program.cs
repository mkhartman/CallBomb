using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallBomb
{
    class Program
    {
        // Vars
        public static string accountSid = "**********";
        public static string authToken = "***********";
        public static List<string> phoneNumbers = new List<string>( new string[] { "***********" });
        
        public static string targetNum = "";
                          

        static void Main(string[] args)
        {
            Console.WriteLine("===== Phone Scammer Tele-Bomb V1 =====");
            Console.WriteLine("Enter the Target Number: ");
            targetNum = Console.ReadLine();
            Console.WriteLine("WARNING: Target " + targetNum + " is acquired, Press enter to confirm, otherwise quit now...");
            Console.ReadLine();
            Console.Clear();

            TwilioClient.Init(accountSid, authToken);

            int count = 1;
            do
            {
                Console.WriteLine("Starting Call Batch " + count);
                foreach(string phoneNum in phoneNumbers)
                {
                    Call(phoneNum);
                    System.Threading.Thread.Sleep(1000);
                }
                count++;
                System.Threading.Thread.Sleep(5000);

            } while (true);
            
        }

        static void Call(string caller)
        {
            try
            {
                var call = CallResource.Create(
                    to: new PhoneNumber(targetNum),
                    from: new PhoneNumber(caller),
                    record: true,
                    url: new Uri("http://demo.twilio.com/docs/classic.mp3")
                    );

                Console.WriteLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format($"Error with number: {caller}, {ex.Message}"));
            }

        }
    }
}
