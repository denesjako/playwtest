using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace PlaywrightTests;
    public class Tools
    {

        public Tools()
        {
        }

        public static string GenerateRandomNumberWithLength(int length)
        {
            Random random = new Random();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                output.Append(random.Next(0, 10));
            }
                         
            return output.ToString();
        }

        public static string GenerateRandomNumberUpToHundred()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            return randomNumber.ToString();
        }

        public static Credentials GetCredentials()
        {
                string configFile = "config.json";
                if (!File.Exists(configFile))
                {
                    Console.WriteLine("Config file not found.");
                }

                string json = File.ReadAllText(configFile);

                Credentials? credentials = JsonConvert.DeserializeObject<Credentials>(json);

                if (credentials == null)
                {
                    Console.WriteLine("Failed to read credentials from the config file.");
                }

                return credentials;
        }

        public static string GetEmail()
        {
            var credentials = GetCredentials();
            return credentials.Email;
        }

        public static string GetPassword()
        {
            var credentials = GetCredentials();
            return credentials.Password;
        }
    }
